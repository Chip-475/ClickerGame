using UnityEngine;
using UnityEngine.InputSystem;

public class gameManager : MonoBehaviour
{
    private void Awake()
    {
        if (InputSystem.settings != null)
        {
            InputSystem.settings.maxEventBytesPerUpdate = 0;
        }
    }

}
