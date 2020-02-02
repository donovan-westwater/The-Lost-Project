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
    public bool spin = true;
    public Vector3 spindir;
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
        if (spin) this.transform.rotation *= Quaternion.Euler(spindir.x * Time.deltaTime, spindir.y * Time.deltaTime, spindir.z * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.F)) //This is test code, remove when implemented in player
        {
            ApplyChange();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Start();
        }
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
        try
        {
            return JsonUtility.FromJson<Spinning_Object>(jsontext);
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
            return JsonUtility.FromJson<Spinning_Object>(System.IO.File.ReadAllText(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json"));
        }

    }
}
