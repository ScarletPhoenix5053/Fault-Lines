using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCARLET.NodeSystems;

//[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]
public class FaultLinkRenderer : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private FaultLinkNoisePrefs noiseSettings;
    [SerializeField] private AnimationCurve pathDeviation;

    public int Seed { get; set; }

    private LineRenderer lineRenderer;
    private Node nodeA;
    private Node nodeB;
    
    public void SetNodes(NodeConnection connection)
    {
        nodeA = connection.A;
        nodeB = connection.B;

        if (lineRenderer == null) lineRenderer = GetComponent<LineRenderer>();
        FaultLogic.CreateFaultLinePath(nodeA, nodeB, noiseSettings, pathDeviation, lineRenderer);
    }
}