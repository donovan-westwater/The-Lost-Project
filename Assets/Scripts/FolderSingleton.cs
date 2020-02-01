using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderSingleton : MonoBehaviour
{
    public static FolderSingleton instance;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
