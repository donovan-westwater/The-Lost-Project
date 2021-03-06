﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject player;
    Vector3 playerStartingPos;
    Quaternion playerStartingRot;
    public GlitchObject[] glitches;

    private void Start()
    {
        playerStartingPos = player.transform.position;
        playerStartingRot = player.transform.rotation;

        OnTriggerEnter(this.GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
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
}
