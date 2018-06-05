using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AStar
{ 
    public class AStarNode
    {
        public Point Point;
         
        /// <summary>
        /// 起点到该点的距离;
        /// </summary>
        public int G;
        /// <summary>
        /// 启发函数预测的次点到终点的距离;
        /// </summary>
        public int H;

        public int F
        {
            get
            {
                return G+H;
            } 
        }

        /// <summary>
        /// 父节点;
        /// </summary>
        public AStarNode ParentNode;

        /// <summary>
        /// 邻居节点;
        /// </summary>
        private List<AStarNode> neigrsAStarNodes = new List<AStarNode>();
        public List<AStarNode> NeigrsAStarNodes
        {
            get
            {
                neigrsAStarNodes.Clear();
                neigrsAStarNodes.Add(new AStarNode(Point.X-1,Point.Y));
                neigrsAStarNodes.Add(new AStarNode(Point.X-1,Point.Y-1));
                neigrsAStarNodes.Add(new AStarNode(Point.X-1,Point.Y+1));
                neigrsAStarNodes.Add(new AStarNode(Point.X+1,Point.Y));
                neigrsAStarNodes.Add(new AStarNode(Point.X+1,Point.Y-1));
                neigrsAStarNodes.Add(new AStarNode(Point.X+1,Point.Y+1));
                neigrsAStarNodes.Add(new AStarNode(Point.X,Point.Y-1));
                neigrsAStarNodes.Add(new AStarNode(Point.X,Point.Y+1));
                return neigrsAStarNodes;
            }
        }

        public bool EqualOther(AStarNode node)
        {
            if (node == null) return false;
            return Point==node.Point;
        }
         
        public int GetH(AStarNode target)
        {
            int a = Math.Abs(Point.X - target.Point.X);
            int b = Math.Abs(Point.Y - target.Point.Y);
            return 10 * (int)Math.Sqrt(a*a +b*b);
        }

        public int GetG(AStarNode target)
        {
            if (target.ParentNode.EqualOther(null))
                return 0;

            if (target.Point==Point)
            {
                return 0;
            }
            // 和自己同行或者同列,返回10;
            if (target.Point.X==Point.X||target.Point.Y==Point.Y)
            {
                return 10;
            }
            // 在自己的四个拐角就返回14;
            return 14;
        }

        public AStarNode(Point point)
        {
            this.Point = point;
        }

        public AStarNode(int x,int y)
        {
            this.Point = new Point(x,y);
        }
    }
}