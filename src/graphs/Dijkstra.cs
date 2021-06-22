/*
Дан ориентированный взвешенный граф. Найдите кратчайшее расстояние от одной заданной вершины до другой.

Формат ввода
В первой строке содержатся три числа: N, S и F (1≤ N≤ 100, 1≤ S, F≤ N), где N – количество вершин графа, S – начальная вершина, а F – конечная. 
В следующих N строках вводится по N чисел, не превосходящих 100, – матрица смежности графа, где -1 означает отсутствие ребра между вершинами, 
а любое неотрицательное число – присутствие ребра данного веса. На главной диагонали матрицы записаны нули.

Формат вывода
Требуется вывести искомое расстояние или -1, если пути между указанными вершинами не существует. 
*/

using System;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = Int32.Parse(str[0]);
            int s = Int32.Parse(str[1])-1;
            int f = Int32.Parse(str[2])-1;
            int[,] arr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                str = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                    arr[i, j] = Int32.Parse(str[j]);
            }
            int[] d = new int[n];
            bool[] u = new bool[n];
            for (int i = 0; i < n; i++)
                d[i] = Int32.MaxValue;
            d[s] = 0;
            for(int i = 0; i < n; i++)
            {
                int v = -1;
                for (int j = 0; j < n; j++)
                    if (!u[j] && (v == -1 || d[j] < d[v]))
                        v = j;
                if (d[v] == Int32.MaxValue)
                    break;
                u[v] = true;

                for(int j = 0; j < n; j++)
                {
                    int to, len;
                    if (arr[v, j] > 0)
                    {
                        to = j;
                        len = arr[v, j];
                    }
                    else
                        continue;
                    if (d[v] + len < d[to])
                        d[to] = d[v] + len;
                }
            }
            if (d[f] == Int32.MaxValue)
                Console.WriteLine(-1);
            else
                Console.WriteLine(d[f]);
        }
    }
}
