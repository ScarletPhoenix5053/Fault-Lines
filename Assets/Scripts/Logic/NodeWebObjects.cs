using UnityEngine;
using System.Collections.Generic;

namespace SCARLET.NodeSystems
{
    public class NodeWeb
    {
        private List<Node> nodes = new List<Node>();
        public List<Node> Nodes { get => nodes; internal set { nodes = value; UpdateConnections(); } } 
        public int NodeCount => Nodes != null ? Nodes.Count : 0;

        private List<NodeConnection> connections;
        public List<NodeConnection> Connections
        {
            get
            {
                if (connections == null) UpdateConnections();
                return connections;
            }
            internal set
            {
                connections = value;
            }
        }
        public int ConnectionCount => Connections != null ? Connections.Count : 0;

        internal void UpdateConnections() => connections = NodeWebControl.MapConnectionsIn(this);
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
            Connected = new List<Node>();
        }
        public Node(NodeWeb parent) : this(parent, Vector3.zero) { }

        public bool IsConnetedTo(Node other) => Connected != null ? Connected.Contains(other) : false;
        public bool ConnectTo(Node other) => NodeWebControl.ConnectNodes(ref this, ref other);

        public override bool Equals(object obj)
        {
            if (!(obj is Node)) return false;
            Node other = (Node)obj;

            if (other.Position == Position) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Node a, Node b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Node a, Node b)
        {
            return !a.Equals(b);
        }
        public override string ToString()
        {
            return "Node (" 
                + Position.x.ToString("G3") + "," 
                + Position.y.ToString("G3") + "," 
                + Position.z.ToString("G3") + ")";
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

        public override bool Equals(object obj)
        {
            if (!(obj is NodeConnection)) return false;
            NodeConnection other = (NodeConnection)obj;

            if (other.A == A &&
                other.B == B)
            {
                return true;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + A.GetHashCode();
            hash = hash * 31 + B.GetHashCode();
            return hash;
        }
        public static bool operator ==(NodeConnection a, NodeConnection b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(NodeConnection a, NodeConnection b)
        {
            return !a.Equals(b);
        }
    }
}