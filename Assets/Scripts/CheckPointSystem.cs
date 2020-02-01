using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    public CheckPoint[] checkPoints; // Array of checkpoints

    // Get the transform of the most recent checkpoint activated
    public Vector3 GetRecetCheckPointTransform()
    {
        for (int i = checkPoints.Length - 1; i >= 1; i--)
            if (checkPoints[i].Activated)
                return checkPoints[i].gameObject.transform.position;
        return checkPoints[0].gameObject.transform.position;
    }
}
