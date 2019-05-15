/****************************************************
** auth： onelei
** desc： 遗传算法
*****************************************************/
using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    internal class Program
    {
        /// <summary>
        /// 染色体;
        /// </summary>
        private class chromosome
        {
            /// <summary>
            /// 用6bit对染色体进行编码;
            /// </summary>
            public int[] bits = new int[6];

            /// <summary>
            /// 适应值;
            /// </summary>
            public int fitValue;

            /// <summary>
            /// 选择概率;
            /// </summary>
            public double fitValuePercent;

            /// <summary>
            /// 累积概率;
            /// </summary>
            public double probability;

            public chromosome Clone()
            {
                chromosome c = new chromosome();
                for (int i = 0; i < bits.Length; i++)
                {
                    c.bits[i] = bits[i];
                }
                c.fitValue = fitValue;
                c.fitValuePercent = fitValuePercent;
                c.probability = probability;
                return c;
            }
        }

        /// <summary>
        /// 染色体组;
        /// </summary>
        private static List<chromosome> chromosomes = new List<chromosome>();

        private static List<chromosome> chromosomesChild = new List<chromosome>();

        private static Random random = new Random();

        private enum ChooseType
        {
            Bubble,//冒泡;
            Roulette,//轮盘赌;
        }

        private static ChooseType chooseType = ChooseType.Roulette;

        /// <summary>
        /// Main入口函数;
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Console.WriteLine("遗传算法");
            Console.WriteLine("下面举例来说明遗传算法用以求函数最大值函数为y = -x*x+ 5的最大值，-32<=x<=31");
            // f(x)=-x2+ 5
            // 迭代次数;
            int totalTime = 200;
            Console.WriteLine("迭代次数为: " + totalTime);
            //初始化;
            Console.WriteLine("初始化: ");
            Init();
            // 输出初始化数据;
            Print();
            for (int i = 0; i < totalTime; i++)
            {
                Console.WriteLine("当前迭代次数: " + i);

                //重新计算fit值;;
                UpdateFitValue();

                // 挑选染色体;
                Console.WriteLine("挑选:");

                switch (chooseType)
                {
                    case ChooseType.Bubble:
                        // 排序;
                        Console.WriteLine("排序:");
                        ChooseChromosome();
                        break;

                    default:
                        //轮盘赌;
                        Console.WriteLine("轮盘赌:");
                        UpdateNext();
                        break;
                }
                Print(true);

                //交叉得到新个体;
                Console.WriteLine("交叉:");
                CrossOperate();
                Print();

                //变异操作;
                Console.WriteLine("变异:");
                VariationOperate();
                Print();
            }

            int maxfit = chromosomes[0].fitValue;
            for (int i = 1; i < chromosomes.Count; i++)
            {
                if (chromosomes[i].fitValue > maxfit)
                {
                    maxfit = chromosomes[i].fitValue;
                }
            }
            Console.WriteLine("最大值为: " + maxfit);
            Console.ReadLine();
        }

        /// <summary>
        /// 打印;
        /// </summary>
        private static void Print(bool bLoadPercent = false)
        {
            Console.WriteLine("=========================");
            for (int i = 0; i < chromosomes.Count; i++)
            {
                Console.Write("第" + i + "条" + " bits: ");
                for (int j = 0; j < chromosomes[i].bits.Length; j++)
                {
                    Console.Write(" " + chromosomes[i].bits[j]);
                }
                int x = DeCode(chromosomes[i].bits);
                Console.Write(" x: " + x);
                Console.Write(" y: " + chromosomes[i].fitValue);
                if (bLoadPercent)
                {
                    Console.Write(" 选择概率: " + chromosomes[i].fitValuePercent);
                    //Console.Write(" 累积概率: " + chromosomes[i].probability);
                }
                Console.WriteLine();
            }
            Console.WriteLine("=========================");
        }

        /// <summary>
        /// 初始化;
        /// </summary>
        private static void Init()
        {
            chromosomes.Clear();
            // 染色体数量;
            int length = 10;
            int totalFit = 0;

            for (int i = 0; i < length; i++)
            {
                chromosome chromosome = new chromosome();
                for (int j = 0; j < chromosome.bits.Length; j++)
                {
                    // 随机出0或者1;
                    //int seed = (i + j) * 100 / 3;//种子;
                    int bitValue = random.Next(0, 2);
                    chromosome.bits[j] = bitValue;
                }
                //获得十进制的值;
                int x = DeCode(chromosome.bits);
                int y = GetFitValue(x);
                chromosome.fitValue = y;
                chromosomes.Add(chromosome);
                //算出total fit;
                if (chromosome.fitValue <= 0)
                {
                    totalFit += 0;
                }
                else
                {
                    totalFit += chromosome.fitValue;
                }
            }
        }

        /// <summary>
        /// 解码,二进制装换;
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        private static int DeCode(int[] bits)
        {
            int result = bits[1] * 16 + bits[2] * 8 + bits[3] * 4 + bits[4] * 2 + bits[5] * 1;
            //正数;
            if (bits[0] == 0)
            {
                return result;
            }
            else
            {
                return -result;
            }
        }

        /// <summary>
        /// 获取fit值;
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int GetFitValue(int x)
        {
            //目标函数：y= - ( x^ 2 ) +5;
            return (x * x) + 5;
        }

        /// <summary>
        /// 更新下一代;
        /// 基于轮盘赌选择方法，进行基因型的选择;
        /// </summary>
        private static void UpdateNext()
        {
            // 获取总的fit;
            double totalFitValue = 0;
            for (int i = 0; i < chromosomes.Count; i++)
            {
                //适应度为负数的取0;
                if (chromosomes[i].fitValue <= 0)
                {
                    totalFitValue += 0;
                }
                else
                {
                    totalFitValue += chromosomes[i].fitValue;
                }
            }
            Console.WriteLine("totalFitValue " + totalFitValue);

            //算出每个的fit percent;
            for (int i = 0; i < chromosomes.Count; i++)
            {
                if (chromosomes[i].fitValue <= 0)
                {
                    chromosomes[i].fitValuePercent = 0;
                }
                else
                {
                    chromosomes[i].fitValuePercent = chromosomes[i].fitValue / totalFitValue;
                }
                Console.WriteLine("fitValuePercent " + i + " " + chromosomes[i].fitValuePercent);
            }

            ////计算累积概率;
            //// 第一个的累计概率就是自己的概率;
            chromosomes[0].probability = chromosomes[0].fitValuePercent;
            Console.WriteLine("probability 0 " + chromosomes[0].probability);
            double probability = chromosomes[0].probability;
            for (int i = 1; i < chromosomes.Count; i++)
            {
                if (chromosomes[i].fitValuePercent != 0)
                {
                    chromosomes[i].probability = chromosomes[i].fitValuePercent + probability;
                    probability = chromosomes[i].probability;
                }
                Console.WriteLine("probability " + i + " " + chromosomes[i].probability);
            }
            chromosomesChild.Clear();
            //轮盘赌选择方法,用于选出前两个;
            for (int i = 0; i < chromosomes.Count; i++)
            {
                //产生0-1之前的随机数;
                //int seed = i * 100 / 3;
                double rand = random.NextDouble();//0.0-1.0
                Console.WriteLine("挑选的rand " + rand);
                if (rand < chromosomes[0].probability)
                {
                    chromosomesChild.Add(chromosomes[0].Clone());
                }
                else
                {
                    for (int j = 0; j < chromosomes.Count - 1; j++)
                    {
                        if (chromosomes[j].probability <= rand && rand <= chromosomes[j + 1].probability)
                        {
                            chromosomesChild.Add(chromosomes[j + 1].Clone());
                        }
                    }
                }
            }
            for (int i = 0; i < chromosomes.Count; i++)
            {
                chromosomes[i] = chromosomesChild[i];
            }
        }

        /// <summary>
        /// 选择染色体;
        /// </summary>
        private static void ChooseChromosome()
        {
            // 从大到小排序;
            chromosomes.Sort((a, b) => { return b.fitValue.CompareTo(a.fitValue); });
        }

        /// <summary>
        /// 交叉操作;
        /// </summary>
        private static void CrossOperate()
        {
            /**         bit[5]~bit[0]   fit
             * 4        000 110         12
             * 3        001 010         9
             * child1   000 010         14
             * child2   001 110         5
             */
            int rand1 = random.Next(0, 6);//0-5;
            int rand2 = random.Next(0, 6);//0-5;
            if (rand1 > rand2)
            {
                var t = rand1;
                rand1 = rand2;
                rand2 = t;
            }
            Console.WriteLine("交叉的rand " + rand1 + " - " + rand2);
            for (int j = 0; j < chromosomes.Count; j = j + 2)
            {
                for (int i = rand1; i <= rand2; i++)
                {
                    //将第0个给第2个;
                    var t = chromosomes[j].bits[i];
                    chromosomes[j].bits[i] = chromosomes[j + 1].bits[i];//第一条和第三条交叉;
                    chromosomes[j + 1].bits[i] = t;
                }
                chromosomes[j].fitValue = GetFitValue(DeCode(chromosomes[j].bits));
                chromosomes[j + 1].fitValue = GetFitValue(DeCode(chromosomes[j + 1].bits));
            }
        }

        /// <summary>
        /// 变异操作;
        /// </summary>
        private static void VariationOperate()
        {
            int rand = random.Next(0, 50);
            Console.WriteLine("变异的rand " + rand);
            if (rand < 5)//1/50 = 0.02的概率进行变异;rand==25;
            {
                Console.WriteLine("开始变异");

                int col = random.Next(0, 6);
                int row = random.Next(0, 4);
                Console.WriteLine("变异的位置 " + row + "  " + col);
                // 0变为1,1变为0;
                if (chromosomes[row].bits[col] == 0)
                {
                    chromosomes[row].bits[col] = 1;
                }
                else
                {
                    chromosomes[row].bits[col] = 0;
                }
                chromosomes[row].fitValue = GetFitValue(DeCode(chromosomes[row].bits));
            }
        }

        /// <summary>
        /// 重新计算fit值;
        /// </summary>
        private static void UpdateFitValue()
        {
            for (int i = 0; i < chromosomes.Count; i++)
            {
                chromosomes[i].fitValue = GetFitValue(DeCode(chromosomes[i].bits));
            }
        }
    }
}