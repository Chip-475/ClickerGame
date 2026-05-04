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
        float t = duration;

        while (t>=0)
        {
            yield return new WaitForSeconds(0.2f);
            t -= 0.2f;
            if (met.activeSelf)
            {
                meteor.hpMeteor -= clicker.clickStr;
                Debug.Log(t);
            }
            yield return null;
            Debug.Log(t);
        }
        clicker.autoClicker = false;
    }
}
