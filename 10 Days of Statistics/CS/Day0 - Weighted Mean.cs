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
    /*
     * Complete the 'weightedMean' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY X
     *  2. INTEGER_ARRAY W
     */

    public static void weightedMean(List<int> X, List<int> W)
    {
        List<int> Y = new List<int>();
        for (int i = 0; i < X.Count; i++)
        {
            Y.Add(X[i] * W[i]);
        }

        double numerator = Y.Sum();
        double denominator = W.Sum();

        Console.WriteLine(Math.Round(numerator / denominator, 1).ToString(".0"));
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> vals = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(valsTemp => Convert.ToInt32(valsTemp)).ToList();

            List<int> weights = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(weightsTemp => Convert.ToInt32(weightsTemp)).ToList();

            Result.weightedMean(vals, weights);
        }
    }
}
