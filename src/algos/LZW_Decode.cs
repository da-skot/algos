/*


Реализуйте декодирование в алгоритме LZW. Напомним алгоритм LZW. Рассмотрим строку s, состоящую из строчных латинских букв. 
Исходно имеется словарь, содержащий символы от a до z с кодами от 0 до 25, соответственно. 
Алгоритм поддерживает текущий буфер t, исходно инициализированный пустой строкой. Последовательно рассматриваются символы строки s. 
Пусть очередной символ строки равен c. Если строка t есть в словаре, то t присваивается tc и обработка символа завершается. 
Иначе выводится код t и строка tc помещается в словарь с минимальным свободным кодом. После этого t присваивается значение c и обработка символа завершается. 
После просмотра всех символов код оставшегося t также выводится.

Формат ввода
Первая строка ввода содержит число n количество кодов LZW-кодировании (1<=n<=1000). Вторая строка содержит n чисел вывод алгоритма LZW. Гарантируется, что ввод является корректным LZW-кодом некоторой строки длины не больше 1000.

Формат вывода
Выведите раскодированную строку.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LZW_Decode
{
    class Program
    {
        static void Main(string[] args)
        {
            Tries t = new Tries();
            int n = Int32.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(' ');
            for(int i = 0; i < str.Length; i++)
            {
                int code = Int32.Parse(str[i]);
                t.find(code);
            }
            Console.WriteLine(t.stroka());
        }
    }
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public int code;
    }
    class Tries
    {
        private Dictionary<int, string> codes = new Dictionary<int, string>();
        private int q = 0;
        private string w = "", k = "", wk = "";
        private string encode;
        TrieNode root = new TrieNode();
        public Tries()
        {
            for (int i = 97; i < 123; i++)
            {
                root.children.Add((char)i, new TrieNode());
                root.children[(char)i].code = q;
                codes.Add(q, ((char)i).ToString());
                q++;
            }
        }
        public bool findAdd(string str)
        {
            char[] chars = str.ToCharArray();
            TrieNode tempRoot = root;
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];
                }
                else
                {
                    tempRoot.children.Add(chars[i], new TrieNode());
                    tempRoot.children[chars[i]].code = q;
                    codes.Add(q, str);
                    q++;
                    return false;
                }
            }
            return true;
        }
        public void find(int code)
        {
            string sym = codes[code];
            encode += sym;
            bool flaq = true;
            if (w == "")
                w = sym;
            else
            {
                while (flaq)
                {
                    k = sym[0].ToString();
                    sym = sym.Remove(0, 1);
                    wk = w + k;
                    flaq = findAdd(wk);
                    if (!flaq)
                        w = wk[wk.Length - 1].ToString() + sym;
                    else
                        w = wk;
                }
            }
        }
        public string stroka()
        {
            return encode;
        }
    }
}
