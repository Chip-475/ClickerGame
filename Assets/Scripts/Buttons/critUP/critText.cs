using UnityEngine;

public class critText : MonoBehaviour
{
    float spstX, spstY;

    void Start()
    {
        do
        {
            if(Screen.height > Screen.width)
            {
                spstX = Random.Range(-Screen.width / 3, Screen.width / 3);
                spstY = Random.Range(-Screen.height / 6, Screen.height / 6);
            }else if(Screen.height < Screen.width)
            {
                spstX = Random.Range(-Screen.width / 6, Screen.width / 6);
                spstY = Random.Range(-Screen.height / 3, Screen.height / 3);
            }
            else
            {
                spstX = Random.Range(-Screen.width / 4, Screen.width / 4);
                spstY = Random.Range(-Screen.height / 4, Screen.height / 4);
            }
        } while (spstX > -75 && spstX < 75 && spstY > -75 && spstY < 75);
        transform.position += new Vector3(spstX, spstY);
        Destroy(gameObject, 1);
    }
}