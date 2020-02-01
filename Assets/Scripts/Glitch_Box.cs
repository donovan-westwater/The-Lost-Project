using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.AccessControl;

[System.Serializable]
public class BoxJson
{
    public bool isActive;
}

public class Glitch_Box : GlitchObject
{
    bool isCollidable;

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
    }
    //Applies changes from the file to the wall in game
    public override void ApplyChange()
    {
        string filepath = playerSelectedFilePath + "/" + jsonFileName + ".json";
        string jsontext = System.IO.File.ReadAllText(filepath);

        BoxJson obj = readJSON(jsontext);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.SetActive(obj.isActive);
    }
    public override void RefreshData(string data)
    {
        print(data); //replace later
    }
    //Turns the raw string info from the text file into the wall's seralized object
    public BoxJson readJSON(string jsontext)
    {
        return JsonUtility.FromJson<BoxJson>(jsontext);
    }
}
