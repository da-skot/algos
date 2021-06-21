/*
Реализуйте кодирование в алгоритме LZW. Рассмотрим строку s, состоящую из строчных латинских букв. 
Исходно имеется словарь, содержащий символы от ‘a’ до ‘z’ с кодами от 0 до 25, соответственно. 
Алгоритм поддерживает текущий буфер t, исходно инициализированный пустой строкой. Последовательно рассматриваются символы строки s. 
Пусть очередной символ строки равен c.Если строка t есть в словаре, то t присваивается tc и обработка символа завершается. 
Иначе выводится код t и строка tc помещается в словарь с минимальным свободным кодом. После этого t присваивается значение c и обработка символа завершается. 
После просмотра всех символов код оставшегося t также выводится.
Формат ввода

Входной файл содержит строку, содержащую не более 1000 строчных букв латинского алфавита.
Формат вывода

Выведите коды, которые выводятся по мере выполнения алгоритма.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LZW_Encode
{
    class Program
    {
        static void Main(string[] args)
        {
            Tries t = new Tries();
            string str = Console.ReadLine();
            string w = "", k = "", wk = "";
            int ans = -1;
            for (int i = 0; i < str.Length; i++)
            {
                k = str[i].ToString();
                wk = w + k;
                int[] cd = t.findAdd(wk.ToCharArray());
                if (cd[0] == 0)
                {
                    Console.Write($"{cd[1]} ");
                    w = wk[wk.Length - 1].ToString();
                }
                else
                {
                    ans = cd[1];
                    w = wk;
                }
            }
            Console.Write(t.findAdd(w.ToCharArray())[1]);
        }
    }
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public int code;
    }
    class Tries
    {
        private int q = 0;
        TrieNode root = new TrieNode();
        public Tries()
        {
            for (int i = 97; i < 123; i++)
            {
                root.children.Add((char)i, new TrieNode());
                root.children[(char)i].code = q;
                q++;
            }
        }
        public int[] findAdd(char[] chars)
        {
            TrieNode tempRoot = root;
            int[] cd = new int[2] { 1, -1 };
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];
                    cd[1] = tempRoot.code;
                }
                else
                {
                    tempRoot.children.Add(chars[i], new TrieNode());
                    tempRoot.children[chars[i]].code = q;
                    q++;
                    cd[0] = 0;
                }
            }
            return cd;
        }
    }
}
