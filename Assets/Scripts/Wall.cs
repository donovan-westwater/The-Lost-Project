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
public class Wall : MonoBehaviour
{
    public string filename;
    bool isCorrupted = true;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //This is test code, remove when implemented in player
        {
            applyChange();
        }
    }
    //Applies changes from the file to the wall in game
    void applyChange()
    {
        string filepath = "./" + filename + ".json";//Path.Combine(Directory.GetCurrentDirectory(),"../"+filename+".json");
        string jsontext = System.IO.File.ReadAllText(filepath);
        Filewall obj = readJSON(jsontext);
        this.transform.position = obj.pos;
        this.transform.eulerAngles = obj.rot;
        isCorrupted = obj.isActive;

    }
    //Turns the raw string info from the text file into the wall's seralized object
    public Filewall readJSON(string jsontext)
    {
        return JsonUtility.FromJson<Filewall>(jsontext);

    }

}
