using UnityEngine;

public class CannonUnlockButton : MonoBehaviour
{
    public AudioClip upgradeSFX;
    public void OnClick()
    {
        audioManager.manager.playSFX(upgradeSFX, transform, data.sfx);
        if (data.cannon1==false)
        {
            data.cannon1 = true;
            data.money -= CannonUnlockManager.cannonUnlock1Cost;
            Debug.Log("1");
        }
        else
        {
            data.cannon2 = true;
            data.money -= CannonUnlockManager.cannonUnlock2Cost;
            Debug.Log("2");
        }
    }
}
