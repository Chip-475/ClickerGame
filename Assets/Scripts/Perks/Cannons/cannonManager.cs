using UnityEngine;
using System.Collections;

public class cannonManager : MonoBehaviour
{
    //WIP NON MODIFICARE DIO CANE BASTARDO
    public bool shoot1, shoot2;
    public GameObject cannon_1, cannon_2;
    [SerializeField] private Transform[] points = new Transform[6];
    private float step1, time2;
    private bool shooting1, shooting2;
    
    IEnumerator cannon1()
    {
        shooting1 = true;
        int r = Random.Range(0, 3);
        Debug.Log(r);
        while(cannon_1.transform.rotation != Quaternion.FromToRotation(cannon_1.transform.position, points[r].position))
        {
            cannon_1.transform.rotation =
            Quaternion.RotateTowards
            (
                cannon_1.transform.rotation,
                Quaternion.FromToRotation(cannon_1.transform.position, points[r].position),
                step1
            );
            yield return new WaitForFixedUpdate();
            step1 = Time.deltaTime * 15;
        }
        yield return new WaitForSeconds(2);
        shooting1 = false;
        step1 = 0;
    } 
    IEnumerator cannon2()
    {
        shooting2 = true;
        int r = Random.Range(0, 5);
        transform.rotation = Quaternion.LookRotation(points[r].forward, Vector2.up);
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(5);
        shooting2 = false;
        time2 = 0;
    }
    void Update()
    {
        if (shoot1)
        {
            if (!shooting1)
            {
                StartCoroutine(cannon1());
            }
        }
        if (shoot2)
        {
            if (!shooting2)
            {
                StartCoroutine(cannon2());
            }
            time2 = Time.deltaTime;
        }
    }
}
