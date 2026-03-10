using UnityEngine;
using System.Collections;

public class cannonManager : MonoBehaviour
{
    //WIP NON MODIFICARE O TI AMMAZZO LA FAMIGLIA
    public bool shoot1, shoot2;
    public GameObject cannon_1, cannon_2;
    [SerializeField] private Transform[] points = new Transform[6];
    private float step1, time2;
    private bool shooting1, shooting2;
    
    IEnumerator cannon1()
    {
        shooting1 = true;
        int r = Random.Range(0, 5);
        Debug.Log(r);
        cannon_1.transform.rotation = Quaternion.FromToRotation(cannon_1.transform.position, points[r].position);
        yield return new WaitForSeconds(2);
        shooting1 = false;
        step1 = 0;
    } 
    IEnumerator cannon2()
    {
        shooting2 = true;
        int r = Random.Range(0, 5);
        transform.rotation = Quaternion.Slerp(transform.rotation, points[r].rotation, time2);
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
            step1 = Time.deltaTime;
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
