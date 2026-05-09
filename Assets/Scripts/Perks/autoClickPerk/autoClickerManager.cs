using UnityEngine;
using System.Collections;
public class autoClickerManager : MonoBehaviour
{
    [SerializeField] private clicker click;
    [SerializeField] private GameObject met;
    public static autoClickerManager Instance;
    public void stavoltastartadavverolautoclicker()
    {
        StartCoroutine(autoclick(clicker.AutoClickerDuration));
    }
    public void Start()
    {
        Instance = this;
    }
    public IEnumerator autoclick(float duration)
    {
        clicker.autoClicker = true;
        float endTime=Time.time+duration;

        while (Time.time<endTime)
        {
            if (met.activeSelf)
            {
                meteor.hpMeteor = Mathf.Clamp(meteor.hpMeteor - clicker.clickStr, 0, meteor.hpMeteor);
            }
            yield return new WaitForSeconds(0.1f);
        }
        clicker.autoClicker = false;
    }
}
