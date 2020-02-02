using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyScriptEcho : MonoBehaviour
{
    public KeyScript hostScript;
    public bool wasClicked = false;
    public GameObject offGraphic;
    public GameObject onGraphic;

    private void OnTriggerEnter(Collider other)
    {
        wasClicked = true;
        offGraphic.SetActive(false);
        onGraphic.SetActive(true);
        hostScript.ApplyChanges();
        hostScript.CheckKeys();

    }
}
