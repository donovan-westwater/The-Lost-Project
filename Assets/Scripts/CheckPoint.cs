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
    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector2(0, Mathf.Deg2Rad * spinSpeed); //Rotate the checkpoint model
        Activated = number == 0; //Activate the first checkpoint automatically
        particles.SetActive(Activated);
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.transform.position).magnitude < .75f && !Activated)
        {
            Activated = true;
            particles.SetActive(true);
        }
    }
}
