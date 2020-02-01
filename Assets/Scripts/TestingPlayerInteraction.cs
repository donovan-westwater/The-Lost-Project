using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.AccessControl;

public class TestingPlayerInteraction : MonoBehaviour
{
    /*
     * The plan is to have the player type in their directory in the beginning of the game and then reference that directory for the rest of the game this current test CustomFilePath is just for us to test before we implement the player text input field
     * */
    string m_Path;
    string CustomFilePath = "D:/Profiles/student/LostGame/Yes";
    string sourcePath;

    void Start()
    {
        //Get the path of the Game data folder
        m_Path = Application.dataPath;
        sourcePath = m_Path + "/Source";
        CopyFileToDir("Intro.txt", true);
        CreateFileInDir("ThereIsNoEnd.txt", true);
    }


    /// <summary>
    /// Copies a file from the source folder to the folder that the player can access 
    /// </summary>
    /// <param name="sourceFile">The name of the file being copied. WARNING THIS MUST INCLUDE THE ENDING EX: .txt</param>
    /// <param name="overWrite">When true this will overwrite the file if it is already present.  When this is false if the file is present it will not write the file to the folder</param>
    /// <returns></returns>
    public void CopyFileToDir(string sourceFile, bool overWrite)
    {
        if (!overWrite)
        {
            File.Copy(sourcePath + "/" + sourceFile, CustomFilePath + "/" + sourceFile, true);
        }
        else
        {
            if (!File.Exists(CustomFilePath + "/" + sourceFile))
            {
                File.Copy(sourcePath + "/" + sourceFile, CustomFilePath + "/" + sourceFile, true);

            }
        }
    }
    /// <summary>
    /// Creates a new file that the player can access
    /// </summary>
    /// <param name="FileName">The name of the file being created. WARNING THIS MUST INCLUDE THE ENDING EX: .txt</param>
    /// <param name="overWrite">When true this will overwrite the file if it is already present.  When this is false if the file is present it will not write the file to the folder</param>
    /// <returns></returns>
    public void CreateFileInDir(string FileName, bool overWrite)
    {
        if (!overWrite)
        {
            if (!File.Exists(CustomFilePath + "/" + FileName))
            {
                File.Create(CustomFilePath + "/" + FileName);
            }
        }
        else
        {
            if (!File.Exists(CustomFilePath + "/" + FileName))
            {
                File.Create(CustomFilePath + "/" + FileName);
            }
            else
            {
                File.Delete(sourcePath + "/" + FileName);
                File.Create(CustomFilePath + "/" + FileName);
            }
        }
    }

}
