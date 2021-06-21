/*
В этой задаче вам необходимо организовать структуру данных Heap для хранения целых чисел, над которой определены следующие операции: a) Insert(k) – добавить в Heap число k (1 ≤ k ≤ 1000000) ; b) Extract достать из Heap наибольшее число (удалив его при этом).
Формат ввода

В первой строке содержится количество команд N (1 ≤ N ≤ 100000), далее следуют N команд, каждая в своей строке. Команда может иметь формат: “0 <число>” или “1”, обозначающий, соответственно, операции Insert(<число>) и Extract. Гарантируется, что при выполенении команды Extract в структуре находится по крайней мере один элемент.
Формат вывода

Для каждой команды извлечения необходимо отдельной строкой вывести число, полученное при выполнении команды Extract.
*/

using System;
using System.Collections.Generic;

namespace Heap
{
    class Program
    {
        private static List<int> list;
        static void Main(string[] args)
        {
            list = new List<int>();
            int n = Int32.Parse(Console.ReadLine());
            List<int> arr = new List<int>();
            for (int j = 0; j < n; j++)
            {
                string str = Console.ReadLine();
                if (str == "1")
                {
                    arr.Add(list[0]);
                    list[0] = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    heapify(0);
                }
                else
                {
                    list.Add(Int32.Parse(str.Split(' ')[1]));
                    for (int i = list.Count / 2; i >= 0; i--)
                        heapify(i);
                }
            }
            foreach (int i in arr)
                Console.WriteLine(i);
        }
        private static void heapify(int i)
        {
            int leftChild, rightChild, largestChild;
            while (true)
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
