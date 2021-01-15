using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class Test : EditorWindow
{
    [MenuItem("PlayField/Test")]
    public static void ShowWindow()
    {
        GetWindow<Test>("Test");
    }

    private void OnGUI()
    {
        
    }
}
