using UnityEditor;
using System.Collections;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(DialogWindow))]
public class DataManager : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DataManager dataManager = (DataManager)target;

        //dataManager.lol = EditorGUILayout.IntField("lol", dataManager.lol);
    }
}
