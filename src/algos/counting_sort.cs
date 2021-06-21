/*
Реализуйте алгоритм сортировки подсчетом для произвольных чисел, по модулю не превосходящих 10000.
Формат ввода

На вход программе сначала подается значение n ≤ 100000 – количество элементов в массиве. В следующей строке входных данных расположены сами элементы массива – целые числа, по модулю не превосходящие 10000.
Формат вывода

Распечатайте отсортированный по неубыванию массив.
*/
using System;

namespace razn
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
            counting_sort(arr);
        }
        private static void counting_sort(int[] arr)
        {
            int min = 10001, max = -10001, k;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }
            k = max - min + 1;
            int[] c = new int[k];
            for (int i = 0; i < k; i++)
                c[i] = 0;
            for (int i = 0; i < arr.Length; i++)
                c[arr[i] - min]++;
            int b = 0;
            for (int j = 0; j < k; j++) 
            { 
                for (int i = 0; i < (c[j]); i++)
                {
                    arr[b] = j + min;
                    b++;
                }
                
            }
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }
    }
}
