using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class JCorruptDoor
{
    public bool isCorrupt;
}


public class CorruptDoor : GlitchObject
{
    private void Start()
    {
        jsonFileName = "door";

        if (!File.Exists(playerSelectedFilePath + "/" + jsonFileName + ".json"))
        {
            File.Delete(playerSelectedFilePath + "/" + jsonFileName + ".json");
        }
        File.Create(playerSelectedFilePath + "/" + jsonFileName + ".json").Dispose();
        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json", playerSelectedFilePath + "/" + jsonFileName + ".json", true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ApplyChange();
        }
    }

    public override void ApplyChange()
    {
        string filepath = playerSelectedFilePath + "/" + jsonFileName + ".json";
        string jsontext = System.IO.File.ReadAllText(filepath);

        JCorruptDoor obj = readJSON(jsontext);
        print(obj.isCorrupt);
        gameObject.SetActive(obj.isCorrupt);
    }
    public JCorruptDoor readJSON(string jsontext)
    {
        try
        {
            return JsonUtility.FromJson<JCorruptDoor>(jsontext);
        }
        catch (Exception)
        {
            Debug.Log("INVALID JSON RESETING");

            if (!File.Exists(playerSelectedFilePath + "/" + jsonFileName + ".json"))
            {
                File.Delete(playerSelectedFilePath + "/" + jsonFileName + ".json");
            }
            File.Create(playerSelectedFilePath + "/" + jsonFileName + ".json").Dispose();
            File.Copy(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json", playerSelectedFilePath + "/" + jsonFileName + ".json", true);

            return JsonUtility.FromJson<JCorruptDoor>(System.IO.File.ReadAllText(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json"));
        }
    }
}
