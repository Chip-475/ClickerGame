using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{

    public TMP_Text moneyCounter;

    private void Update()
    {
        moneyCounter.text = "Money: " + data.money;
    }

}
