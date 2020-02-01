using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.AccessControl;

public class FolderSingleton : MonoBehaviour
{
    public static FolderSingleton instance;
    public string playerSelectedFilePath;
    public string sourceFilePath;

    void Awake()
    {
        if (instance == null && instance != this)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        if (!File.Exists(playerSelectedFilePath))
        {
            playerSelectedFilePath = Application.dataPath+"/Result";
            sourceFilePath = Application.dataPath + "/Source";
        }
    }
}
