using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Security.AccessControl;
using TMPro;

[System.Serializable]
public class BoxJson
{
    public bool canCollide;
   // public string comment;
}


public class Glitch_Box : GlitchObject
{
    bool isCollidable;
    //public TextMeshProUGUI text;

    private void Start()
    {
        jsonFileName = "wall";
        CreateJSON(jsonFileName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //This is test code, remove when implemented in player
        {
            ApplyChange();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Start();
        }
    }
    //Applies changes from the file to the wall in game
    public override void ApplyChange()
    {
        BoxJson obj = ReadJSON<BoxJson>(this);
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(obj.isActive);
        this.gameObject.transform.GetChild(0).GetComponent<Collider>().enabled = obj.canCollide;
        //text.text = obj.comment;
    }
}