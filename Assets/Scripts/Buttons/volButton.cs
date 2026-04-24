using UnityEngine;

public class volButton : MonoBehaviour
{
    public GameObject volMenu;

    public void onClick()
    {
        if (volMenu.activeSelf)
        {
            volMenu.SetActive(false);
        }
        else
        {
            volMenu.SetActive(true);
        }
    }
}
