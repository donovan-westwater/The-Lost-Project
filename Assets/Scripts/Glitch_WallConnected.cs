using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class WallConnected
{
    public bool SetOneIsActive;
    public bool SetTwoIsActive;
}

public class Glitch_WallConnected : GlitchObject
{
    public bool isSetOne = false;
    public bool isFlipped = false;

    private void Start()
    {
        jsonFileName = "WallConnected";
    }

    public override void ApplyChange()
    {
        if (IExist(this))
        {
            jsonFileName = "WallConnected";
            WallConnected obj = ReadJSON<WallConnected>(this);
            if (isSetOne)
            {
                for (int i = 0; i < this.gameObject.transform.childCount; i++)
                {
                    this.gameObject.transform.GetChild(i).gameObject.SetActive(CheckForFlip(obj.SetOneIsActive));
                }
            }
            else
            {
                for (int i = 0; i < this.gameObject.transform.childCount; i++)
                {
                    this.gameObject.transform.GetChild(i).gameObject.SetActive(CheckForFlip(obj.SetTwoIsActive));
                }
            }
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
