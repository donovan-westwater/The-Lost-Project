using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public abstract class GlitchObject : MonoBehaviour
{
    [HideInInspector]
    public string playerSelectedFilePath;
    [HideInInspector]
    public string jsonFileName;

    public virtual void ApplyChange() { }

    private void Awake()
    {
        playerSelectedFilePath = FolderSingleton.INSTANCE.playerSelectedFilePath;
    }

    public static void CreateJSON(string jsonName)
    {
        FolderSingleton.INSTANCE.SendFileToPlayer(jsonName + ".json");
    }

    public static void DeleteJSON(string jsonName)
    {
        FolderSingleton.INSTANCE.DeleteFileFromPlayer(jsonName + ".json");
    }

    public static bool IExist(GlitchObject gObject)
    {
        return FolderSingleton.INSTANCE.DoesFileExistForPlayer(gObject.jsonFileName + ".json");
    }

    public static T ReadJSON<T>(GlitchObject gObject)
    {
        try
        {
            return JsonUtility.FromJson<T>(FolderSingleton.INSTANCE.GetFullTextFromPlayer(gObject.jsonFileName));
        }
        catch (Exception)
        {
            Debug.Log("INVALID JSON RESETING");
            CreateJSON(gObject.jsonFileName);

            return JsonUtility.FromJson<T>(FolderSingleton.INSTANCE.GetFullTextFromSource(gObject.jsonFileName));
        }
    }
}
