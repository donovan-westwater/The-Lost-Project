using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.AccessControl;
using System;
using static System.Environment;
public static class FolderUtil
{
    [HideInInspector] public static string playerSelectedFilePath { get { return SpecialFolder.MyDocuments + "/TheLostGame"; } }

    public static string GetFullTextFromSource(string fileName)
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
    public static string GetFullTextFromPlayer(string fileName)
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

    public static void SendFileToPlayer(string fileName)
    {
        DeleteFileFromPlayer(fileName);
        File.Create(playerSelectedFilePath + "/" + fileName).Dispose();
        File.WriteAllText(playerSelectedFilePath + "/" + fileName, GetFullTextFromSource(fileName));
    }

    public static void DeleteFileFromPlayer(string fileName)
    {
        if (File.Exists(playerSelectedFilePath + "/" + fileName))
        {
            File.Delete(playerSelectedFilePath + "/" + fileName);
        }
    }

    public static bool DoesFileExistForPlayer(string fileName)
    {
        return File.Exists(playerSelectedFilePath + "/" + fileName);
    }
}
