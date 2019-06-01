﻿using UnityEngine;
using System.Collections;
using SCARLET.NodeSystems;

public static class FaultLogic
{
    public static void CreateFaultLinkRenderers(Transform container, NodeWeb faultWeb, GameObject linkPrefab)
    {
        for (int i = 0; i < faultWeb.ConnectionCount; i++)
        {
            var newLink = Object.Instantiate(linkPrefab, container);
            newLink.name = "L" + i.ToString("D3") +" (" + faultWeb.Connections[i].A + ")(" + faultWeb.Connections[i].B + ")";
            newLink.GetComponent<FaultLinkRenderer>().SetNodes(faultWeb.Connections[i]);
        }
    }
    public static void CreateFaultLinePath(Node nodeA, Node nodeB, FaultLinkNoisePrefs prefs, AnimationCurve deviation, LineRenderer lineRenderer)
    {
        // Get noise sample
        var noiseSample = 
            NoiseGenerator.GeneratePerlinWave(
                prefs.SampleCount,
                prefs.Octaves,
                prefs.Scale,
                prefs.Persistence,
                prefs.Lacunarity,
                prefs.Seed);

        // Get points along line @ sample density
        var worldPositions = new Vector3[prefs.SampleCount];
        for (int i = 0; i < prefs.SampleCount; i++)
        {
            worldPositions[i] = Vector3.Lerp(nodeA.Position, nodeB.Position, Mathf.InverseLerp(0,prefs.SampleCount,i));
        }

        // Adjust points using sample & curve
        var dir = nodeB.Position - nodeA.Position;
        var rot = Quaternion.Euler(dir);

        for (int i = 0; i < prefs.SampleCount; i++)
        {
            var modifier = rot * new Vector3(noiseSample[i], 0, 0);
            worldPositions[i] += modifier;
        }

        // Apply to line renderer   
        lineRenderer.positionCount = prefs.SampleCount;
        lineRenderer.SetPositions(worldPositions);
    }
}