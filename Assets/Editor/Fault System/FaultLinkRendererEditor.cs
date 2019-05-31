using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FaultLinkRenderer))]
public class FaultLinkRendererEditor : Editor
{
    private const float seedFieldWidth = 50f;
    private const string randomButtonText = "Random Curve";
    private const string resetButtonText = "Reset Curve";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var linkRenderer = target as FaultLinkRenderer;

        // Custom horizontal layout group
        GUILayout.BeginHorizontal();

        // [int] field for seed
        linkRenderer.Seed = EditorGUILayout.IntField(linkRenderer.Seed, GUILayout.Width(seedFieldWidth));

        // random button
        if (GUILayout.Button(randomButtonText))
        {

        }

        // reset button
        if (GUILayout.Button(resetButtonText))
        {

        }

        GUILayout.EndHorizontal();
    }
}
