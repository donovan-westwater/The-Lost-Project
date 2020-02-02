using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerToPos : MonoBehaviour
{
    public GameObject newPos;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        other.gameObject.transform.position = newPos.transform.position;
        other.gameObject.SetActive(true);
    }
}
