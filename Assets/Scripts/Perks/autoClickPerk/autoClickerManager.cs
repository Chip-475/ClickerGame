using UnityEngine;
using System.Collections;
public class autoClickerManager : MonoBehaviour
{
    [SerializeField] private clicker click;
    public IEnumerator autoclick()
    {
        click.isAutoClicking = true;
        click.click();
        click.autoClickerTimer -= 1f;
        Debug.Log(click.autoClickerTimer);
        yield return new WaitForSeconds(1f);
        click.isAutoClicking = false;
        
    }
}
