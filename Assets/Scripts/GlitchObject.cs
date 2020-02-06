using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public abstract class GlitchObject : MonoBehaviour
{
    [HideInInspector]
    public string jsonFileName;

    public virtual void ApplyChange() { }

    public static void CreateJSON(string jsonName)
    {
        FolderUtil.SendFileToPlayer(jsonName + ".json");
    }

    public static void DeleteJSON(string jsonName)
    {
        FolderUtil.DeleteFileFromPlayer(jsonName + ".json");
    }

    public static bool IExist(GlitchObject gObject)
    {
        return FolderUtil.DoesFileExistForPlayer(gObject.jsonFileName + ".json");
    }

    public static T ReadJSON<T>(GlitchObject gObject)
    {
        try
        {
            return JsonUtility.FromJson<T>(FolderUtil.GetFullTextFromPlayer(gObject.jsonFileName));
        }
        catch (Exception)
        {
            Debug.Log("INVALID JSON RESETING");
            CreateJSON(gObject.jsonFileName);

            return JsonUtility.FromJson<T>(FolderUtil.GetFullTextFromSource(gObject.jsonFileName));
        }
    }
}
