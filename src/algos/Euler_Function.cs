/*
Дано натуральное число n<=10ˆ9, определите количество натуральных чисел, меньших n и взаимно простых с n. Это число обозначается f(n) и называется функцией Эйлера. 
*/

using System;
namespace Euler_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine(euler_fun(n));
        }
        private static int euler_fun(int n)
        {
            int f = n;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0)
                {
                    while (n % i == 0)
                        n /= i;
                    f -= f / i;
                }
            if (n > 1)
                f -= f / n;
            return f;
        }
    }
}
