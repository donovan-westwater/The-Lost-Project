using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.AccessControl;

public class SetPathThatPlayerSelected : MonoBehaviour
{
    public void SetPath()
    {
        SceneManager.LoadScene("Level2");
    }
}
