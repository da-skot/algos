/*
Отсортируйте массив при помощи цифровой сортировки.
Формат ввода

Сначала вводятся числа N (1 ≤ N ≤ 100000) и k (1 ≤ k ≤ 9) — количество элементов в массиве и количество разрядов в числах соотвественно. Во второй строке вводятся N чисел, в каждом из которых ровно k значащих цифр.
Формат вывода

Выведите отсортированный массив, разделяя числа пробелами.
*/

using System;

namespace razn
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] st = Console.ReadLine().Split(' ');
            int n = Int32.Parse(st[0]);
            int k = Int32.Parse(st[1]);
            string[] str = Console.ReadLine().Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = Int32.Parse(str[i]);
            radix_sort(arr, k);
        }
        private static void radix_sort(int[] arr, int m)
        {
            int[] b = new int[arr.Length];
            for (int i = 1; i <= m; i++)
            {
                int[] c = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int j = 0; j < arr.Length; j++)
                {
                    int d = digit(arr[j], i);
                    c[d]++;
                }
                int count = 0;
                for (int j = 0; j < 10; j++)
                {
                    int tmp = c[j];
                    c[j] = count;
                    count += tmp;
                }
                for (int j = 0; j < arr.Length; j++)
                {
                    int d = digit(arr[j], i);
                    b[c[d]] = arr[j];
                    c[d]++;
                }
                b.CopyTo(arr,0);
            }

            foreach (int i in arr)
                Console.Write($"{i} ");
        }
        private static int digit(int a, int b)
        {
            string str = a.ToString();
            char s = str[str.Length - b];
            return (Int32.Parse(s.ToString()));
        }
    }
}
