using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.AccessControl;

public class SetPathThatPlayerSelected : MonoBehaviour
{
    public void SetPath()
    {
        string path3 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/LostGame";
        
        DirectoryInfo dir = Directory.CreateDirectory(path3);

        File.SetAttributes(path3, FileAttributes.Normal);


        //if (!Directory.Exists(path3))

            if (!File.Exists(path3 + "/" + "intro" + ".txt"))
        {
            File.Delete(path3 + "/" + "intro" + ".txt");
        }

        File.Create(path3 + "/" + "intro" + ".txt").Dispose();

        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + "intro" + ".txt", path3 + "/" + "intro" + ".txt", true);

        FolderSingleton.instance.playerSelectedFilePath = path3;

        SceneManager.LoadScene("Tutorial");

        
    }
}
