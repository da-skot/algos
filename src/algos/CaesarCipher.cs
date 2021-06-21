/*
В шифре Цезаря каждый символ заменяется на другой символ, третий по счету в алфавите после данного, с цикличность. 
То есть символ A заменяется на D, символ B - на E, символ C - на F, ..., символ Z на C. 
Аналогично строчные буквы заменяются на строчные буквы. Все остальные символы не меняются.

Дана строка, зашифруйте ее при помощи шифра Цезаря. 
Решение оформите в виде функции CaesarCipher (S, k), возвращающей новую строку. <сode>S — исходная строка, k — величина сдвига. Функцию нужно вызывать со значением k=3.

Указание: сделайте функцию CaesarCipherChar(c, k), шифрующую один символ.

*/

using System;

namespace Caesar
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(CaesarCipher(str, 3));
        }
        static private string CaesarCipher(string S, int k)
        {
            string str = "";
            for (int i = 0; i < S.Length; i++)
                str += CaesarCipherChar(S[i], k);
            return str;
        }
        static private char CaesarCipherChar(char c, int k)
        {
            byte index = (byte)c;
            if (index>=65 && index<=90)
            {
                index += 3;
                if (index > 90)
                    index = (byte)(64 + (index % 90));
                return (char)index;
            }
            if (index >= 97 && index <= 122)
            {
                index += 3;
                if (index > 122)
                    index = (byte)(96 + (index % 122));
                return (char)index;
            }
            return c;
        }
    }
}
