using UnityEngine;
using System.Collections;

public class cannon_2 : MonoBehaviour
{
    private const int DefaultShootCost2 = 30;

    public bool shoot2;
    public GameObject cannon2, shootPoint;
    public int shootCost2 = DefaultShootCost2;
    public float step;

    [Header("fire rate")]
    public float baseFireTime = 1f;
    public float baseWaitingTime = 7.5f;
    public float fireRateReductionPerLevel = 0.05f;

    public GameObject[] perk = new GameObject[0];

    private bool shooting2;

    private static int CurrentPerkCount()
    {
        return data.clickPerkAmount
            + data.critPerkAmount
            + data.goldMeteorAmount
            + data.autoclickAmount
            + data.spawnedPerkCount
            + data.pendingPerkCount;
    }

    IEnumerator _cannon1()
    {
        shooting2 = true;
        data.fuel1 -= shootCost2;

        int x = UnityEngine.Random.Range(-410, -230);
        int y = UnityEngine.Random.Range(200, 520);
        int r = UnityEngine.Random.Range(0, perk.Length);

        Quaternion targetRotation = Quaternion.FromToRotation(cannon2.transform.position, new Vector3(x, y, 0));

        while (cannon2.transform.rotation != targetRotation)
        {
            cannon2.transform.rotation = Quaternion.RotateTowards(
                cannon2.transform.rotation,
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
            perkScriptComponent.SetTargetPosition(GameObject.Find("arrivalPoint2").transform.position);
        }

        yield return new WaitForSeconds(baseWaitingTime - (fireRateReductionPerLevel * data.cannonFireRatelvl));
        shooting2 = false;
    }

    private void Start()
    {
        if (shootCost2 <= 0)
        {
            shootCost2 = DefaultShootCost2;
        }

        step = Time.deltaTime * 15f;
    }

    void Update()
    {
        shoot2 = data.cannon2;

        data.fuel1 = Mathf.Clamp(data.fuel1, 0, cannon_1.totalDepot);

        if (shoot2 && data.fuel1 >= shootCost2 && !shooting2 && data.PerkLimit > CurrentPerkCount())
        {
            data.pendingPerkCount++;
            StartCoroutine(_cannon1());
        }
    }
}
