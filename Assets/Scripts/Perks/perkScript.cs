using System.Collections;
using UnityEngine;

public class perkScript : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject arrivalPoint;
    public enum perkType
    {
        clickUp,
        critUp,
        goldMeteor,
        autoClick
    }

    public perkType type;

    IEnumerator move(GameObject _arrivalPoint)
    {
        float moveTime = 100;
        float t = 0;
        while (t < moveTime && transform.position != _arrivalPoint.transform.position)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, _arrivalPoint.transform.position, 1 - Mathf.Pow(1 - (t / moveTime), 3));
            if(transform.position==_arrivalPoint.transform.position ) { yield return null; }
            yield return null;
        }
    }

    private void Start()
    {
        parentObject = gameObject.transform.parent.gameObject;
        if (parentObject.tag == "ArrivalPoint1")
        {
            arrivalPoint = GameObject.Find("arrivalPoint1");
        }
        else if (parentObject.tag == "ArrivalPoint2")
        {
            arrivalPoint = GameObject.Find("arrivalPoint2");
        }
        transform.parent = GameObject.Find("safeArea").transform;
        StartCoroutine(move(arrivalPoint));
        print(transform.parent.name);
        Destroy(gameObject, 5);
    }

    public void onClick()
    {
        switch (type)
        {
            case perkType.clickUp:
                data.clickPerkAmount++;
                Destroy(gameObject);
                break;
            case perkType.critUp:
                data.critPerkAmount++;
                Destroy(gameObject);
                break;
            case perkType.goldMeteor:
                data.goldMeteorAmount++;
                Destroy(gameObject);
                break;
        }
    }
}