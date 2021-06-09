/*
Дан неориентированный граф, возможно, с петлями и кратными ребрами. Необходимо построить компоненту связности, содержащую первую вершину.
Формат ввода

В первой строке записаны два целых числа N (1 ≤ N ≤ 103) и M (0 ≤ M ≤ 5 * 105) — количество вершин и ребер в графе. В последующих M строках перечислены ребра — пары чисел, определяющие номера вершин, которые соединяют ребра.
Формат вывода

В первую строку выходного файла выведите число K — количество вершин в компоненте связности. Во вторую строку выведите K целых чисел — вершины компоненты связности, перечисленные в порядке возрастания номеров. 
*/

using System;
using System.Collections.Generic;

namespace Depth_first_search
{
    class Program
    {
        private static List<int>[] g;
        private static bool[] used;
        private static int count = 0;
        private static void dfs(int v)
        {
            count++;
            used[v] = true;
            foreach (int i in g[v])
            {
                if (!used[i])
                    dfs(i);
            }
        }
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = Int32.Parse(str[0]);
            int m = Int32.Parse(str[1]);
            used = new bool[n];
            g = new List<int>[n];
            for (int i = 0; i < n; i++)
                g[i] = new List<int>();
            for(int i = 0; i < m; i++)
            {
                str = Console.ReadLine().Split(' ');
                g[Int32.Parse(str[0])-1].Add(Int32.Parse(str[1])-1);
                g[Int32.Parse(str[1]) - 1].Add(Int32.Parse(str[0]) - 1);
            }
            dfs(0);
            Console.WriteLine(count);
            for (int i = 0; i < n; i++)
                if (used[i])
                    Console.Write($"{i + 1} ");
        }
    }
}
