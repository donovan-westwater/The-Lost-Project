using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateDir : MonoBehaviour
{
    private void Awake()
    {
        if (!Directory.Exists(FolderSingleton.playerSelectedFilePath))
            Directory.CreateDirectory(FolderSingleton.playerSelectedFilePath);
    }
}
