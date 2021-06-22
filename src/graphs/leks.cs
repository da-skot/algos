/*
Дано натуральное число N. Рассмотрим его разбиение на натуральные слагаемые. Два разбиения, отличающихся только порядком слагаемых, будем считать за одно, поэтому можно считать, что слагаемые в разбиении упорядочены по невозрастанию.

Формат ввода
Задано единственное число N. (N ≤ 40)

Формат вывода
Необходимо вывести все разбиения числа N на натуральные слагаемые в лексикографическом порядке.
*/
using System;
using System.Collections.Generic;

namespace Combinations
{
    class Program
    {
        static int n;
        static List<int> ans;
        static void Main(string[] args)
        {
            n = Int32.Parse(Console.ReadLine());
            ans = new List<int>();
            ans.Add(-1);
            for (int i = 1; i <= n; i++)
                ans.Add(0);
            Combinations(1, n, n);
        }
        static void Combinations(int a, int b, int c)
        {
            bool flaq = true;
            if(c == 0)
            {
                for (int i = 1; i < a; i++)
                    Console.Write($"{ans[i]} ");
                Console.WriteLine();
                flaq = false;
            }
            if (flaq)
            {
                int min = Math.Min(b, c);
                for (int i = min; i > 0; i--)
                {
                    ans[a] = i;
                    Combinations(a + 1, i , c-i);
                }
            }
        }
    }
}
