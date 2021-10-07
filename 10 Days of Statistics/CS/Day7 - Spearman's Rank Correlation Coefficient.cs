using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

class Solution
{
    public struct Pair
    {
        public int index;
        public double value;
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        List<double> xs = Console.ReadLine().Trim().Split(' ').Select(x => Convert.ToDouble(x)).ToList();
        List<double> ys = Console.ReadLine().Trim().Split(' ').Select(x => Convert.ToDouble(x)).ToList();

        Console.WriteLine(string.Format("{0:N3}", spearman(n, xs, ys)));
    }

    public static double spearman(int n, List<double> xs, List<double> ys)
    {
        int[] rankX = getRanks(xs);
        int[] rankY = getRanks(ys);

        double numerator = 0;
        for (int i = 0; i < n; i++)
        {
            numerator += Math.Pow(rankX[i] - rankY[i], 2);
        }
        numerator *= 6;

        return 1 - numerator / (n * (n * n) - 1);
    }

    public static int[] getRanks(List<double> arr)
    {
        int n = arr.Count;

        List<Pair> pairs = new List<Pair>();

        for (int i = 0; i < n; i++)
        {
            Pair item = new Pair();
            item.index = i;
            item.value = arr[i];

            pairs.Add(item);
        }
        pairs.Sort((s1, s2) => s1.value.CompareTo(s2.value));

        int[] ranks = new int[n];
        int rank = 1;
        foreach (Pair p in pairs)
        {
            ranks[p.index] = rank++;
        }
        return ranks;
    }
}
