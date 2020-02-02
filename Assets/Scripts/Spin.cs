using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 spinSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(Mathf.Deg2Rad * spinSpeed.x, Mathf.Deg2Rad * spinSpeed.y, Mathf.Deg2Rad * spinSpeed.z);
    }
}
