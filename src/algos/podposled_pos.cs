/*
Дано целое число 1≤n≤103 и массив A[1…n] натуральных чисел, не превосходящих 2⋅109.

Выведите максимальное 1≤k≤n, для которого найдётся подпоследовательность 1≤i1<i2<…<ik≤n длины k, в которой каждый элемент делится на предыдущий 
(формально: для всех 1≤j<k, A[ij]∣∣A[ij+1]).

Задача из курса «Алгоритмы: теория и практика. Методы»: https://stepik.org/course/217/syllabus
*/

using System;

namespace evklid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = Int32.Parse(str[i]);
            int max = 0;
            int[] count = new int[n];
            for (int i = 0; i < n; i++)
            {
                count[i] = 0;
                for (int j = i - 1; j >= 0; j--)
                    if (arr[j] <= arr[i] && arr[i] % arr[j] == 0)
                        count[i] = Math.Max(count[j], count[i]);
                count[i]++; 
                max = Math.Max(max, count[i]);
            }
            Console.WriteLine(max);
        }
    }
}
