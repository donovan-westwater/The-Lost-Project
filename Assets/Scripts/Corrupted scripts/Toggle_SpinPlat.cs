using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
[Serializable]
public class SpinningPlatform
{
    public bool isMoving;
    public bool isSpinning;
}
public class Toggle_SpinPlat : GlitchObject
{
    public bool spin = true;
    public bool move = true;
    bool reverse = false;
    public float travelDist = 50f;
    float currentDis = 0;
    Vector3 startingDir;
    // Start is called before the first frame update
    private void Start()
    {
        jsonFileName = "SpinAndMove";
        startingDir = this.transform.forward;
        CreateJSON(jsonFileName);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("IM RUNNING");
        if (spin) this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), 75f * Time.deltaTime);
        if (move)
        {
            if (!reverse)
            {
                if (currentDis > travelDist) reverse = true;
                this.transform.position += 10 * startingDir * Time.deltaTime;
                currentDis +=10 * this.startingDir.magnitude * Time.deltaTime;
            }
            else if (reverse)
            {
                if (currentDis < 0) reverse = false;
                this.transform.position -= 10 * startingDir * Time.deltaTime;
                currentDis -= 10 * startingDir.magnitude * Time.deltaTime;
            }

        }
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
        SpinningPlatform obj = ReadJSON<SpinningPlatform>(this);
        move = obj.isMoving;
        spin = obj.isSpinning;
    }
}