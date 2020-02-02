using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[System.Serializable]
public class PlayerJson
{
    public int jumpHeight;
    public int walkSpeed;
    public int runSpeed;
    public int gravityMultiplier;
}

[RequireComponent(typeof(FirstPersonController))]
public class Glitch_Player : MonoBehaviour
{
    public FirstPersonController playerController2;
    private void Start()
    {

    }
}
