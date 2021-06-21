/*
По данному числу 1≤n≤109 найдите максимальное число k, для которого n можно представить как сумму k различных натуральных слагаемых.

Задача из курса «Алгоритмы: теория и практика. Методы»: https://stepik.org/course/217/syllabus

Формат ввода
В первой строке входных данных одно целое число n.
Формат вывода
Выведите в первой строке число k, во второй — k слагаемых. 
*/

using System;
using System.Collections.Generic;

namespace evklid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            List<int> arr = new List<int>();
            int i = 0;
            while (true)
            {
                i++;
                if (i * 2 < n)
                {
                    arr.Add(i);
                    n = n - i;
                }
                else
                {
                    arr.Add(n);
                    break;
                }
            }
            Console.WriteLine(arr.Count);
            Console.WriteLine(String.Join(" ",arr));
        }
    }
}
