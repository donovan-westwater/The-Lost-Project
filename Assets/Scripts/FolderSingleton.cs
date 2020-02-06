using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.AccessControl;
using System;
using static System.Environment;
public class FolderSingleton : MonoBehaviour
{
    public static FolderSingleton INSTANCE;
    [HideInInspector]
    public string playerSelectedFilePath;

    void Awake()
    {
        if (INSTANCE == null && INSTANCE != this)
        {
            INSTANCE = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        playerSelectedFilePath = SpecialFolder.MyDocuments+"/TheLostGame";
        Directory.CreateDirectory(playerSelectedFilePath);
    }

    public string GetFullTextFromSource(string fileName)
    {
        string shortFileName = fileName;
        if (fileName.IndexOf(".") > 0)
        {
            shortFileName = fileName.Remove(fileName.IndexOf("."));
        }
        TextAsset newFile = (TextAsset)Resources.Load("Source/" + shortFileName);
        string newFileText = newFile.text;
        return newFileText;
    }
    public string GetFullTextFromPlayer(string fileName)
    {
        string shortFileName = fileName;
        if (fileName.IndexOf(".") > 0)
        {
            shortFileName = fileName.Remove(fileName.IndexOf("."));
        }

        string filepath = playerSelectedFilePath + "/" + fileName + ".json";
        string jsontext = System.IO.File.ReadAllText(filepath);
        return jsontext;
    }

    public void SendFileToPlayer(string fileName)
    {
        //File.Delete(playerSelectedFilePath + "/" + fileName);
        //File.Create(playerSelectedFilePath + "/" + fileName).Dispose();

        DeleteFileFromPlayer(fileName);
        File.Create(playerSelectedFilePath + "/" + fileName).Dispose();
        File.WriteAllText(playerSelectedFilePath + "/" + fileName, GetFullTextFromSource(fileName));
    }

    public void DeleteFileFromPlayer(string fileName)
    {
        if (File.Exists(playerSelectedFilePath + "/" + fileName))
        {
            File.Delete(playerSelectedFilePath + "/" + fileName);
        }
    }

    public bool DoesFileExistForPlayer(string fileName)
    {
        return File.Exists(playerSelectedFilePath + "/" + fileName);
    }


}
