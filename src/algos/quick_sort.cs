/*
Реализовать сортировку Хоара (быструю, quicksort)
по неубыванию для заданного целочисленного массива N элементов
с выбором в качестве опорного среднего элемента обрабатываемой части массива.
Решить данную задачу требуется по классической схеме Хоара: с двумя индексами и массив делится на 2 части.
Определить количество рекурсивных вызовов.
Формат ввода

В первой строке — целое число N, количество элементов во входном массиве.
Во второй строке — массив N целых чисел со знаком, разделенных пробелом.
Формат вывода

В первой строке - целое число, количество рекурсивных вызовов.
Во второй строке — N элементов сортированного по неубыванию массива, разделенных пробелом. 
*/
using System;
using System.IO;

namespace Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int[] arr;  
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = Int32.Parse(sr.ReadLine());
                arr = new int[n];
                string[] str = sr.ReadLine().Split(' ');
                for (int i = 0; i < n; i++)
                    arr[i] = Int32.Parse(str[i]);
                sr.Close();
            }
            quicksort(arr, 0, arr.Length - 1);
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine(count-1);
                foreach (int i in arr)
                    sw.Write($"{i} ");
                sw.Close();
            }
        }
        private static int count = 0;
        private static int[] quicksort(int[] arr, int lo, int hi)
        {
            int i = lo;
            int j = hi;
            int pivot = arr[i + (j - i) / 2];
            while(i<=j)
            {
                while (arr[i] < pivot)
                    i++;
                while (arr[j] > pivot)
                    j--;
                if (i <= j)
                {
                    int t = arr[j];
                    arr[j] = arr[i];
                    arr[i] = t;
                    i++;
                    j--;
                }
            }
            count++;
            if (lo < j)
                quicksort(arr, lo, j);
            if (i < hi)
                quicksort(arr, i, hi);
            return arr;
        }
    }
}
