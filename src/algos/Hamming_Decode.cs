/*
На вход подается сообщение (код Хэмминга), возможно с ошибками. Раскодировать сообщение и вывести его. Используется код (64, 57).

Формат ввода
Код Хэмминга, возможно с ошибками.

Формат вывода
Раскодированное сообщение.
*/

using System;
using System.Collections.Generic;

namespace Hamming_decode
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine().Remove(0,1);
            int[] code = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
                code[i] = Int32.Parse(str[i].ToString());
            decode(code);
        }
        static void decode(int[] code)
        {
            int mistake = -1;
            for (int i = 0; i < code.Length; i++)
            {
                if (Math.Log(i + 1, 2) % 1 != 0)
                    continue;
                int x = (int)Math.Log(i + 1, 2);
                int one_count = 0;
                for (int j = i + 2; j <= code.Length; ++j)
                    if ((j & (1 << x)) > 0)
                        if (code[j - 1] == 1)
                            one_count++;
                if (one_count % 2 == code[i])
                    continue;
                else
                    mistake += (i+1);
            }
            if (mistake != -1)
            {
                if (code[mistake] == 0)
                    code[mistake] = 1;
                else
                    code[mistake] = 0;
            }
            List<int> decode = new List<int>();
            for (int i = 0; i < code.Length; i++)
                if (Math.Log(i + 1, 2) % 1 != 0)
                    decode.Add(code[i]);
            Console.WriteLine(String.Join("",decode));
        }
    }
}
