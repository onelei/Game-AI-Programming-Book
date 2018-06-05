# 遗传算法
示例为计算函数为y = -x*x+ 5的最大值，-32<=x<=31.

参考: http://blog.csdn.net/ljp1919/article/details/42425281

采用轮盘赌算法作为选择算子的算法

# 核心算法

## 轮盘赌

```
        /// <summary>
        /// 更新下一代;
        /// 基于轮盘赌选择方法，进行基因型的选择;
        /// </summary>
        static void UpdateNext()
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
            //计算累积概率;
            // 第一个的累计概率就是自己的概率;
            chromosomes[0].probability = chromosomes[0].fitValuePercent;
            for (int i = 1; i < chromosomes.Count; i++)
            {
                // 上一个的累计概率加上自己的概率,得到自己的累计概率;
                chromosomes[i].probability = chromosomes[i - 1].probability + chromosomes[i].fitValuePercent;
            }
            //轮盘赌选择方法,用于选出前两个;
            for (int i = 0; i < chromosomes.Count; i++)
            {

                //产生0-1之前的随机数;
                int seed = i * 100 / 3;
                double rand = new Random(seed).NextDouble();//0.0-1.0
                Console.WriteLine("挑选的rand " + rand);
                if (rand < chromosomes[0].probability)
                {
                    chromosomes[i] = chromosomes[0];
                }
                else
                {
                    for (int j = 0; j < chromosomes.Count - 1; j++)
                    {
                        if (chromosomes[j].probability <= rand && rand <= chromosomes[j + 1].probability)
                        {
                            chromosomes[i] = chromosomes[j + 1];
                        }
                    }
                }
            }
        }
```

## 交叉操作

```
        /// <summary>
        /// 交叉操作;
        /// </summary>
        static void CrossOperate()
        {
            /**         bit[5]~bit[0]   fit
             * 4        000 110         12
             * 3        001 010         9
             * child1   000 010         14
             * child2   001 110         5
             */
            int rand = new Random().Next(0, 6);//0-5;
            Console.WriteLine("交叉的rand " + rand);
            for (int i = 0; i < rand; i++)
            {
                //将第0个给第2个;
                chromosomes[2].bits[i] = chromosomes[0].bits[i];//第一条和第三条交叉;
                chromosomes[3].bits[i] = chromosomes[1].bits[i];//第二条和第四条交叉;
            }

            for (int i = rand; i < 6; i++)
            {
                chromosomes[2].bits[i] = chromosomes[1].bits[i];//第一条和第三条交叉;
                chromosomes[3].bits[i] = chromosomes[0].bits[i];//第二条和第四条交叉;
            }
        }
```

## 变异操作

```
        /// <summary>
        /// 变异操作;
        /// </summary>
        static void VariationOperate()
        {
            int rand = new Random(DateTime.Now.Millisecond).Next(0, 50);
            Console.WriteLine("变异的rand " + rand);
            if (rand == 25)//1/50 = 0.02的概率进行变异;rand==25;
            {
                Console.WriteLine("开始变异");

                int col = new Random(DateTime.Now.Millisecond * 10).Next(0, 6);
                int row = new Random(DateTime.Now.Millisecond * 10).Next(0, 4);

                // 0变为1,1变为0;
                if (chromosomes[row].bits[col] == 0)
                {
                    chromosomes[row].bits[col] = 1;
                }
                else
                {
                    chromosomes[row].bits[col] = 0;
                }
            }
        }
```
