using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class FaultLinkRenderer : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private FaultLinkNoisePrefs noiseSettings;
    [SerializeField] private AnimationCurve pathDeviation;

    public int Seed { get; set; }

    private LineRenderer lineRenderer;

    private void Reset()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
}