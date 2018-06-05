using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS
{
    public class DFS
    { 
        public static int NODE_BLOCK = 3;
        public static int NODE_START = 1;
        public static int NODE_End = 2;

        private static Node[,] map;
        private static int mapLengh;
        private static int mapWidth;
        
        public static void InitMap(int[,] _map)
        {
            mapLengh = _map.GetLength(0);
            mapWidth = _map.GetLength(1);
            map = new Node[mapLengh,mapWidth];
            for (int i = 0; i < mapLengh; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    map[i,j] = new Node(i, j, _map[i, j]);
                }
            }
            
        }
        
        /// <summary>
        /// DFS深度搜索算法；
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="target"></param>
        /// <param name="passNodeList"></param>
        public static void Search(Node origin,Node target, ref List<Node> passNodeList)
        { 
            int startX = origin.X;
            int startY = origin.Y;
            for (int i = 0; i < mapLengh; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (!map[i,j].bVisit)
                    {
                        DFSSearch(i,j,origin,target); 
                    }
                }
            }


            // 这里是保存最短路径；
            Node curentNode = map[target.X, target.Y]; 
            while (curentNode.Value!=origin.Value)
            {
                passNodeList.Add(curentNode);
                curentNode = curentNode.parent;
            }
            passNodeList.Add(origin);
        }
        
        /// <summary>
        /// 深度遍历当前节点；
        /// </summary>
        /// <param name="i">当前节点的X坐标</param>
        /// <param name="j">当前节点的Y坐标</param>
        /// <param name="origin">开始节点</param>
        /// <param name="target">目标节点</param>
        private static void DFSSearch(int i,int j,Node origin,Node target)
        { 
            map[i,j].bVisit = true;

            //获取邻居节点;
            List<Node> neighbors = getNeighbor(map[i,j]);
            for (int k = 0; k < neighbors.Count; k++)
            {
                int x =neighbors[k].X;
                int y =neighbors[k].Y;
                if (!map[x,y].bVisit&&map[x,y].Value!=NODE_BLOCK)
                {
                    //递归深度遍历；
                    
                    //先设置标志位为已访问；
                    map[x,y].bVisit = true;
                    map[x,y].parent = map[i, j];
                    DFSSearch(x, y, origin, target);  
                }
            }
        }
        
        // 获取邻居节点;
        private static List<Node> getNeighbor(Node currentNode)
        {
            List<Node> nodes = new List<Node>();
            int x = currentNode.X;
            int y = currentNode.Y;
            if (x-1>=0&&x-1<mapLengh)
            {
                nodes.Add(map[x-1,y]);
            }

            if (x+1>=0&&x+1<mapLengh)
            {
                nodes.Add(map[x+1,y]);
            }

            if (y-1>=0&&y-1<mapLengh)
            {
                nodes.Add(map[x,y-1]); 
            }
            
            if (y+1>=0&&y+1<mapWidth)
            {
                nodes.Add(map[x,y+1]); 
            }
            return nodes;
        }
        
        private static void PrintMapData()
        {
            Console.WriteLine("---------------------");

            int mapLength = map.GetLength(0);
            int mapWidth = map.GetLength(1);
            for (int i = 0; i < mapLength; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (map[i, j].bVisit)
                    {
                        Console.Write(8 + ", ");

                    }
                    else
                    {
                        Console.Write(map[i,j].Value + ", ");

                    }
                }
                Console.WriteLine();
            }
        }
    }
}