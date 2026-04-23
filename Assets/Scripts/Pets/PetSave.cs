using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class PetSave
{
    private static string path = Application.persistentDataPath + "/petSave.json";

    public static void Save(data _)
    {
        PetInventorySaveData saveData = new PetInventorySaveData
        {
            pets = new List<PetInstance>(data.pets)
        };

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(path, json);
    }

    public static data Load()
    {
        if (!File.Exists(path))
        {
            data.pets = new List<PetInstance>();
            return new data();
        }

        string json = File.ReadAllText(path);
        PetInventorySaveData saveData = JsonUtility.FromJson<PetInventorySaveData>(json);
        data.pets = saveData.pets;
        return new data();
    }
}

[System.Serializable]
public class PetInventorySaveData
{
    public List<PetInstance> pets = new List<PetInstance>();
}
