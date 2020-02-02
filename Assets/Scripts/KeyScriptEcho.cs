using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyScriptEcho : MonoBehaviour
{
    public KeyScript hostScript;
    public bool wasClicked = false;
    public GameObject offGraphic;
    public GameObject onGraphic;
    public GameObject resetArea;

    private void OnTriggerEnter(Collider other)
    {
        wasClicked = true;
        offGraphic.SetActive(false);
        onGraphic.SetActive(true);
        hostScript.ApplyChanges();
        hostScript.CheckKeys();


        Invoke("ResetArea", 0.1f);
    }

    void ResetArea()
    {
        if (resetArea != null)
        {
            hostScript.player.SetActive(false);
            hostScript.player.transform.position = resetArea.transform.position;
            hostScript.player.SetActive(true);
        }
    }
}
