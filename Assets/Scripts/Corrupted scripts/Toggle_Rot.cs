using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class Spinning_Object
{
   public bool isSpinning;
}
public class Toggle_Rot : GlitchObject
{
    public bool spin = true;
    public Vector3 spindir;
    // Start is called before the first frame update
    private void Start()
    {
        jsonFileName = "Spin";
        CreateJSON(jsonFileName);
    }
    // Update is called once per frame
    void Update()
    {
        if (spin) this.transform.rotation *= Quaternion.Euler(spindir.x * Time.deltaTime, spindir.y * Time.deltaTime, spindir.z * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.F)) //This is test code, remove when implemented in player
        {
            ApplyChange();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Start();
        }
    }
    public override void ApplyChange()
    {
        Spinning_Object obj = ReadJSON<Spinning_Object>(this);
        spin = obj.isSpinning;
    }
}
