using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public CheckPointSystem checkPointSystem;
    private CharacterController con;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player falls to his death, respawn them at the nearest checkpoint
        if (transform.position.y < -20)
            Die();
    }

    // Respawn the player at the nearest checkpoint
    private void Die()
    {
        con.enabled = false;
        Vector3 checkPointTranform = checkPointSystem.GetRecetCheckPointTransform();
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(checkPointTranform.x,checkPointTranform.y += 2f,checkPointTranform.z);
        con.enabled = true;
    }
}
