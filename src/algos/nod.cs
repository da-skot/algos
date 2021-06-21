/*
По данным двум числам 1≤a,b≤2⋅109 найдите их наибольший общий делитель.

Задача из курса «Алгоритмы: теория и практика. Методы»: https://stepik.org/course/217/syllabus

Формат ввода
В первой строке входных данных два целых числа a и b.

Формат вывода
Выведите наибольший общий делитель чисел a и b. 
*/

using System;

namespace evklid
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = Int32.Parse(str[0]);
            int m = Int32.Parse(str[1]);
            while( m != 0)
            {
                int t = m;
                m = n % m;
                n = t;
            }
            Console.WriteLine(n);
        }
    }
}
