/*


В неориентированном графе требуется найти минимальный путь между двумя вершинами.
Формат ввода

Первым на вход поступает число N – количество вершин в графе (1 ≤ N ≤ 100). Затем записана матрица смежности (0 обозначает отсутствие ребра, 1 – наличие ребра). Далее задаются номера двух вершин – начальной и конечной.

Формат вывода

Выведите сначала L – длину кратчайшего пути (количество ребер, которые нужно пройти), а потом сам путь. Если путь имеет длину 0, то его выводить не нужно, достаточно вывести длину.

Необходимо вывести путь (номера всех вершин в правильном порядке). Если пути нет, нужно вывести -1.

*/
using System;
using System.Collections.Generic;

namespace path_graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[,] g = new bool[n + 1, n + 1];
            string[] str;
            for (int i = 1; i <= n; i++)
            {
                str = Console.ReadLine().Split(' ');
                for (int j = i; j <= n; j++)
                {
                    if (Int32.Parse(str[j-1]) == 1)
                    {
                        g[i, j] = true;
                        g[j, i] = true;
                    }
                    else
                    {
                        g[i, j] = false;
                        g[j, i] = false;
                    }
                }
            }
            str = Console.ReadLine().Split(' ');
            int first = int.Parse(str[0]);
            int last = int.Parse(str[1]);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(first);
            bool[] used = new bool[n + 1];
            used[first] = true;
            int[] d = new int[n + 1];
            int[] p = new int[n + 1];
            if (first != last)
            {
                while (queue.Count != 0)
                {
                    int v = queue.Peek();
                    queue.Dequeue();
                    for (int i = 1; i <= n; i++)
                    {
                        if (g[v, i])
                        {
                            if (!used[i])
                            {
                                used[i] = true;
                                queue.Enqueue(i);
                                d[i] = d[v] + 1;
                                p[i] = v;
                            }
                        }
                    }
                }
                if (d[last] == 0 && p[last] == 0)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine(d[last]);
                    Stack<int> path = new Stack<int>();
                    path.Push(last);
                    for (int i = 0; i < d[last]; i++)
                    {
                        int value = path.Peek();
                        path.Push(p[value]);
                    }
                    foreach (int value in path)
                    {
                        Console.Write($"{value} ");
                    }
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
