/*
От вас требуется определить вес минимального остовного дерева для неориентированного взвешенного связного графа.

Формат ввода
В первой строке входных данных находятся числа N и M (1 <= N <= 100; 1 <= M <= 6000), где N – количество вершин в графе, а M – количество рёбер. 
В каждой из последующих M строк записано по тройке чисел A, B, C, где A и B – номера вершин, соединённых ребром, а C – вес ребра (натуральное число, не превышающее 30000)

Формат вывода
Вывести одно число – искомый вес.
*/

using System;

namespace Prima
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = Int32.Parse(str[0]);
            int m = Int32.Parse(str[1]);
            int[,] g = new int[n, n];
            int[] min_e = new int[n];
            int[] sel_e = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    g[i, j] = Int32.MaxValue;
                min_e[i] = Int32.MaxValue;
                sel_e[i] = -1;

            }
            for (int i = 0; i < m; i++)
            {
                str = Console.ReadLine().Split(' ');
                g[Int32.Parse(str[0])-1, Int32.Parse(str[1])-1] = Int32.Parse(str[2]);
                g[Int32.Parse(str[1]) - 1, Int32.Parse(str[0]) - 1] = Int32.Parse(str[2]);
            }
            bool[] used = new bool[n];
            min_e[0] = 0;
            int cost = 0;
            for (int i = 0; i < n; i++)
            {
                int v = -1;
                for (int j = 0; j < n; j++)
                    if (!used[j] && (v == -1 || min_e[j] < min_e[v]))
                        v = j;
                if (min_e[v] == Int32.MaxValue)
                    break;
                if (sel_e[v] != -1)
                    cost += g[v, sel_e[v]];
                used[v] = true;
                for (int to = 0; to < n; to++)
                    if (g[v, to] < min_e[to])
                    {
                        min_e[to] = g[v, to];
                        sel_e[to] = v;
                    }
            }
            Console.WriteLine(cost);
        }
    }
}
