using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Rigidbody rb;
    public float spinSpeed;
    public bool Activated { get; set; } // Determines if checkpoint is activated
    public int number; // Determines which number checkpoint this is
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector2(0, Mathf.Deg2Rad * spinSpeed); //Rotate the 
        Activated = number == 1; //Activate the first checkpoint automatically
    }

    // Update is called once per frame
    void Update()
    {

    }
}
