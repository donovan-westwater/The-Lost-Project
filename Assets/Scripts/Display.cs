using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public int number;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Text.gameObject.SetActive(true);
            if (number==0)
            {
                Text.text = (player.weapon == null) ? "You need a hammer to repair!" : "Press left Click to repair";
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButton(1) && player.weapon!=null)
        {
            print("repaired");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Text.gameObject.SetActive(false);
        }
    }
}
