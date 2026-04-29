using System.Collections;
using UnityEngine;

public class perkScript : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject arrivalPoint;

    public Vector3 targetPosition;
    public float moveTime = 0.5f;

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
        Vector3 startPosition = transform.position;
        float t = 0f;

        while (t < moveTime)
        {
            t += Time.deltaTime;
            float normalizedTime = t / moveTime;
            float easedTime = 1 - Mathf.Pow(1 - normalizedTime, 3);

            transform.position = Vector3.Lerp(startPosition, targetPosition, easedTime);
            yield return null;
        }

        transform.position = targetPosition;
    }

    private void Start()
    {
        StartCoroutine(move());
        Destroy(gameObject, 5f);
    }

    public void SetTargetPosition(Vector3 target)
    {
        targetPosition = target;
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
            case perkType.autoClick:
                data.autoclickAmount++;
                Destroy (gameObject); 
                break;
        }
    }
}
