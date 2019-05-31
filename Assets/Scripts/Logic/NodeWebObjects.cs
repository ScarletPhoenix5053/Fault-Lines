using UnityEngine;
using System.Collections.Generic;

namespace SCARLET.NodeSystems
{
    public class NodeWeb
    {        
        [SerializeField]
        [Tooltip("Transform for storing this web's nodes")]
        private Transform nodeParent;
    }
    public struct Node
    {
        public Vector3 Position { get; internal set; }
        public List<Node> Connected { get; internal set; }
    }
}