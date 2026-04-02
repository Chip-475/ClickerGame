using UnityEngine;

public class baseClickPickUp : MonoBehaviour
{
    public void critUpPickup()
    {
        data.clickPerk++;
        //animationPH
        Destroy(gameObject);
    }
}