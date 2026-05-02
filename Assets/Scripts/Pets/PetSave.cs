using UnityEngine;

public static class PetSave
{
    public static void Save(data _)
    {
        SaveAndLoad.SaveNow();
    }

    public static data Load()
    {
        SaveAndLoad.LoadNow();
        return new data();
    }
}
