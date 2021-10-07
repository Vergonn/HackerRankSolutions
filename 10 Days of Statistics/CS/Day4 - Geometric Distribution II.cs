using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        List<float> vals = Console.ReadLine().Trim().Split(' ').ToList().Select(arr => float.Parse(arr.ToString())).ToList();

        float p = vals[0] / vals[1];
        float result = 0;
        for (int i = 1; i <= 5; i++)
        {
            result += geometric(i, p);
        }
        Console.WriteLine(Math.Round(result, 3));
    }

    static float geometric(int n, float p)
    {
        return (float)(Math.Pow(1 - p, n - 1) * p);
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
}
