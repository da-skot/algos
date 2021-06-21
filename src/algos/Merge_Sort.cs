/*
Отсортируйте данный массив, используя сортировку слиянием.
Формат ввода

Первая строка входных данных содержит количество элементов в массиве N, N ≤ 10ˆ5. Далее идет N целых чисел, не превосходящих по абсолютной величине 10ˆ9.
Формат вывода

Выведите эти числа в порядке неубывания.
*/

using System;

namespace Merge_Sort
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
            foreach (int i in mergesort(arr))
                Console.Write($"{i} ");
        }
        private static int[] mergesort(int[] arr)
        {
            if (arr.Length == 1)
                return arr;
            else
            {
                int m = arr.Length / 2;
                int[] arr1 = new int[arr.Length - m];
                int[] arr2 = new int[m];
                Array.Copy(arr, 0, arr1, 0, arr.Length - m);
                Array.Copy(arr, (arr.Length - m), arr2, 0, m);
                return merge(mergesort(arr1), mergesort(arr2));
            }
        }
        private static int[] merge(int[] arr1, int[] arr2)
        {
            int[] arr = new int[arr1.Length + arr2.Length];
            int l = 0, r = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(l<arr1.Length && r<arr2.Length)
                {
                    if (arr1[l] <= arr2[r])
                    {
                        arr[i] = arr1[l];
                        l++;
                    }
                    else
                    {
                        arr[i] = arr2[r];
                        r++;
                    }
                }
                else
                {
                    if (l < arr1.Length)
                    {
                        arr[i] = arr1[l];
                        l++;
                    }
                    else
                    {
                        arr[i] = arr2[r];
                        r++;
                    }
                }
            }
            return arr;
        }
    }
}
