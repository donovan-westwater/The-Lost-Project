using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class FlipJson
{
    public bool IsEnabled;
}


public class Glitch_Flip : GlitchObject
{
    public bool isFlipped = false;

    private void Start()
    {
        jsonFileName = "Flip";

        if (!File.Exists(playerSelectedFilePath + "/" + jsonFileName + ".json"))
        {
            File.Delete(playerSelectedFilePath + "/" + jsonFileName + ".json");
        }
        File.Create(playerSelectedFilePath + "/" + jsonFileName + ".json").Dispose();
        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json", playerSelectedFilePath + "/" + jsonFileName + ".json", true);
    }

    public override void ApplyChange()
    {
        jsonFileName = "Flip";
        string filepath = playerSelectedFilePath + "/" + jsonFileName + ".json";
        string jsontext = System.IO.File.ReadAllText(filepath);

        FlipJson obj = readJSON(jsontext);
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(CheckForFlip(!obj.IsEnabled));
        }
    }
    public FlipJson readJSON(string jsontext)
    {
        try
        {
            return JsonUtility.FromJson<FlipJson>(jsontext);
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

            return JsonUtility.FromJson<FlipJson>(System.IO.File.ReadAllText(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json"));
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
