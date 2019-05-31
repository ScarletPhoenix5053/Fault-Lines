using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FaultWeb))]
public class FaultWebEditor : Editor
{
    private const string generateButtonText = "Generate";
    private const string clearButtonText = "Clear";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var faultWeb = target as FaultWeb;

        // Button Group
        GUILayout.BeginHorizontal();

        // Generate
        if (GUILayout.Button(generateButtonText))
        {

        }

        // Clear/Reset
        if (GUILayout.Button(clearButtonText))
        {

        }

        GUILayout.EndHorizontal();
    }
}
