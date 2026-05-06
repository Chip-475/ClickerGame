using UnityEngine;
using System.Collections;
public class autoClick : MonoBehaviour
{
    [SerializeField] private clicker click;
    public GameObject timer;
    public GameObject point;
    public void onClick()
    {
        data.autoclickAmount--;

        data.perkUsed++;
        click.startAutoclicker();
        Instantiate(timer, point.transform);
    }

}
