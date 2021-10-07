using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        List<string> vals = Console.ReadLine().Trim().Split(' ').ToList();
        float p = float.Parse(vals[0]);
        float n = float.Parse(vals[1]);

        float result = 0;
        for (int i = 0; i < 3; i++)
        {
            result += b(i, n, p / 100);
        }
        Console.WriteLine(Math.Round(result, 3));

        result = 0;
        for (int i = 2; i < n + 1; i++)
        {
            result += b(i, n, p / 100);
        }
        Console.WriteLine(Math.Round(result, 3));
    }

    static float fact(float n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * fact(n - 1);
        }
    }

    static float comb(float n, float x)
    {
        return fact(n) / (fact(x) * fact(n - x));
    }

    static float b(float x, float n, float p)
    {
        return (float)(comb(n, x) * Math.Pow(p, x) * Math.Pow((1 - p), (n - x)));
    }
}
