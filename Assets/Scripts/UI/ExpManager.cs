using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    public int explvl = 0;
    public int expreq = 100;
    void Update()
    {
        if (explvl < 10)
        {
            if (data.exp > expreq)
            {
                explvl += 1;
                expreq += expreq / 3;
            }
        }
        else
            {
                if (data.exp > expreq)
                {
                    explvl += 1;
                    expreq = (int)(100 * Mathf.Pow(explvl, 1.5f));
                }
            }
    }
}
