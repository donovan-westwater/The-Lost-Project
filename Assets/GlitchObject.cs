using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GlitchObject : MonoBehaviour
{
    public string playerSelectedFilePath;
    public string jsonFileName;

    public virtual void RefreshData(string data)
    {
    }

    public virtual void ApplyChange() { }

    private void Awake()
    {
        playerSelectedFilePath = FolderSingleton.instance.playerSelectedFilePath;
    }
}
