using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.AccessControl;
using System;

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

        try
        {
            File.Create(playerSelectedFilePath + "/" + "testForFolder" + ".txt").Dispose();
            File.Delete(playerSelectedFilePath + "/" + "testForFolder" + ".txt");
        }
        catch (Exception)
        {
            playerSelectedFilePath = Application.dataPath + "/Result";
        }

        sourceFilePath = Application.dataPath + "/Source";
    }

    public void SendFileToPlayer(string fileName)
    {
        if (!File.Exists(playerSelectedFilePath + "/" + fileName))
        {
            File.Delete(playerSelectedFilePath + "/" + fileName);
        }
        File.Create(playerSelectedFilePath + "/" + fileName).Dispose();
        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + fileName, playerSelectedFilePath + "/" + fileName, true);
    }
}
