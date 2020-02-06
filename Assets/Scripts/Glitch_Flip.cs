using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class FlipJson
{
    public bool IsEnabled;
}


public class Glitch_Flip : GlitchObject
{
    public bool isFlipped = false;

    private void Start()
    {
        jsonFileName = "Flip";
        CreateJSON(jsonFileName);
    }

    public override void ApplyChange()
    {
        jsonFileName = "Flip";
        FlipJson obj = ReadJSON<FlipJson>(this);

        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(CheckForFlip(!obj.IsEnabled));
        }
    }


    bool CheckForFlip(bool input)
    {
        if (isFlipped)
        {
            return !input;
        }
        else
        {
            return input;
        }
    }
}
