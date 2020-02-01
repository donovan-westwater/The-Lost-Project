using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class Filewall
{
    public bool isActive;
    public Vector3 pos;
    public Vector3 rot;
}
//json format ex: {"isActive" : true,"pos":{"x":100.7,"y":0.7,"z":1.7},"rot":{"x":50,"y":0,"z":0}}
public class Wall : GlitchObject
{
    public string filename;
    bool isCorrupted = true;
    
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
        string filepath = "./" + filename + ".json";//Path.Combine(Directory.GetCurrentDirectory(),"../"+filename+".json");
        string jsontext = System.IO.File.ReadAllText(filepath);
        Filewall obj = readJSON(jsontext);
        this.transform.position = obj.pos;
        this.transform.eulerAngles = obj.rot;
        isCorrupted = obj.isActive;

    }
    public override void RefreshData(string data)
    {
        print(data); //replace later
    }
    //Turns the raw string info from the text file into the wall's seralized object
    public Filewall readJSON(string jsontext)
    {
        return JsonUtility.FromJson<Filewall>(jsontext);

    }

}
