/*
По данным числам N и K выведите все возрастающие последовательности длины K из чисел 1..N в лексикографическом порядке.

Формат ввода
Заданы 2 числа: N и K (1 ≤ K,N ≤ 100). Для всех тестов верно, что число требуемых последовательностей не превышает 5000.

Формат вывода
Необходимо вывести все возрастающие последовательности длины K из чисел 1..N в лексикографическом порядке. Последовательности выводятся по одной в строке, числа внутри последовательностей разделяются пробелами. 
*/
using System;
using System.Collections.Generic;

namespace Combinations
{
    class Program
    {
        static int n, m;
        static List<int> ans;
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            n = Int32.Parse(str[0]);
            m = Int32.Parse(str[1]);
            ans = new List<int>();
            ans.Add(-1);
            for (int i = 1; i <= n; i++)
                ans.Add(i);
            Combinations(1, 1);
        }
        static void Combinations(int a, int b)
        {
            bool flaq = true;
            if(a > m)
            {
                for (int i = 1; i <= m; i++)
                    Console.Write($"{ans[i]} ");
                Console.WriteLine();
                flaq = false;
            }
            if (flaq)
                for (int i = b; i <= n - m + a; ++i)
                {
                    ans[a] = i;
                    Combinations(a + 1, i + 1);
                }
        }
    }
}
