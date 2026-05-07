using UnityEngine;

public class cancel : MonoBehaviour
{
    public GameObject cancelPanel;
public void toggleCancel()
    {
        cancelPanel.SetActive(!cancelPanel.activeSelf);
    }
}
