using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
[Serializable]
public class MovingPlatform
{
    public bool isMoving;
}
public class Toggle_Platform : GlitchObject
{
    public Vector3 dir;
    public bool move = true;
    bool reverse = false;
    public float travelDist = 50f;
    float currentDis = 0;
    // Start is called before the first frame update
    private void Start()
    {
        jsonFileName = "MovingPlatform";
        CreateJSON(jsonFileName);
    }
    // Update is called once per frame
    void Update()
    {
       //Debug.Log("IM RUNNING");
        if (move) {
            if(!reverse)
            {
                if (currentDis > travelDist) reverse = true;
                this.transform.position += 5 * dir.normalized * Time.deltaTime;
                currentDis += 5 * dir.normalized.magnitude * Time.deltaTime;
            }
            else if(reverse)
            {
                if (currentDis < 0) reverse = false;
                this.transform.position -= 5 * dir.normalized * Time.deltaTime;
                currentDis -= 5 * dir.normalized.magnitude * Time.deltaTime;
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
        MovingPlatform obj = ReadJSON<MovingPlatform>(this);
        move = obj.isMoving;
    }
}
