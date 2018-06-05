using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS
{
    internal class Program
    {
        private static int[,] map;
        public static void Main(string[] args)
        {
            
            map = new int[10,10]{           // 初始的map_maze  
                { 1, 0, 3, 3, 3, 3, 3, 0, 3, 3 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 3, 0 },
                { 0, 0, 0, 3, 0, 0, 3, 3, 3, 0 },
                { 3, 0, 0, 0, 0, 3, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 },
                { 3, 0, 0, 0, 3, 0, 0, 3, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 3, 0, 0, 0 },
                { 0, 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 3, 3, 3, 0, 0, 3, 0, 3, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 3, 3, 0, 3 },
            };

             
            getMapStrings();
                
            BFS.InitMap(map);
            List<Node> passNodes = new List<Node>();
            int startX,startY;
            int endX,endY;
            getPoint(1,out startX,out startY);
            getPoint(2,out endX,out endY);
            Node start = new Node(startX,startY,map[startX,startY]);
            Node end = new Node(endX,endY, map[endX,endY]);
            BFS.Search(start,end,ref passNodes);
            
            Console.WriteLine("\n === BFS 寻路结束 === " + (passNodes.Count>0));
            Console.WriteLine("一共有 "+passNodes.Count +" 个中间节点");

            for (int i = 0; i < passNodes.Count; i++)
            {
                int x = passNodes[i].X;
                int y = passNodes[i].Y;
                
                map[x, y] = 8;
            }

            PrintMapData();
            
            getMapStrings();
            
            /*
            map = new int[10,10]{           // 初始的map_maze  
                { 1, 0, 0, 3, 0, 3, 0, 0, 0, 0 },
                { 0, 0, 3, 0, 0, 3, 0, 3, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 3, 3, 0, 3 },
                { 3, 0, 3, 0, 0, 0, 0, 0, 0, 3 },
                { 3, 0, 0, 2, 0, 3, 0, 3, 0, 3 },
                { 3, 0, 0, 3, 0, 0, 0, 3, 0, 3 },
                { 3, 0, 3, 0, 0, 3, 3, 0, 0, 0 },
                { 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 },
                { 3, 3, 3, 0, 0, 3, 0, 3, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 3, 3, 0, 3 },
            };
            */
            
            map = new int[10,10]{           // 初始的map_maze  
                { 1, 0, 3, 3, 3, 3, 3, 0, 3, 3 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 3, 0 },
                { 0, 0, 0, 3, 0, 0, 3, 3, 3, 0 },
                { 3, 0, 0, 0, 0, 3, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 },
                { 3, 0, 0, 0, 3, 0, 0, 3, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 3, 0, 0, 0 },
                { 0, 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 3, 3, 3, 0, 0, 3, 0, 3, 0, 3 },
                { 3, 0, 0, 0, 0, 3, 3, 3, 0, 3 },
            };

            Console.WriteLine("DFS开始======================================");
            PrintMapData();
            getMapStrings();

            DFS.InitMap(map);
            passNodes.Clear();
            getPoint(1,out startX,out startY);
            getPoint(2,out endX,out endY);
            start = new Node(startX,startY,map[startX,startY]);
            end = new Node(endX,endY, map[endX,endY]);
            DFS.Search(start,end,ref passNodes);
            Console.WriteLine("\n === DFS 寻路结束 === " + (passNodes.Count>0));
            Console.WriteLine("一共有 "+passNodes.Count +" 个中间节点");

            for (int i = 0; i < passNodes.Count; i++)
            {
                int x = passNodes[i].X;
                int y = passNodes[i].Y;
                Console.Write(x+","+y+"  ");
                map[x, y] = 8;
            }

            PrintMapData();
            getMapStrings();

        }
        
        private static void getPoint(int value,out int x,out int y)
        {
            x = 0;
            y = 0;
            int mapLength = map.GetLength(0);
            int mapWidth = map.GetLength(1);
            for (int i = 0; i < mapLength; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (map[i,j] == value)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            } 
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
        
        private  static void getMapStrings()
        {
            Console.WriteLine();
            int mapLength = map.GetLength(0);
            int mapWidth = map.GetLength(1);
            string[,] result = new string[mapLength,mapWidth];
            for (int i = 0; i < mapLength; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    switch (map[i, j])
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("S");
                            break;
                        case 2:
                            Console.Write("E");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                        case 4:
                            Console.Write(".");
                            break;
                        case 8:
                            Console.Write("A");
                            break;
                    }
                    Console.Write("  ");
                }

                Console.WriteLine();

            }
        }
        
        
    }
}