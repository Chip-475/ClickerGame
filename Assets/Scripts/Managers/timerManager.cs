using TMPro;
using UnityEngine;

public class timerManager : MonoBehaviour
{
    public float timeElapsed = 0f;
    public int timer = 30;
    public TMP_Text timerText;

    private void Start()
    {
        Destroy(gameObject,30.5f);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timer)
        {
            return;
        }
        if (timer - timeElapsed < 10f)
        {
            timerText.text = "00:0" + Mathf.CeilToInt(timer - timeElapsed);
        }
        else
        {
            timerText.text = "00:" + Mathf.CeilToInt(timer - timeElapsed);
        }


    }
}
