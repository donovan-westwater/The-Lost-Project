using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class Spinning_Object
{
   public bool isSpinning;
}
public class Toggle_Rot : GlitchObject
{
    bool spin = true;
    // Start is called before the first frame update
    private void Start()
    {
        jsonFileName = "Spin";

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
        if (spin) this.transform.rotation *= Quaternion.Euler(50f * Time.deltaTime, 0, 0);  
    }
    public override void ApplyChange()
    {
        string filepath = playerSelectedFilePath + "/" + jsonFileName + ".json";
        string jsontext = System.IO.File.ReadAllText(filepath);

        Spinning_Object obj = readJSON(jsontext);
        spin = obj.isSpinning;

    }
    //Turns the raw string info from the text file into the wall's seralized object
    public Spinning_Object readJSON(string jsontext)
    {
        return JsonUtility.FromJson<Spinning_Object>(jsontext);

    }
}
