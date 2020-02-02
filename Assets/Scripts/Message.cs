using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    private TextTrigger text;
    public int messageNumber;
    public GameObject corruptDoor;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextTrigger>();
        if (messageNumber == 0)
        {
            text.txt.text = "Dev note 12: I think I broke my game! I can't get my bridge to appear! Go to " + FolderSingleton.instance.playerSelectedFilePath + "and view the invisible bridge.txt document!\nBTW, that purple square is a checkpoint.";
            FolderSingleton.instance.SendFileToPlayer("Invisible Bridge.txt");
        }
        if (messageNumber == 1)
        {
            text.txt.text = "Dev note 35: This door leads to the first level! But it's corrupted! Go to" + FolderSingleton.instance.playerSelectedFilePath + " and right click on door.json and uncorrupt the door with notepad or notepad++!!! Make sure to save! Press F in the game to refresh then Touch the door!";
            FolderSingleton.instance.SendFileToPlayer("door.json");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
