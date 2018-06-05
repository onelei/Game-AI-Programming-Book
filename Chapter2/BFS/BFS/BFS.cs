using System;
using System.Collections.Generic;
using System.Threading;

namespace BFS
{
    public class BFS
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
        /// BFS算法；
        /// </summary>
        /// <param name="origin">开始节点</param>
        /// <param name="target">目标点</param>
        /// <param name="passNodeList">最短路径列表</param>
        public static void Search(Node origin, Node target,ref List<Node> passNodeList)
        {
            passNodeList.Clear(); 
 
            for (int i = 1; i < mapLengh; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    //如果没有访问该节点，就访问它；
                    if (!map[i,j].bVisit)
                    {
                        BFSSearch(map[i,j],origin,target,ref passNodeList); 
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
        /// 根据当前节点，检查自己的邻居节点；
        /// </summary>
        /// <param name="currentNode">当前节点</param>
        /// <param name="origiNode">原始节点</param>
        /// <param name="target">目标节点</param>
        /// <param name="passNodeList">最短路径列表</param>
        private static void BFSSearch(Node currentNode,Node origiNode,Node target,ref List<Node> passNodeList)
        {
            //将当前节点加入队列中；
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(currentNode);

            while (queue.Count>0)
            {
                Node head = queue.Dequeue();  
                // 检查四个邻居(上下左右);
                List<Node> neighbors = getNeighbor(head);
                for (int i = 0; i < neighbors.Count; i++)
                { 
                    // 没有访问并且可以访问；
                    if (!neighbors[i].bVisit&&neighbors[i].Value!= NODE_BLOCK)
                    {
                        //标记节点为已经访问；
                        neighbors[i].bVisit = true;
                        neighbors[i].parent = head;
                        queue.Enqueue(neighbors[i]);
                        
                        //记录中间的路径节点；
                        if (neighbors[i].Value == target.Value)
                        { 
                            return;
                        }
                        
                    }
                }
                 
            }
        }

        // 获取邻居节点;
        private static List<Node> getNeighbor(Node currentNode)
        {
            List<Node> nodes = new List<Node>();
            int x = currentNode.X;
            int y = currentNode.Y;
            if (x-1>=0)
            {
                nodes.Add(map[x-1,y]);
            }

            if (x+1>=0&&x+1<mapLengh)
            {
                nodes.Add(map[x+1,y]);
            }

            if (y-1>=0)
            {
                nodes.Add(map[x,y-1]); 
            }
            
            if (y+1>=0&&y+1<mapWidth)
            {
                nodes.Add(map[x,y+1]); 
            }
            return nodes;
        }
    }
}