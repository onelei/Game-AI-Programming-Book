using System;
using System.Collections.Generic;

namespace AStar
{
    internal class Program
    {
        private static int[,] map;
        public static void Main(string[] args)
        { 
            map = new int[10,10]{           // 初始的map_maze  
                { 1, 0, 0, 3, 0, 3, 0, 0, 0, 0 },
                { 0, 0, 3, 0, 0, 3, 0, 3, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 3, 3, 0, 3 },
                { 3, 0, 3, 0, 0, 0, 0, 0, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 0, 0, 0, 3 },
                { 3, 0, 0, 3, 0, 0, 0, 3, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 3, 0, 0, 0 },
                { 0, 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 3, 3, 3, 0, 0, 3, 0, 3, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 3, 3, 0, 3 },
            };

            PrintMapData();

            AStar.InitMap(map);

            AStarNode start = new AStarNode(0,0);
            AStarNode end = new AStarNode(7,2);
            List<AStarNode> passNodes = new List<AStarNode>();

            bool bFind = AStar.FindPath(start, end, ref passNodes);

            Console.WriteLine("\n === A* 寻路结束 === " +bFind);
            Console.WriteLine("一共有 "+passNodes.Count +" 个中间节点");

            for (int i = 0; i < passNodes.Count; i++)
            {
                int x = passNodes[i].Point.X;
                int y = passNodes[i].Point.Y;
                
                map[x, y] = 8;
            }

            PrintMapData();
             
        }

        private static void PrintMapData()
        {
            int mapLength = map.GetLength(0);
            int mapWidth = map.GetLength(1);
            for (int i = 0; i < mapLength; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                { 
                    Console.Write(map[i,j] + ", ");
                }
                Console.WriteLine();
            }
        }
        
        
    }
}