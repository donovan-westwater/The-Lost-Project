using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.AccessControl;
using System;
using static System.Environment;
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

        if (playerSelectedFilePath == "")
        {
            playerSelectedFilePath = "f";
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


        playerSelectedFilePath = SpecialFolder.MyDocuments+"";
        //DirectorySecurity sec = new DirectorySecurity();
        //sec.AddAccessRule(new FileSystemAccessRule("S-1-5-32-545", FileSystemRights.FullControl, AccessControlType.Allow));
        Debug.Log(playerSelectedFilePath);
        playerSelectedFilePath = Path.GetFullPath(playerSelectedFilePath);
        Debug.Log(playerSelectedFilePath);


        Directory.CreateDirectory(playerSelectedFilePath + "/TheLostGame");
    }

    public void SendFileToPlayer(string fileName)
    {
        /*
        if (!File.Exists(playerSelectedFilePath + "/" + fileName))
        {
            File.Delete(playerSelectedFilePath + "/" + fileName);
        }
        */
        File.Delete(playerSelectedFilePath + "/" + fileName);
        File.Create(playerSelectedFilePath + "/" + fileName).Dispose();
        Debug.Log(sourceFilePath);
        Debug.Log(playerSelectedFilePath);
        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + fileName, playerSelectedFilePath + "/" + fileName, true);
    }
}
