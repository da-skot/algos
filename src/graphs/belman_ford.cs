/*
Профессору Форду необходимо попасть на международную конференцию. Он хочет потратить на дорогу наименьшее количество денег, поэтому решил, 
что будет путешествовать исключительно ночными авиарейсами (чтобы не тратиться на ночевку в отелях), а днем будет осматривать достопримечательности тех городов, 
через которые он будет проезжать транзитом. Он внимательно изучил расписание авиаперелетов и составил набор подходящих авиарейсов, выяснив, 
что перелеты на выбранных направлениях совершаются каждую ночь и за одну ночь он не сможет совершить два перелета.

Теперь профессор хочет найти путь наименьшей стоимости, учитывая что до конференции осталось K ночей (то есть профессор может совершить не более K перелетов).

Формат ввода
В первой строке находятся числа N (количество городов), M (количество авиарейсов), K (количество оставшихся ночей), S (номер города, в котором живет профессор), F (номер города, в котором проводится конференция).

Ограничения: 2≤N≤100, 1≤M≤10ˆ5, 1≤K≤100, 1≤S≤N, 1≤F≤N.

Далее идет M строк, задающих расписание авиарейсов. i-я строка содержит три натуральных числа: Si, Fi и Pi, где Si - номер города, из которого вылетает i-й рейс, Fi - номер го-рода, в который прилетает i-й рейс, Pi - стоимость перелета i-м рейсом. 1≤Si≤N, 1≤Fi≤N, 1≤Pi≤10ˆ6.

Формат вывода
Выведите одно число - минимальную стоимость пути, подходящего для профессора. Если профессор не сможет за K ночей добраться до конференции, выведите число -1. 
*/

using System;
using System.Collections.Generic;

namespace belman_ford
{
    class Program
    {
        struct edge
        {
            public edge(int _a, int _b, int _cost)
            {
                a = _a;
                b = _b;
                cost = _cost;
            }
            public int a, b, cost;
        }
        static void Main(string[] args)
        {
            List<edge> e = new List<edge>();
            string[] str = Console.ReadLine().Split(' ');
            int n = Int32.Parse(str[0]);
            int m = Int32.Parse(str[1]);
            int k = Int32.Parse(str[2]);
            int s = Int32.Parse(str[3]) - 1;
            int f = Int32.Parse(str[4]) - 1;
            for (int i = 0; i < m; i++)
            {
                str = Console.ReadLine().Split(' ');
                if (Int32.Parse(str[0]) != Int32.Parse(str[1]))
                    e.Add(new edge(Int32.Parse(str[0]) - 1, Int32.Parse(str[1]) - 1, Int32.Parse(str[2])));
            }
            int[] d = new int[n];
            int[] used = new int[n];
            for (int i = 0; i < n; i++)
                d[i] = Int32.MaxValue;
            d[s] = 0;
            for (int i = 0; i < k-1; i++)
                for (int j = 0; j < e.Count; j++)
                    if ((d[e[j].a] != Int32.MaxValue) && (used[e[j].a] <= i) && (d[e[j].b] > d[e[j].a] + e[j].cost))
                    {
                        d[e[j].b] =  d[e[j].a] + e[j].cost;
                        used[e[j].b]++;
                    }
            for (int j = 0; j < e.Count; j++)
                if ((d[e[j].a] != Int32.MaxValue) && (e[j].b == f) && (d[e[j].b] > d[e[j].a] + e[j].cost))
                    d[e[j].b] = d[e[j].a] + e[j].cost;
            if (d[f] != Int32.MaxValue)
                Console.WriteLine(d[f]);
            else
                Console.WriteLine(-1);
        }
    }
}
