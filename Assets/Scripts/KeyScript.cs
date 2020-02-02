using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System;
using System.IO;
using System.Security.AccessControl;
using UnityEngine.SceneManagement;


[System.Serializable]
public class KeyJson
{
    public bool SendToNextLevel;
}

public class KeyScript : GlitchObject
{
    public GameObject player;
    Vector3 playerStartingPos;
    Quaternion playerStartingRot;
    public GlitchObject[] glitches;
    public KeyScriptEcho[] keys;
    public GameObject offGraphic;
    public GameObject onGraphic;
    public GameObject startingTransform;
    public GameObject endingTransform;
    bool isEndOfLevel = false;

    public string newFileToGenerate;

    bool SendToNextLevel = false;

    private void Start()
    {
        jsonFileName = "Key";
        playerStartingPos = startingTransform.transform.position;
        playerStartingRot = startingTransform.transform.rotation;

        ApplyChanges();
    }

    public override void ApplyChange()
    {
        jsonFileName = "Key";
        if (File.Exists(playerSelectedFilePath + "/" + jsonFileName + ".json"))
        {
            string filepath = playerSelectedFilePath + "/" + jsonFileName + ".json";
            string jsontext = System.IO.File.ReadAllText(filepath);

            KeyJson obj = readJSON(jsontext);
            if (obj.SendToNextLevel)
            {
                File.Delete(playerSelectedFilePath + "/" + jsonFileName + ".json");
                File.Delete(playerSelectedFilePath + "/" + "WallConnected" + ".json");
                File.Delete(playerSelectedFilePath + "/" + "Flip" + ".json");
                player.SetActive(false);
                if (newFileToGenerate != "")
                {
                    FolderSingleton.instance.SendFileToPlayer(newFileToGenerate + ".json");
                }
                player.transform.position = endingTransform.transform.position;
                player.SetActive(true);
                if (isEndOfLevel == true)
                {
                    SceneManager.LoadScene("FinalLevel");
                }
            }
        }
    }

    public KeyJson readJSON(string jsontext)
    {
        try
        {
            return JsonUtility.FromJson<KeyJson>(jsontext);
        }
        catch (Exception)
        {
            Debug.Log("INVALID JSON RESETING");

            if (!File.Exists(playerSelectedFilePath + "/" + jsonFileName + ".json"))
            {
                File.Delete(playerSelectedFilePath + "/" + jsonFileName + ".json");
            }
            File.Create(playerSelectedFilePath + "/" + jsonFileName + ".json").Dispose();
            File.Copy(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json", playerSelectedFilePath + "/" + jsonFileName + ".json", true);
            return JsonUtility.FromJson<KeyJson>(System.IO.File.ReadAllText(FolderSingleton.instance.sourceFilePath + "/" + jsonFileName + ".json"));
        }
    }




    public void ApplyChanges()
    {
        player.gameObject.SetActive(false);
        player.transform.position = playerStartingPos;
        player.transform.rotation = playerStartingRot;
        player.gameObject.SetActive(true);

        foreach (GlitchObject glitch in glitches)
        {
            glitch.ApplyChange();
        }
    }

    public void CheckKeys()
    {
        foreach (KeyScriptEcho key in keys)
        {
            if (key.wasClicked == false)
            {
                return;
            }
        }

        CreateJSON(jsonFileName);
    }

    private void OnTriggerEnter(Collider other)
    {
        offGraphic.SetActive(false);
        onGraphic.SetActive(true);
        ApplyChanges();
    }
}
