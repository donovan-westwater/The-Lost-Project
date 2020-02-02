using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class WallConnected
{
    public bool SetOneIsActive;
    public bool SetTwoIsActive;
}

public class Glitch_WallConnected : GlitchObject
{
    public bool isSetOne = false;
    public bool isFlipped = false;

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
        jsonFileName = "WallConnected";
        string filepath = playerSelectedFilePath + "/" + jsonFileName + ".json";
        string jsontext = System.IO.File.ReadAllText(filepath);

        WallConnected obj = readJSON(jsontext);
        if (isSetOne)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).gameObject.SetActive(CheckForFlip(obj.SetOneIsActive));
            }
        }
        else
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).gameObject.SetActive(CheckForFlip(obj.SetTwoIsActive));
            }
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

    bool CheckForFlip(bool input)
    {
        if (isFlipped)
        {
            return !input;
        }
        else
        {
            return input;
        }
    }
}
