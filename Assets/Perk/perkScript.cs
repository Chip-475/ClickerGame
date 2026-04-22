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

    IEnumerator move()
    {
        Debug.Log("CR");
        int moveTime = 2;
        float t = 0;
        while (t < moveTime)
        {
            Debug.Log("CR");
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, arrivalPoint.transform.position, t / moveTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private void Start()
    {
        parentObject = gameObject.transform.parent.gameObject;
        arrivalPoint = GameObject.FindGameObjectWithTag("ArrivalPoint");
        StartCoroutine(move());
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
