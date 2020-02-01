using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using UnityEditor;

public class SetPathThatPlayerSelected : MonoBehaviour
{
    string path;

    public void SetPath()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with png", "", "");

        File.Create(Path.GetFullPath(path)).Dispose();
        Debug.Log(Path.GetDirectoryName(path));
        string path2 = Path.GetDirectoryName(path);
        File.Delete(path);
        if (!File.Exists(path2 + "/" + "intro" + ".txt"))
        {
            File.Delete(path2 + "/" + "intro" + ".txt");
        }
        File.Create(path2 + "/" + "intro" + ".txt").Dispose();
        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + "intro" + ".txt", path2 + "/" + "intro" + ".txt", true);

        FolderSingleton.instance.playerSelectedFilePath = path2;
    }
}
