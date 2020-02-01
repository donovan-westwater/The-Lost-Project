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
    string customFileName = "/Level1Test";

    void Start()
    {
        customFileName += ".txt";

        //Get the path of the Game data folder
        m_Path = Application.dataPath;

        string m_Path_With_String = CustomFilePath + customFileName;

        //Output the Game data path to the console
        Debug.Log("dataPath : " + m_Path);

        //File.Copy(m_Path2 + "/Pog.txt", CustomFilePath, false);
        File.WriteAllText(m_Path_With_String, "I have created txt");


        /*
        File.Create(CustomFilePath + "/SubSubFolder/folder.txt");
        File.Move(m_Path_With_String, "");
        */
        
        /*
        if (!File.Exists(m_Path_With_String))
        {
            File.WriteAllText(m_Path, "I have created txt");
        }
        */
        
        
    }
}
