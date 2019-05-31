using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaultWeb : MonoBehaviour
{
    [Header("Node Field Generation")]
    [SerializeField] private int nodeCountMin = 7;
    [SerializeField] private int nodeCountMax = 7;
    [SerializeField] [Range(0, 1)] private float nodeDensityMin = 0.5f;
    [SerializeField] [Range(0, 1)] private float nodeDensityMax = 0.5f;

    private void OnValidate()
    {
        // Min vals never exceeed max vals
        if (nodeCountMin > nodeCountMax) nodeCountMin = nodeCountMax;
        if (nodeDensityMin > nodeDensityMax) nodeDensityMin = nodeDensityMax;

        // Max vals never fall below min vals
        if (nodeCountMax < nodeCountMin) nodeCountMax = nodeCountMin;
        if (nodeDensityMax < nodeDensityMin) nodeDensityMax = nodeDensityMin;

        // Node count is never negative
        if (nodeCountMin < 0) nodeCountMin = 0;
        if (nodeCountMax < 0) nodeCountMax = 0;
    }
}
