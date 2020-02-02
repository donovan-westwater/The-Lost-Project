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
            text.txt.text = "I think I broke my game! I need you to help me repair it! Go to Documents/LostGame and view the Broken Bridge.txt document!\nBTW, that purple square is a checkpoint.";
        }
        if (messageNumber == 1)
        {
            text.txt.text = "This door leads to the first level! But it's corrupted! Go to Documents/LostGame and right click on door.json and uncorrupt the door with notepad or notepad++!!! Make sure to save! Press F in the game to refresh then Touch the door!";
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (messageNumber == 0)
            {
                FolderSingleton.instance.SendFileToPlayer("Broken Bridge.txt");
            }
            if (messageNumber == 1)
            {
                FolderSingleton.instance.SendFileToPlayer("door.json");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
