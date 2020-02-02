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

public class SetPathThatPlayerSelected : MonoBehaviour
{
    string path;

    public void SetPath()
    {
        string path = EditorUtility.SaveFolderPanel("Save textures to folder", "", "");
        
        string path2 = path;
        if (!File.Exists(path2 + "/" + "intro" + ".txt"))
        {
            File.Delete(path2 + "/" + "intro" + ".txt");
        }
        File.Create(path2 + "/" + "intro" + ".txt").Dispose();
        File.Copy(FolderSingleton.instance.sourceFilePath + "/" + "intro" + ".txt", path2 + "/" + "intro" + ".txt", true);

        FolderSingleton.instance.playerSelectedFilePath = path2;

        SceneManager.LoadScene("Testing mechanics");

        
    }
}
