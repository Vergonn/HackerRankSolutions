using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        List<string> vals = Console.ReadLine().Trim().Split(' ').ToList();
        float l = float.Parse(vals[0]);
        float r = float.Parse(vals[1]);
        float odds = l / r;

        float result = 0;
        for (int i = 3; i < 7; i++)
        {
            result += b(i, 6, odds / (1 + odds));
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
