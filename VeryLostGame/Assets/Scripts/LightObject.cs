using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    private Rigidbody rb;
    public float spinSpeed;
    public bool flickerRotation; // Will flicker the rotation if set to true

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector2(0, Mathf.Deg2Rad * spinSpeed); //Rotate the light
        if (flickerRotation)
            StartCoroutine(Flicker());
    }

    // Flicker the rotation
    IEnumerator Flicker()
    {
        while (true) {
            transform.eulerAngles = new Vector3(0, Random.Range(0, 360), transform.eulerAngles.z);
            yield return new WaitForSeconds(Random.Range(2,7));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
