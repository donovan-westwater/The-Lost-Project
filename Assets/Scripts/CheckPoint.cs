using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool Activated { get; set; }
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        Activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
