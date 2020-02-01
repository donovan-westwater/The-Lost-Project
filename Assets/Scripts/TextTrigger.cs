using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    GameObject Player;
    public Image img;
    public Text txt;
    bool popupmode = false;
    public float triggerRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //this.GetComponent<Image>().enabled = false;
        img.enabled = false;
        txt.enabled = false;
       // this.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.eulerAngles += new Vector3(0, Time.deltaTime * 5f, 0);
        if(Vector3.Distance(Player.transform.position,this.transform.position) < triggerRadius && !popupmode)
        {
            popupmode = true;
            PopUpToggle(true);
        }
        else if (popupmode && Input.GetKeyDown(KeyCode.E))
        {
            PopUpToggle(false);
            
        }
        else if(Vector3.Distance(Player.transform.position, this.transform.position) > triggerRadius)
        {
            popupmode = false;
            PopUpToggle(false);
        }
        
    }
    void PopUpToggle(bool b)
    {
        //popupmode = b;
        img.enabled = b;
        txt.enabled = b;
    }

}
