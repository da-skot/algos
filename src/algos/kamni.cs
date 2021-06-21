/*
Задача о камнях.

Имеется N камней с разными весами P. Необходимо найти набор камней с максимальным суммарным весом, не превосходящим W.
Необходимо решить задачу используя динамическое программирование.
Формат ввода

Во входном файле 3 строки:

В первой строке число N - это количество доступных камней.
1 <= N <= 1000

Во второй строке число W - ограничение на максимальный вес.
0 <= W <= 50000

В третьей строке N чисел, это веса доступных камней.
Пусть вес камня это P, тогда 1 <= P <= 8000
Набор упорядочен по возрастанию веса, но могут встречаться камни одинакового веса!
Формат вывода

В выходной файл надо записать 3 строки:

В первой строке число A - это суммарный вес всех камней, которые вошли в решение.
Предполагаемые ограничения: 0 <= A <= 50000

Во второй строке число M - количество камней вошедших в решение.
Предполагаемые ограничения: 0 <= M <= 1000

В третьей строке M чисел, это веса взятых камней.
Пусть вес камня это P, тогда 1 <= P <= 8000
Все веса должны быть из входных данных и следовать в неубывающем порядке. 
*/

using System;
using System.IO;
using System.Collections.Generic;

namespace podposled
{
    class Program
    {
        static int[,] TotalValue;
        static int[] weights;
        static List<int> items_weight = new List<int>();
        static void Main(string[] args)
        {
            string[] weight;
            int n, m;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = Int32.Parse(sr.ReadLine());
                m = Int32.Parse(sr.ReadLine());
                weight = sr.ReadLine().Split(' ');
            }
            weights = new int[n];
            for (int i = 0; i < n; i++)
            {
                weights[i] = Int32.Parse(weight[i]); 
            }
            TotalValue = new int[n + 1, m + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0 || j == 0)
                        TotalValue[i, j] = 0;
                    else if (weights[i - 1] <= j)
                        TotalValue[i, j] = Math.Max(weights[i - 1] + TotalValue[i - 1, j - weights[i - 1]], TotalValue[i - 1, j]);
                    else
                        TotalValue[i, j] = TotalValue[i - 1, j];
                }
            }
            findans(n, m);
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine(TotalValue[n, m]);
                sw.WriteLine(items_weight.Count);
                sw.WriteLine(String.Join(" ",items_weight));
            }
        }
        static void findans(int k, int s)
        {
            if (k <= 0)
                return;
            if (TotalValue[k, s] == 0)
                return;
            if (TotalValue[k - 1, s] == TotalValue[k, s])
                findans(k - 1, s);
            else
            {
                findans(k - 1, s - weights[k-1]);
                items_weight.Add(weights[k-1]);
            }
        }
    }
}
