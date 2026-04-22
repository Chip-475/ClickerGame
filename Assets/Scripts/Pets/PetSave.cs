using System.IO;
using UnityEngine;

public static class PetSave
{
    private static string path = Application.persistentDataPath + "/save.json";
    static string id;

    public static void Save(data data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public static data  Load()
    {
        if (!File.Exists(path))
            return new data();

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<data>(json);
    }
}