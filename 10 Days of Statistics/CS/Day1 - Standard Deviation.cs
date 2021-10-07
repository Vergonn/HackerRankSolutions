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
    public static double mean(List<int> arr)
    {
        long sum = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            sum += arr[i];
        }
        double ans = (double)sum / (long)arr.Count;
        return ans;
    }

    /*
     * Complete the 'stdDev' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void stdDev(List<int> arr)
    {
        double m = mean(arr);
        double comp = 0.0;

        for (int i = 0; i < arr.Count; i++)
            comp += Math.Pow(arr[i] - m, 2);

        double fin = Math.Round(Math.Sqrt(comp / arr.Count), 1);
        Console.WriteLine(fin.ToString(".0"));
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> vals = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(valsTemp => Convert.ToInt32(valsTemp)).ToList();

        Result.stdDev(vals);
    }
}
