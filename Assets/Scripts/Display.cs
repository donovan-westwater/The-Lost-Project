using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public int number;
    public Player player;
    public GameObject bridge1;
    public GameObject bridge2;
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
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Text.text = (bridge1.activeSelf) ? (player.weapon == null) ? "You need a hammer to repair!" : "Press left Click to repair" : "Walk across";
        if (Input.GetMouseButton(0) && player.weapon!=null)
        {
            bridge1.SetActive(false);
            bridge2.SetActive(true);
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
