using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    private Text text;
    public int messageNumber;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        if (messageNumber == 0)
        {
            text.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
