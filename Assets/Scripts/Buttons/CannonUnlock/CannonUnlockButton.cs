using UnityEngine;

public class CannonUnlockButton : MonoBehaviour
{
    public AudioClip upgradeSFX;
    public void OnClick()
    {
        audioManager.manager.playSFX(upgradeSFX, transform, data.sfx);
        if (data.cannon1==false)
        {
            if (data.money >= 2500)
            {
            data.cannon1 = true;
            data.money -= CannonUnlockManager.cannonUnlock1Cost;
            Debug.Log("1");
            }
            else
            {
                return;

            }
        }
        if(data.cannon2==false)
        {
            if (data.money >= 5000)
            {
            data.cannon2 = true;
            data.money -= CannonUnlockManager.cannonUnlock2Cost;
            Debug.Log("2");
            }
            else
            {
                return;
            }

        }
    }
}
