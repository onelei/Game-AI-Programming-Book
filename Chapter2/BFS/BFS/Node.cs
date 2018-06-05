using System;
using System.Collections.Generic;

namespace BFS
{
    public class Node
    {
        public int X;
        public int Y;
        public int Value;
        
        public bool bVisit;
        public Node parent;
 
        public Node(int x,int y,int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.parent = null;
            this.bVisit = false;
        }

        public bool EqualsOther(Node node)
        {
            if (node == null) return false;
            return X==node.X&&Y==node.Y;
        }
         
    }
}