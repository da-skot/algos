/*
Отсортируйте данный массив. Используйте пирамидальную сортировку.
Формат ввода

Первая строка входных данных содержит количество элементов в массиве N, N ≤ 10ˆ5. Далее задаются N целых чисел, не превосходящих по абсолютной величине 10ˆ9.
Формат вывода

Выведите эти числа в порядке неубывания.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace HeapSort
{
    class Program
    {
        private static List<int> list;
        static void Main(string[] args)
        {
            list = new List<int>();
            int n = Int32.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = Int32.Parse(str[i]);
            heapSort(arr);
            foreach (int i in arr)
                Console.Write($"{i} ");
        }
        private static void  heapSort(int[] arr)
        {
            list = arr.ToList();
            for (int i = list.Count / 2; i >= 0; i--)
                heapify(i);
            for (int i = arr.Length-1; i>=0; i--)
            {
                arr[i] = list[0];
                list[0] = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                heapify(0);
            }
        }
        private static void heapify(int i)
        {
            int leftChild, rightChild, largestChild;
            while(true)
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;
                if (leftChild < list.Count && list[leftChild] > list[largestChild])
                    largestChild = leftChild;
                if (rightChild < list.Count && list[rightChild] > list[largestChild])
                    largestChild = rightChild;
                if (largestChild == i)
                    break;
                int t = list[i];
                list[i] = list[largestChild];
                list[largestChild] = t;
                i = largestChild;
            }
        }
    }
}
