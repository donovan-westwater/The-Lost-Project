using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CheckPointSystem checkPointSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
            Die();
    }

    private void Die()
    {
        transform.position = checkPointSystem.GetRecetCheckPointTransform();
    }
}
