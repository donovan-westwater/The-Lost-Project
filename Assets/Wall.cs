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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void applyChange()
    {
        string filepath = Path.Combine(Directory.GetCurrentDirectory(),"\\"+filename+".json");
        string jsontext = System.IO.File.ReadAllText(filepath);
        Filewall obj = readJSON(jsontext);
        this.transform.position = obj.pos;
        this.transform.eulerAngles = obj.rot;
        isCorrupted = obj.isActive;

    }
    public Filewall readJSON(string jsontext)
    {
        return JsonUtility.FromJson<Filewall>(jsontext);

    }

}
