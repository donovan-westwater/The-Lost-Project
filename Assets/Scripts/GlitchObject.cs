using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public abstract class GlitchObject : MonoBehaviour
{
    [HideInInspector]
    public string playerSelectedFilePath;
    [HideInInspector]
    public string jsonFileName;

    public virtual void ApplyChange() { }

    private void Awake()
    {
        playerSelectedFilePath = FolderSingleton.instance.playerSelectedFilePath;
    }

    public void CreateJSON(string jsonName)
    {
        if (!File.Exists(playerSelectedFilePath + "/" + jsonName + ".json"))
        {
            File.Delete(playerSelectedFilePath + "/" + jsonName + ".json");
        }
        File.Create(playerSelectedFilePath + "/" + jsonName + ".json").Dispose();
        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + jsonName + ".json", playerSelectedFilePath + "/" + jsonName + ".json", true);
    }
}
