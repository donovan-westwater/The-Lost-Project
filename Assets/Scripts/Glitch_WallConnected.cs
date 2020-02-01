using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class WallConnected
{
    public bool SetOneIsActive;
    public bool SetTwonIsActive;
}

public class Glitch_WallConnected : GlitchObject
{
    public bool isSetOne = false;

    private void Start()
    {
        jsonFileName = "WallConnected";

        if (!File.Exists(playerSelectedFilePath + "/" + jsonFileName + ".json"))
        {
            File.Delete(playerSelectedFilePath + "/" + jsonFileName + ".json");
        }
        File.Create(playerSelectedFilePath + "/" + jsonFileName + ".json").Dispose();
        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json", playerSelectedFilePath + "/" + jsonFileName + ".json", true);
    }

    public override void ApplyChange()
    {
        string filepath = playerSelectedFilePath + "/" + jsonFileName + ".json";
        string jsontext = System.IO.File.ReadAllText(filepath);

        WallConnected obj = readJSON(jsontext);
        if (obj.SetOneIsActive)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(obj.SetOneIsActive);
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(obj.SetTwonIsActive);
        }
    }
    public WallConnected readJSON(string jsontext)
    {
        try
        {
            return JsonUtility.FromJson<WallConnected>(jsontext);
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

            return JsonUtility.FromJson<WallConnected>(System.IO.File.ReadAllText(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json"));
        }
    }
}
