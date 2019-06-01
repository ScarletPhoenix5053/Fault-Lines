using UnityEngine;
using System.Collections.Generic;

namespace SCARLET.NodeSystems
{
    public class NodeWeb
    {
        public List<Node> Nodes { get; internal set; } = new List<Node>();
        public int NodeCount => Nodes != null ? Nodes.Count : 0;

        public List<NodeConnection> Connections { get; internal set; }        
    }

    public struct Node
    {
        public Vector3 Position { get; internal set; }

        public List<Node> Connected { get; internal set; }
        public int ConnectionCount => Connected != null ? Connected.Count : 0;
        public int ConnectionsPossible => web.NodeCount - 1;
        public int ConnectionsAvailable => ConnectionsPossible - ConnectionCount;

        private readonly NodeWeb web;
        
        public Node(NodeWeb web, Vector3 position)
        {
            this.web = web;
            Position = position;
            Connected = null;
        }
        public Node(NodeWeb parent) : this(parent, Vector3.zero) { }

        public bool IsConnetedTo(Node other) => Connected.Contains(other);
        public bool ConnectTo(Node other) => NodeWebControl.ConnectNodes(ref this, ref other);

        public static bool operator ==(Node a, Node b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Node a, Node b)
        {
            return !a.Equals(b);
        }

    }

    public struct NodeConnection
    {
        public readonly Node A;
        public readonly Node B;

        public NodeConnection(Node a, Node b)
        {
            A = a;
            B = b;
        }
    }
}