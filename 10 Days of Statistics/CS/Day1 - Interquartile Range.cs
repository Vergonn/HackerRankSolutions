using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static double median(List<int> arr)
    {
        arr.Sort();
        int mid = arr.Count / 2;
        if (arr.Count % 2 == 1)
            return (double)arr[mid];
        else
            return ((double)arr[mid] + (double)arr[mid - 1]) / 2;
    }

    /*
     * Complete the 'interQuartile' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY values
     *  2. INTEGER_ARRAY freqs
     */

    public static void interQuartile(List<int> values, List<int> freqs)
    {
        List<int> arr = new List<int>();
        for (int i = 0; i < values.Count; i++)
            for (int j = 0; j < freqs[i]; j++)
                arr.Add(values[i]);

        arr.Sort();

        int middle = arr.Count / 2;
        double lm = median(arr.GetRange(0, middle));
        double um = median(arr.GetRange((arr.Count % 2 != 0) ? middle + 1 : middle, middle));

        double fin = Math.Round(um - lm, 1);

        Console.WriteLine(fin.ToString(".0"));
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> val = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(valTemp => Convert.ToInt32(valTemp)).ToList();

        List<int> freq = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(freqTemp => Convert.ToInt32(freqTemp)).ToList();

        Result.interQuartile(val, freq);
    }
}
