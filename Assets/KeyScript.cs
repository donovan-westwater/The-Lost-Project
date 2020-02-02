using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class KeyScript : MonoBehaviour
{
    public GameObject player;
    public bool resetPlayer;
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
