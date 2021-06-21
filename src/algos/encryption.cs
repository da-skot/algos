/*
Петя и Вася обменивались шифрованными сообщениями. Они брали некоторое слово, записанное маленькими латинскими буквами и переставляли в нем буквы. 
Антон перехватил одну из шифровок. У него есть несколько гипотез о том, что могло содержаться в шифровке.

Выведите те слова из списка Антона, шифром которых может являться перехваченное сообщение.
Формат ввода

В первой строке вводится текст перехваченного сообщения.

Во второй строке записано число N — количество слов – гипотез Антона (1≤N≤100). В следующих N строках записаны сами слова.

Каждое слово (как перехваченная шифровка, так и слова – гипотезы Антона) состоит только из маленьких латинских букв и имеет длину не более 200 символов.
Формат вывода

Выведите те слова – гипотезы, в результате шифрования которых могло получиться перехваченное сообщение. Слова должны быть выведены в том же порядке, в каком они вводятся.

Если ни одно слово не подходит, не нужно выводить ничего.

*/

using System;
using System.Collections.Generic;

namespace encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            byte[] arr = new byte[26];
            for (byte i = 0; i < str.Length; i++)
                arr[(byte)str[i] % 97]++;
            byte n = byte.Parse(Console.ReadLine());
            for (byte i = 0; i < n; i++)
                check(arr, Console.ReadLine());
            foreach (string hy in hyp)
                Console.WriteLine(hy);
        }
        private static void check(byte[] arr, string hypothesis)
        {
            byte[] a = new byte[26];
            for (byte i = 0; i < hypothesis.Length; i++)
                a[(byte)hypothesis[i] % 97]++;
            bool flaq = true;
            for (byte i = 0; i < arr.Length; i++)
                if (arr[i] != a[i])
                    flaq = false;
            if (flaq)
                hyp.Add(hypothesis);
        }
        private static List<string> hyp = new List<string>();
    }
}
