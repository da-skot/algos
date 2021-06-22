/*
Коммивояжёр (фр. commis voyageur) – сбытовой посредник, который, перемещаясь по рынку, выполняет роль простого посредника или действует по поручению своего клиента (продавца). 
В капиталистическом обществе – разъездной торговый агент какой-нибудь фирмы, предлагающий покупателям товары по образцам и каталогам.

Баян – музыкальный инструмент, разновидность гармоники с полным хроматическим звукорядом на правой клавиатуре, басами и готовым аккордовым или готово-выборным аккомпанементом на левой. 
Назван в честь древнерусского певца-сказителя Бояна

Вам предлагается решить вариацию классической задачи, называемой задачей коммивояжёра.

Известен список городов, которые требуется посетить. Города представлены точками на плоскости, расстояние между городами определяется как обычное евклидово расстояние между точками. 
Требуется найти как можно более короткий маршрут, проходящий по всем городам. Заметьте, что возвращаться назад не нужно.

Задачу не обязательно решать точно. Но чем оптимальнее вы её решите, тем больше баллов получите.

Формат ввода
В первой строке ввода записано целое число N – количество городов в маршрутном листе коммивояжёра (2<=N<=5000). Города не совпадают.

В следующих N строках записано по два целых числа – координаты городов. Все координаты не превышают 10ˆ9 по абсолютному значению.

Формат вывода
Выведите N различных целых чисел от 1 до N – номера городов в порядке обхода.

Ваш балл по каждому тесту будет вычислен по следующей формуле: SCORE*10ˆ(−(Len/Best−1)

Где: SCORE – максимальное количество баллов за тест, Best – длина лучшего пути, найденного решением жюри или решением участника, Len – длина пути, предоставленного Вами.
*/

using System;
using System.Collections.Generic;

namespace comivoyajor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> cites = new List<City>();
            int n = Int32.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] str = Console.ReadLine().Split(' ');
                cites.Add(new City(Int32.Parse(str[0]),Int32.Parse(str[1])));
            }
            foreach (int x in twoOpt(cites))
                Console.Write($"{x+1} ");
            Console.ReadKey();
        }
        static List<int> twoOpt(List<City> cities)
        {
            List<int> opt = NearestInsertion(cities);
            int limit = 0;
            while (limit < 30)
            {
                for (int i = 1; i < opt.Count; i++)
                    for (int j = i + 1; j < opt.Count - 1; j++)
                        if (distance(cities[opt[i - 1]], cities[opt[j]])+distance(cities[opt[i]], cities[opt[j+1]]) < 
                            distance(cities[opt[i-1]], cities[opt[i]])+distance(cities[opt[j]], cities[opt[j+1]]))
                                opt = Swap(i, j, opt);
                limit++;
            }
            return opt;
        }
        static List<int> NearestInsertion(List<City> cities)
        {
            List<int> path = new List<int>();
            bool[] used = new bool[cities.Count];
            path.Add(0);
            used[0] = true;
            int used_count = 1, next_city;
            while (used_count != cities.Count)
            {
                if (used_count == 1)
                {
                    next_city = FindNearestNeighbor(0, cities, used);
                    path.Add(next_city);                    
                }
                else
                {
                    next_city = PickUnused(used);
                    path.Insert(FindMinimumDistance(next_city, cities, path), next_city);
                }
                used[next_city] = true;
                used_count++;
            }
            return path;
        }
        static int FindNearestNeighbor(int from, List<City> cities, bool[] used)
        {
            int NearNei = -1;
            for (int i = 0; i < cities.Count; i++)
                if (!used[i] && (NearNei == -1 || distance(cities[from], cities[i]) < distance(cities[from], cities[NearNei])))
                    NearNei = i;
            return NearNei;
        }
        static int PickUnused(bool[] used)
        {
            int i = 0;
            while(used[i])
            {
                i++;
            }
            return i;
        }
        static int FindMinimumDistance(int next_cite, List<City> cities, List<int> path)
        {
            int id = -1;
            double min_d = double.MaxValue;
            double d;
            for(int i = 0; i < path.Count-1; i++)
            {
                d = TriangularDistance(cities[path[i]], cities[path[i+1]], cities[next_cite]);
                if (d < min_d)
                {
                    min_d = d;
                    id = i + 1;
                }
            }
            return id;
        }
        static double TriangularDistance(City c1, City c2, City c3)
        {
            return distance(c1,c3) + distance(c3,c2) - distance(c1,c2);
        }

        static double distance(City from, City to)
        {
            return Math.Sqrt(Math.Pow((from.x-to.x),2)+Math.Pow((from.y-to.y),2));
        }
        static List<int> Swap(int a, int b, List<int> opt)
        {
            List<int> newOpt = new List<int>();
            for (int i = 0; i < a; i++)
                newOpt.Add(i);
            int d = 0;
            for (int i = a; i <= b; i++) 
            {
                newOpt.Add(opt[b-d]);
                d++;
            }
            for (int i = b + 1; b < opt.Count; i++)
                newOpt.Add(i);
            return newOpt;
        }
        
    }
    class City
    {
        public int x;
        public int y;
        public City(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
