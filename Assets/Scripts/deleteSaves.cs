using System.IO;
using UnityEngine;

public class deleteSaves : MonoBehaviour
{
    public void onClick()
    {
        SaveAndLoad.ResetAllData();
    }
}
