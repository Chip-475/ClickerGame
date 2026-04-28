using TMPro;
using UnityEngine;

public class CannonUnlockManager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject cannonUnlockbutton;
    public GameObject cannonUnlockfake;
    [Header("Texts")]
    public TMP_Text header;
    public TMP_Text cost;
    public TMP_Text effect;
    [Header("Fake Texts")]
    public TMP_Text fake_header;
    public TMP_Text fake_cost;
    public TMP_Text fake_effect;
    public static int cannonUnlock1Cost = 1500;
    public static int cannonUnlock2Cost = 5000;

    void Update()
    {
        if (data.cannon1 == false)
        {
            header.text = "Unlock Cannon 1";
            fake_header.text = "Unlock Cannon 1";
            effect.text = "Unlocks Cannon 1";
            fake_effect.text = "Unlocks Cannon 1";
            cost.text = "Cost: " + cannonUnlock1Cost;
            fake_cost.text = "Cost: " + cannonUnlock1Cost;
            if (data.money < cannonUnlock1Cost) { cannonUnlockbutton.SetActive(false); cannonUnlockfake.SetActive(true); }
            else { cannonUnlockbutton.SetActive(true); cannonUnlockfake.SetActive(false); }
        }
        else
        {
            header.text = "Unlock Cannon 2";
            fake_header.text = "Unlock Cannon 2";
            effect.text = "Unlocks Cannon 2";
            fake_effect.text = "Unlocks Cannon 2";
            cost.text = "Cost: " + cannonUnlock2Cost;
            fake_cost.text = "Cost: " + cannonUnlock2Cost;
            if (data.money < cannonUnlock2Cost) { cannonUnlockbutton.SetActive(false); cannonUnlockfake.SetActive(true); }
            else { cannonUnlockbutton.SetActive(true); cannonUnlockfake.SetActive(false); }
        }
        if(data.cannon1==true && data.cannon2 == true)
        {
            fake_header.text = "All Cannon Unlocked";
            fake_effect.text = "Good Job";
            fake_cost.text = "Cost:NaN ";
            cannonUnlockbutton.SetActive(false);
            cannonUnlockfake.SetActive(true);
        }
        cost.text = "Cost: " + cost;
        fake_cost.text = "Cost: " + cost;
        
    }
}
