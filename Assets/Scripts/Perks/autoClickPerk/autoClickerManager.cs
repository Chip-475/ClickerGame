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
        Debug.Log("autocliker");
        clicker.autoClicker = true;
        float t = duration;
        while (t>=0)
        {
            if (met.activeSelf)
            {
                meteor.hpMeteor -= clicker.clickStr;
                yield return new WaitForSeconds(1);
                t--;
                Debug.Log(t);
            }
            yield return null;
            Debug.Log("non funziona cane dio");
            Debug.Log(t);
        }
        Debug.Log("fuori while");
        clicker.autoClicker = false;
    }
}
