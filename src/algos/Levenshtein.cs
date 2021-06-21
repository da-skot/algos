/*
Вычислите расстояние редактирования двух данных непустых строк длины не более 102, содержащих строчные буквы латинского алфавита.

Задача из курса «Алгоритмы: теория и практика. Методы»: https://stepik.org/course/217/syllabus

Расстояние Левенштейна (редакционное расстояние, дистанция редактирования) – метрика, измеряющая разность между двумя последовательностями символов. 
Она определяется как минимальное количество односимвольных операций (а именно вставки, удаления, замены), необходимых для превращения одной последовательности символов в другую. 
В общем случае, операциям, используемым в этом преобразовании, можно назначить разные цены. 
*/

using System;
using System.Collections.Generic;

namespace evklid
{
    class Program
    {
        static void Main(string[] args)
        {
			string str1 = Console.ReadLine();
			string str2 = Console.ReadLine();
			int[,] arr = new int[2, str1.Length + 1];
			for (int i = 0; i <= str1.Length; i++)
				arr[0, i] = i;
			for (int i = 1; i <= str2.Length; i++)
				for (int j = 0; j <= str1.Length; j++)
					if (j == 0)
						arr[i % 2, j] = i;
					else if (str1[j - 1] == str2[i - 1])
						arr[i % 2, j] = arr[(i - 1) % 2, j - 1];
					else
						arr[i % 2, j] = 1 + Math.Min(arr[(i - 1) % 2, j], Math.Min(arr[i % 2, j - 1], arr[(i - 1) % 2, j - 1]));			
			Console.WriteLine(arr[str2.Length % 2, str1.Length]);
        }
    }
}
