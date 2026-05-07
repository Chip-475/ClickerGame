using UnityEngine;

public class sorting : MonoBehaviour
{
    public petStats stats;
    //rarity,rank,lvl
    public void sort()
    {
        if (sortManager.type == sortManager.sorting.rank)
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
        if (sortManager.type == sortManager.sorting.rarity)
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
        if (sortManager.type == sortManager.sorting.level)
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
    }
}
