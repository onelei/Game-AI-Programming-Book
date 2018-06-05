using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AStar
{
    public class AStar
    {
        public static int START_NODE = 1;
        public static int END_NODE = 2;
        public static int BARRIER = 3;

        /// <summary>
        /// 打开列表；
        /// </summary>
        public static List<AStarNode> OpenNodes = new List<AStarNode>();

        /// <summary>
        /// 关闭列表；
        /// </summary>
        public static List<AStarNode> CloseNodes = new List<AStarNode>();

        private static int[,] map;
        private static int mapLenght;
        private static int mapWith;

        /// <summary>
        /// 初始化地图数据；
        /// </summary>
        public static void InitMap(int[,] map1)
        {
            mapLenght = map1.GetLength(0);
            mapWith = map1.GetLength(1);

            map = map1;

        }

        /// <summary>
        /// 开始寻路；
        /// </summary>
        /// <param name="originNode"></param>
        /// <param name="targetNode"></param>
        /// <param name="passNodes"></param>
        /// <returns></returns>
        public static bool FindPath(AStarNode originNode, AStarNode targetNode, ref List<AStarNode> passNodes)
        {
            passNodes.Clear();

            if (originNode.EqualOther(targetNode))
            {
                passNodes.Add(originNode);
                return true;
            }

            // 清楚打开和关闭列表；
            OpenNodes.Clear();
            CloseNodes.Clear();

            originNode.G = 0;
            originNode.H = originNode.GetH(targetNode);
            originNode.ParentNode = null;

            OpenNodes.Add(originNode);

            AStarNode currenNode = null;

            while (OpenNodes.Count>0)
            {
                // 找出open表里面最小的F;
                currenNode = GetMinF(OpenNodes);
                if (currenNode.EqualOther(null))
                {
                    return false;
                }

                // 判断当前的节点是不是目标点,是的话就找到了路径;
                if (currenNode.EqualOther(targetNode))
                {
                    while (!currenNode.EqualOther(originNode))
                    {
                        passNodes.Add(currenNode);
                        currenNode = currenNode.ParentNode;
                    }
                    passNodes.Add(originNode);
                    passNodes.Reverse();
                    OpenNodes.Clear();
                    CloseNodes.Clear(); 
                    return true;
                }

                // 没有找到就移除Open列表里面;
                OpenNodes.Remove(currenNode);
                CloseNodes.Add(currenNode);

                // 判断邻居节点;
                Check8(currenNode, targetNode);

                //PrintLog();

            }

            passNodes.Clear();
            OpenNodes.Clear();
            CloseNodes.Clear();
            return false;
        }

        private static void Check8(AStarNode currentNode, AStarNode targetNode)
        {
            List<AStarNode> neigrNodes = currentNode.NeigrsAStarNodes;

            for (int i = 0; i < neigrNodes.Count; i++)
            {
                // 排除边界点;
                int x = neigrNodes[i].Point.X;
                int y = neigrNodes[i].Point.Y;
                if (x >= 0 && x < 10 && y >= 0 && y < 10)
                {
                    // 排除障碍物和关闭列表中的点;
                    if (map[x, y] != BARRIER && !InNodeList(neigrNodes[i],CloseNodes))
                    {
                        // 在Open表格里面;
                        if (InNodeList(neigrNodes[i],OpenNodes))
                        {
                           var _node = OpenNodes.FirstOrDefault(c => c.Point==neigrNodes[i].Point);
                            //判断和邻居自检的G
                            int newG = currentNode.GetG(_node) + currentNode.G;
                            if (newG < _node.G)
                            {
                                _node.ParentNode = currentNode;
                                _node.G = newG;
                            }
                        }
                        else
                        {
                            //不在Open表格里面;
                            neigrNodes[i].ParentNode = currentNode;
                            int newG = currentNode.GetG(neigrNodes[i]) + currentNode.G;
                            neigrNodes[i].G = newG;
                            neigrNodes[i].H = neigrNodes[i].GetH(targetNode);
                            OpenNodes.Add(neigrNodes[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  // 找出open表里面最小的F;
        /// </summary>
        /// <returns></returns>
        private static AStarNode GetMinF(List<AStarNode> OpenNodes)
        {
            AStarNode result = null;
            int fValue = int.MaxValue;
            for (int i = 0; i < OpenNodes.Count; i++)
            {
                if (OpenNodes[i].F < fValue)
                {
                    fValue = OpenNodes[i].F;
                    result = OpenNodes[i];
                }
            }
            return result;
        }

        private static bool InNodeList(AStarNode node,List<AStarNode> Nodes)
        {
            return Nodes.FirstOrDefault(c => c.Point==node.Point) != null;
        }

        private static void PrintLog()
        {
            for (int iter = 0; iter < 10; iter++)
            {
                for (int index = 0; index < 10; index++)
                {
                    bool Ohave = false;
                    bool Chave = false;
                    for (int i = 0; i < OpenNodes.Count; i++)
                    {
                        if (OpenNodes[i].Point.X == index && OpenNodes[i].Point.Y == iter)
                        {
                            Console.Write("O");
                            Ohave = true;
                        }
                    }
                    for (int i = 0; i < CloseNodes.Count; i++)
                    {
                        if (CloseNodes[i].Point.X == index && CloseNodes[i].Point.Y == iter)
                        {
                            Console.Write("C");
                            Chave = true;
                        }
                    }
                    if (!Ohave)
                    {
                        Console.Write(" ");
                    }
                    if (!Chave)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
                
            Console.WriteLine("=================================");
        }
    }
}