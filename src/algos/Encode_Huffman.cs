/*
По данной непустой строке s длины не более 104, состоящей из строчных букв латинского алфавита, постройте оптимальный беспрефиксный код.

Задача из курса «Алгоритмы: теория и практика. Методы»: https://stepik.org/course/217/syllabus

Формат ввода
В первой строке входных данных непустая строка s.
Формат вывода
В первой строке выведите количество различных букв k, встречающихся в строке, и размер получившейся закодированной строки.

В следующих k строках запишите коды букв в формате letter: code. В последней строке выведите закодированную строку.

*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Huffman_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Huff huff = new Huff(Console.ReadLine());
        }
    }
    public class Node
    {
        public char Symbol;
        public int Freq;
        public Node Right;
        public Node Left;

        public List<bool> Traverse(char symbol, List<bool> data)
        {
            if (Right == null && Left == null)
            {
                if (symbol.Equals(this.Symbol))
                    return data;
                else
                    return null;
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;
                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);
                    left = Left.Traverse(symbol, leftPath);
                }
                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = Right.Traverse(symbol, rightPath);
                }
                if (left != null)
                    return left;
                else
                    return right;
            }
        }
    }
    public class Huff
    {
        private Node Root;
        private Dictionary<char, int> Frequencies = new Dictionary<char, int>();
        private Dictionary<char, List<bool>> Symbols = new Dictionary<char, List<bool>>();

        public Huff(string str)
        {
            calcFreq(str);
            Build();
            Encode();
            Output(str);
        }

        public void calcFreq(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Frequencies.ContainsKey(str[i]))
                    Frequencies.Add(str[i], 0);
                Frequencies[str[i]]++;
            }
        }

        public void Build()
        {
            List<Node> nodes = new List<Node>();
            foreach (KeyValuePair<char, int> symbol in Frequencies)
                nodes.Add(new Node()
                { 
                    Symbol = symbol.Key, 
                    Freq = symbol.Value 
                });
            while (nodes.Count > 1)
            {
                List<Node> orderedNodes = nodes.OrderBy(node => node.Freq).ToList<Node>();
                Node left = orderedNodes[0];
                Node right = orderedNodes[1];
                Node parent = new Node()
                {
                    Symbol = '#',
                    Freq = left.Freq + right.Freq,
                    Left = left,
                    Right = right
                };
                nodes.Remove(left);
                nodes.Remove(right);
                nodes.Add(parent);
            }
            Root = nodes[0];
        }

        public void Encode()
        {
            foreach (char i in Frequencies.Keys)
                if (Frequencies.Count != 1)
                    Symbols.Add(i, Root.Traverse(i, new List<bool>()));
                else
                    Symbols.Add(i, new List<bool>() {false});
        }

        public void Output(string str)
        {            
            List<bool> ans = new List<bool>();
            for (int i = 0; i < str.Length; i++)
            {
                ans.AddRange(Symbols[str[i]]);
            }
            Console.WriteLine($"{Frequencies.Count} {ans.Count}");
            foreach (KeyValuePair<char, List<bool>> symbol in Symbols)
            {
                Console.Write(symbol.Key+": ");
                foreach (bool i in symbol.Value)
                    Console.Write(i ? 1 : 0);
                Console.WriteLine();
            }
            foreach (bool i in ans)
                Console.Write(i ? 1 : 0); 
        }
    }
}
