using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCARLET.NodeSystems;

public class FaultWeb : MonoBehaviour
{
    #region Inspector
    [Header("Connections")]
    [SerializeField] private Transform connectionContainer;
    [Header("Node Field Generation")]
    [SerializeField] private int nodeCountMin = 7;
    [SerializeField] private int nodeCountMax = 7;
    [SerializeField] private int nodeConnectionsMin = 2;
    [SerializeField] private int nodeConnectionsMax = 4;

    private const int minimumNodes = 3;
    private const int minimumConnections = 2;

    private void OnValidate()
    {
        // Min vals never exceeed max vals
        if (nodeCountMin > nodeCountMax) nodeCountMin = nodeCountMax;
        if (nodeConnectionsMin > nodeConnectionsMax) nodeConnectionsMin = nodeConnectionsMax;

        // Max vals never fall below min vals
        if (nodeCountMax < nodeCountMin) nodeCountMax = nodeCountMin;
        if (nodeConnectionsMax < nodeConnectionsMin) nodeConnectionsMax = nodeConnectionsMin;

        // Node count is never below absolute minimum
        if (nodeCountMin < minimumNodes) nodeCountMin = minimumNodes;
        if (nodeCountMax < minimumNodes) nodeCountMax = minimumNodes;

        // Connection count is never below absolute minimum
        if (nodeConnectionsMin < minimumConnections) nodeConnectionsMin = minimumConnections;
        if (nodeConnectionsMax < minimumConnections) nodeConnectionsMax = minimumConnections;

        // Connection count is never greater than number of possible connections
        if (nodeConnectionsMax > nodeCountMax - 1) nodeConnectionsMax = nodeCountMax - 1;
    }
    #endregion

    #region Gizmos
    private const float nodeRaidus = 0.2f;

    private void OnDrawGizmos()
    {
        if (faultNodes != null)
        {
            // Draw gizmos for nodes
            if (faultNodes.NodeCount > 0)
            {
                foreach (Node node in faultNodes.Nodes)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(node.Position, nodeRaidus);
                }
            }

            // Draw gizmos for connections
            if (faultNodes.ConnectionCount > 0)
            {
                foreach (NodeConnection connection in faultNodes.Connections)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawLine(connection.A.Position, connection.B.Position);
                }
            }
        }
    }
    #endregion

    #region Variables
    private const float planeSize = 10;

    private NodeWeb faultNodes;
    #endregion

    #region Methods
    public void GenerateFaultWeb()
    {
        faultNodes =
            NodeWebGenerator.GenerateWebPlane(
                new Vector2(
                    transform.localScale.x * planeSize,
                    transform.localScale.z * planeSize
                    ),
                nodeCountMin, nodeCountMax,
                nodeConnectionsMin, nodeConnectionsMax);
    }
    public void ClearFaultWeb() => faultNodes = null;
    #endregion
}
