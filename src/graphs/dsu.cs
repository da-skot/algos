/*
В неориентированный взвешенный граф добавляют ребра. Напишите программу, которая в некоторые моменты находит сумму весов ребер в компоненте связности.

Формат ввода
В первой строке записано два числа n и m (1≤n,m≤10ˆ6) - количество вершин в графе и количество производимых добавлений и запросов. 
Далее следует m строк с описанием добавления или запроса. Каждая строка состоит из двух или четырех чисел. Первое из чисел обозначает код операции. 
Если первое число 1, то за ним следует еще три числа x, y, w. Это означает, что в граф добавляется ребро из вершины x в вершину y веса w. (1≤x<y≤n, 1≤w≤10ˆ3). 
Кратные ребра допустимы. Если первое число 2, то за ним следует ровно одно число x. 
Это означает, что необходимо ответить на вопрос, какова сумма ребер в компоненте связности, которой принадлежит вершина x (1≤x≤n).

Формат вывода
Для каждой операции с кодом 2 выведите ответ на поставленную задачу. Ответ на каждый запрос выводите на отдельной строке.
*/
using System;

namespace Disjoint_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = Int32.Parse(str[0]);
            int m = Int32.Parse(str[1]);
            DSU dsu = new DSU(n);
            for(int i = 0; i < m; i++)
            {
                str = Console.ReadLine().Split(' ');
                if (str[0] == "2")
                    Console.WriteLine(dsu.sum(Int32.Parse(str[1])-1));
                else
                {
                    int x = Int32.Parse(str[1])-1;
                    int y = Int32.Parse(str[2])-1;
                    int len = Int32.Parse(str[3]);
                    dsu.Unite1(x,y,len);
                }
            }
        }
    }
    class DSU
    {
        private int[] p;
        private int[] size;
        private int[] rank;
        public DSU(int n)
        {
            p = new int[n];
            size = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
                MakeSet(i);
        }
        private void MakeSet(int x)
        {
            p[x] = x;
            rank[x] = 0;
        }
        public int Find(int x)
        {
            if (p[x] == x) return x;
            return p[x] = Find(p[x]);
        }
        public void Unite1(int x, int y, int len)
        {
            x = Find(x);
            y = Find(y);
            if (rank[x] < rank[y])
            {
                p[x] = y;
                size[y] += len;
            }
            else
            {
                p[y] = x;
                size[x] += len;
                if (rank[x] == rank[y])
                    ++rank[x];
            }
        }
        public int sum(int x)
        {
            return size[p[x]];
        }
    }
}
