using TMPro;
using UnityEngine;

public class fuelManager : MonoBehaviour
{
    public GameObject fuelButton;
    public GameObject fuelButtonFake;
    public TMP_Text fuelText;
    public TMP_Text fuelTextFake;
    void Update()
    {
        fuelText.text = data.fuel1.ToString() + "/" + cannon_1.totalDepot;
        fuelTextFake.text = data.fuel1.ToString() + "/" + cannon_1.totalDepot;
        if (data.cannon1)
        {
            if (data.fuel1 < cannon_1.totalDepot)
            {
                if (data.money >= 500)
                {
                    fuelButton.SetActive(true);
                    fuelButtonFake.SetActive(false);
                }
                else
                {
                    fuelButton.SetActive(false);
                    fuelButtonFake.SetActive(true);
                }
            }
            else
            {
                fuelButton.SetActive(false);
                fuelButtonFake.SetActive(true);
            }
        }
        else
        {
            fuelButton.SetActive(false);
            fuelButtonFake.SetActive(true);
        }
        
    }
}
