/*
Дан неориентированный граф. Требуется определить, есть ли в нем цикл, и, если есть, вывести его.

Формат ввода

В первой строке дано одно число n — количество вершин в графе ( 1 ≤ n ≤ 500 ). Далее в n строках задан сам граф матрицей смежности.

Формат вывода

Если в иcходном графе нет цикла, то выведите «NO». Иначе, в первой строке выведите «YES», во второй строке выведите число k — количество вершин в цикле, а в третьей строке выведите k различных чисел — номера вершин, которые принадлежат циклу в порядке обхода (обход можно начинать с любой вершины цикла). Если циклов несколько, то выведите любой. 
*/
using System;
using System.Collections.Generic;

namespace cycle_search
{
    class Program
    {
        private static List<int>[] g;
        private static int[] used;
        private static int[] p;
        private static bool cycle;
        private static int end_cycle;
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            g = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                g[i] = new List<int>();
            }
            used = new int[n + 1];
            p = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                string[] str = Console.ReadLine().Split(' ');
                for (int j = i; j <= n; j++)
                {
                    if (Int32.Parse(str[j - 1]) == 1)
                    {
                        g[i].Add(j);
                        g[j].Add(i);
                    }
                }
            }
            for (int i = 1; i <= n; i++)
            {
                if (used[i] == 0)
                {
                    dfs(i);
                    if (cycle)
                    {
                        break;
                    }
                }
            }
            if (!cycle)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
                int x = end_cycle;
                int count = 1;
                while (p[x] != -1)
                {
                    count++;
                    x = p[x];
                }
                Console.WriteLine(count);
                x = end_cycle;
                while (x != -1)
                {
                    Console.Write($"{x} ");
                    x = p[x];
                }
            }
        }

        private static void dfs(int v)
        {
            used[v] = 1;
            if (cycle)
                return; 
            for (int i = 0; i < g[v].Count; i++)
            {
                int to = g[v][i];
                if (used[to] == 0)
                {
                    p[to] = v;
                    dfs(to);
                    if (cycle)
                        return; 
                }
                else if (used[to] == 1 && to != p[v])
                {
                    p[to] = -1;
                    end_cycle = v;
                    cycle = true;
                    return;
                }
            }
            used[v] = 2;
        }
    }
}
