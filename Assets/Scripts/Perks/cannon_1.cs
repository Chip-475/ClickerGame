using UnityEngine;
using System.Collections;

public class cannon_1 : MonoBehaviour
{
    public bool shoot1;
    public GameObject cannon1, shootPoint;
    public int shootCost1;
    public float step;

    [Header("fire rate")]
    public float baseFireTime = 1f;
    public float baseWaitingTime = 7.5f;
    public float fireRateReductionPerLevel = 0.05f;

    [Header("depot")]
    public int baseMaxFuel1 = 100;
    public int depotBonusPerLevel = 25;

    public GameObject[] perk = new GameObject[0];

    private bool shooting1;

    IEnumerator _cannon1()
    {
        shooting1 = true;
        data.fuel1 -= shootCost1;
        int x = UnityEngine.Random.Range(230, 410);
        int y = UnityEngine.Random.Range(120, 520);
        int r = UnityEngine.Random.Range(0, perk.Length);

        Quaternion targetRotation = Quaternion.FromToRotation(cannon1.transform.position, new Vector3(x, y, 0));

        while (Quaternion.Angle(cannon1.transform.rotation, targetRotation) > 0.1f)
        {
            cannon1.transform.rotation = Quaternion.RotateTowards(
                cannon1.transform.rotation,
                targetRotation,
                step
            );
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(baseFireTime - (fireRateReductionPerLevel * data.cannonFireRatelvl));

        GameObject safeArea = GameObject.Find("safeArea");
        GameObject perkInstance = Instantiate(perk[r], shootPoint.transform.position, Quaternion.identity, safeArea.transform);

        perkScript perkScriptComponent = perkInstance.GetComponent<perkScript>();
        if (perkScriptComponent != null)
        {
            perkScriptComponent.SetTargetPosition(GameObject.Find("arrivalPoint1").transform.position);
        }
        yield return new WaitForSeconds(baseWaitingTime - (fireRateReductionPerLevel * data.cannonFireRatelvl));
        shooting1 = false;
    }

    private void Start()
    {
        step = Time.deltaTime * 15f;
    }

    void Update()
    {
        shoot1 = data.cannon1;

        data.fuel1 = Mathf.Clamp(data.fuel1, 0, 100 + (data.cannonDepotlvl * 10));

        if (shoot1 && data.fuel1 > shootCost1 && !shooting1&&data.PerkLimit != data.totalPerk)
        {
            StartCoroutine(_cannon1());
        }
    }
}
