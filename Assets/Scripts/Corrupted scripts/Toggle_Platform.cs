using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
[Serializable]
public class MovingPlatform
{
    public bool isMoving;
}
public class Toggle_Platform : GlitchObject
{
    public bool move = true;
    bool reverse = false;
    public float travelDist = 50f;
    float currentDis = 0;
    // Start is called before the first frame update
    private void Start()
    {
        jsonFileName = "MovingPlatform";

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
       //Debug.Log("IM RUNNING");
        if (move) {
            if(!reverse)
            {
                if (currentDis > travelDist) reverse = true;
                this.transform.position += 5 * this.transform.forward * Time.deltaTime;
                currentDis += 5 * this.transform.forward.magnitude * Time.deltaTime;
            }
            else if(reverse)
            {
                if (currentDis < 0) reverse = false;
                this.transform.position -= 5 * this.transform.forward * Time.deltaTime;
                currentDis -= 5 * this.transform.forward.magnitude * Time.deltaTime;
            }
            
        }
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

        MovingPlatform obj = readJSON(jsontext);
        move = obj.isMoving;

    }
    //Turns the raw string info from the text file into the wall's seralized object
    public MovingPlatform readJSON(string jsontext)
    {
        try
        {
            return JsonUtility.FromJson<MovingPlatform>(jsontext);
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
            return JsonUtility.FromJson<MovingPlatform>(System.IO.File.ReadAllText(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json"));
        }

    }
}
