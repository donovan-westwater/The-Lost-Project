using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GlitchObject : MonoBehaviour
{
    [HideInInspector]
    public string playerSelectedFilePath;
    [HideInInspector]
    public string jsonFileName;

    public virtual void ApplyChange() { }

    private void Awake()
    {
        playerSelectedFilePath = FolderSingleton.instance.playerSelectedFilePath;
    }
}
