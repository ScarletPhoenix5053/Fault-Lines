using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SCARLET.NodeSystems
{
    public static class NodeWebControl
    {
        public static bool ConnectNodes(ref Node a, ref Node b)
        {
            if (a.IsConnetedTo(b) || a == b)
            {
                return false;
            }
            else
            {
                a.Connected.Add(b);
                b.Connected.Add(a);
                return true;
            }
        }
        public static List<NodeConnection> MapConnectionsIn(NodeWeb web)
        {
            var connections = new List<NodeConnection>();

            foreach (Node node in web.Nodes)
            {
                // Loop thru each node
                // Add each connection if not already in list
                foreach (Node connected in node.Connected)
                {
                    var connection = new NodeConnection(node, connected);
                    if (connections.Contains(connection)) continue;
                    else connections.Add(connection);
                }
            }

            return connections;
        }
    }
}