using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCARLET.NodeSystems
{
    public static class NodeWebGenerator
    {
        public static NodeWeb GenerateWebPlane(Vector2 dimensions, int countMin, int countMax, int connectionsMin, int connectionsMax)
        {
            var count = Random.Range(countMin, countMax + 1);
            var nodeWeb = new NodeWeb();

            var startX = -(dimensions.x / 2);
            var startY = -(dimensions.y / 2);

            // Create nodes
            for (int i = 0; i < count; i++)
            {
                // Generate node
                var newNode = new Node(nodeWeb);

                // Give it a random position, within constraints of plane
                var posX = Random.Range(0, dimensions.x);
                var posY = Random.Range(0, dimensions.y);
                newNode.Position = new Vector3(startX + posX, 0, startY + posY);

                // Store in nodeweb
                nodeWeb.Nodes.Add(newNode);
            }

            // Connect nodes
            var connectionLimits = new int[count];                           
            if (connectionsMax > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    // Define and track # of connections for node i
                    connectionLimits[i] = Random.Range(connectionsMin, connectionsMax < count - 1 ? connectionsMax : count - 1);

                    // Generate needed connections
                    var connectionsToCreate = connectionLimits[i] - nodeWeb.Nodes[i].ConnectionCount;
                    if (connectionsToCreate > nodeWeb.Nodes[i].ConnectionsAvailable)
                        connectionsToCreate = nodeWeb.Nodes[i].ConnectionsAvailable;
                    for (int n = 0; n < connectionsToCreate; n++)
                    {
                        // Connect node i with a random node in its web
                        var connectionIsValid = false;
                        do
                        {
                            connectionIsValid = nodeWeb.Nodes[i].ConnectTo(nodeWeb.Nodes[Random.Range(0, nodeWeb.NodeCount)]);
                        }
                        while (!connectionIsValid);                       
                    }
                }
            }

            return nodeWeb;
        }
    }
}