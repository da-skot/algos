/*
Неориентированный граф с кратными рёбрами называется полным, если любая пара его различных вершин соединена хотя бы одним ребром.
Для заданного списком ребер графа проверьте, является ли он полным.
Формат ввода

Сначала вводятся числа n (1 <= n <= 100) – количество вершин в графе и m (1 <= m <=10000) – количество ребер. Затем следует m пар чисел – ребра графа.
Формат вывода

Выведите «YES», если граф является полным, и «NO» в противном случае.
*/
using System;
using System.Collections.Generic;

namespace razn
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = Int32.Parse(str[0]);
            n = n * (n - 1) / 2;
            int m = Int32.Parse(str[1]);
            List<graf> grafs = new List<graf>();
            str = Console.ReadLine().Split(' ');
            graf q = new graf(Int32.Parse(str[0]), Int32.Parse(str[1]));
            grafs.Add(q);
            for (int i = 1; i < m; i++)
            {
                str = Console.ReadLine().Split(' ');
                if (q.check(Int32.Parse(str[0]), Int32.Parse(str[1])))
                {
                    graf graf1 = new graf(Int32.Parse(str[0]), Int32.Parse(str[1]));
                    grafs.Add(graf1);
                    q = graf1;
                }
            }
            if (n == grafs.Count)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }

    public class graf
    {
        int a;
        int b;
        public graf(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public bool check (int a, int b)
        {
            if ((this.a == a && this.b == b) || (this.a == b && this.b == a))
                return false;
            else
                return true;
        }
    }
}
