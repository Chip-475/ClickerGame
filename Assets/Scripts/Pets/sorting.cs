using UnityEngine;

public class sorting : MonoBehaviour
{
    public petStats stats;
    public sortManager toggle;
    //rarity,rank,lvl
    public void sort()
    {
        if (sortManager.type == sortManager.sorting.rank)
        {
            if (toggle.sortOrder)
            {
                data.pets.Sort((a, b) =>
                {
                    int result = b.rank.CompareTo(a.rank);
                    if (result == 0)
                        result = stats.getRarity(b).CompareTo(stats.getRarity(a));
                    if (result == 0)
                        result = b.Petlvl.CompareTo(a.Petlvl);
                    return result;
                });
            }
            else
            {
                data.pets.Sort((b, a) =>
                {
                    int result = b.rank.CompareTo(a.rank);
                    if (result == 0)
                        result = stats.getRarity(b).CompareTo(stats.getRarity(a));
                    if (result == 0)
                        result = b.Petlvl.CompareTo(a.Petlvl);
                    return result;
                });
            }
        }
        if (sortManager.type == sortManager.sorting.rarity)
        {
            if (toggle.sortOrder)
            {
                data.pets.Sort((a, b) =>
                {
                    int result = stats.getRarity(b).CompareTo(stats.getRarity(a));
                    if (result == 0)
                        result = b.rank.CompareTo(a.rank);
                    if (result == 0)
                        result = b.Petlvl.CompareTo(a.Petlvl);
                    return result;
                });
            }
            else
            {
                data.pets.Sort((b, a) =>
                {
                    int result = stats.getRarity(b).CompareTo(stats.getRarity(a));
                    if (result == 0)
                        result = b.rank.CompareTo(a.rank);
                    if (result == 0)
                        result = b.Petlvl.CompareTo(a.Petlvl);
                    return result;
                });
            }

        }
        if (sortManager.type == sortManager.sorting.level)
        {
            if (toggle.sortOrder)
            {
                data.pets.Sort((a, b) =>
                {
                    int result = b.Petlvl.CompareTo(a.Petlvl);
                    if (result == 0)
                        result = stats.getRarity(b).CompareTo(stats.getRarity(a));
                    if (result == 0)
                        result = b.rank.CompareTo(a.rank);
                    return result;
                });
            }
            else
            {
                data.pets.Sort((b, a) =>
                {
                    int result = b.Petlvl.CompareTo(a.Petlvl);
                    if (result == 0)
                        result = stats.getRarity(b).CompareTo(stats.getRarity(a));
                    if (result == 0)
                        result = b.rank.CompareTo(a.rank);
                    return result;
                });
            }
        }
    }
}
