using UnityEngine;
using System.Collections;
public class autoClick : MonoBehaviour
{
    [SerializeField] private clicker click;

    public void onClick()
    {

        data.autoclickAmount--;
        data.perkUsed++;
        click.startAutoclicker();
        
    }

}
