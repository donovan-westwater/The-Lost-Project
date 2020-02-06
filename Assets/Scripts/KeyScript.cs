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

[RequireComponent(typeof(AudioSource))]
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
    public bool isEndOfLevel = false;


    public string newFileToGenerate;
    
    public bool isFirstOne = false;
    AudioSource source;

    private void Start()
    {
        jsonFileName = "Key";
        playerStartingPos = startingTransform.transform.position;
        playerStartingRot = startingTransform.transform.rotation;
        source = this.GetComponent<AudioSource>();
        DeleteJSON("WallConnected");

        ApplyChanges();

        Invoke("TelePlayer", 0.1f);

        
    }

    void TelePlayer()
    {
        if (isFirstOne)
        {
            player.SetActive(false);
            player.transform.position = startingTransform.transform.position;
            player.SetActive(true);
        }
    }

    public override void ApplyChange()
    {
        if (IExist(this))
        {
            jsonFileName = "Key";
            KeyJson obj = ReadJSON<KeyJson>(this);
            if (obj.SendToNextLevel)
            {
                DeleteJSON(jsonFileName);
                DeleteJSON("WallConnected");
                DeleteJSON("Flip");
                if (newFileToGenerate != "")
                {
                    CreateJSON(newFileToGenerate);
                }
                player.SetActive(false);
                player.transform.position = endingTransform.transform.position;
                player.SetActive(true);
                if (isEndOfLevel == true)
                {
                    DeleteJSON("WallConnected");
                    SceneManager.LoadScene("FinalLevel");
                }
            }
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
            if (IExist(glitch))
            {
                glitch.ApplyChange();
            }
        }
    }

    bool hasWon = false;

    public void CheckKeys()
    {
        if (!hasWon)
        {
            foreach (KeyScriptEcho key in keys)
            {
                if (key.wasClicked == false)
                {
                    return;
                }
            }

            source.Play();
            CreateJSON(jsonFileName);
            hasWon = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        offGraphic.SetActive(false);
        onGraphic.SetActive(true);
        ApplyChanges();
    }
}
