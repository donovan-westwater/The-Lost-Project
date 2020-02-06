using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class JCorruptDoor
{
    public bool isCorrupt;
}


public class CorruptDoor : GlitchObject
{
    private void Start()
    {
        jsonFileName = "door";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ApplyChange();
        }
    }

    public override void ApplyChange()
    {
        JCorruptDoor obj = ReadJSON<JCorruptDoor>(this);
        print(obj.isCorrupt);
        gameObject.SetActive(obj.isCorrupt);
    }
}
