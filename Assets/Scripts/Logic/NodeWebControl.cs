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
    }
}