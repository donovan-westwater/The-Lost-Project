using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Security.AccessControl;
using TMPro;

[System.Serializable]
public class BoxJson
{
    public bool isActive;
   // public string comment;
}


public class Glitch_Box : GlitchObject
{
    bool isCollidable;
    //public TextMeshProUGUI text;

    private void Start()
    {
        jsonFileName = "Box";

        if (!File.Exists(playerSelectedFilePath + "/" + jsonFileName + ".json"))
        {
            File.Delete(playerSelectedFilePath + "/" + jsonFileName + ".json");
        }
        File.Create(playerSelectedFilePath + "/" + jsonFileName + ".json").Dispose();
        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json", playerSelectedFilePath + "/" + jsonFileName + ".json", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //This is test code, remove when implemented in player
        {
            ApplyChange();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Start();
        }
    }
    //Applies changes from the file to the wall in game
    public override void ApplyChange()
    {
        string filepath = playerSelectedFilePath + "/" + jsonFileName + ".json";
        string jsontext = System.IO.File.ReadAllText(filepath);

        BoxJson obj = readJSON(jsontext);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(obj.isActive);
        //text.text = obj.comment;
    }
    public override void RefreshData(string data)
    {
        print(data); //replace later
    }
    //Turns the raw string info from the text file into the wall's seralized object
    public BoxJson readJSON(string jsontext)
    {
        try
        {
            return JsonUtility.FromJson<BoxJson>(jsontext);
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
            return JsonUtility.FromJson<BoxJson>(System.IO.File.ReadAllText(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json"));
        }
    }
}