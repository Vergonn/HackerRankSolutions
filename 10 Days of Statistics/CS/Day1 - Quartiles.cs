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
        {
            return (double)arr[mid];
        }
        else
        {
            return ((double)arr[mid] + (double)arr[mid - 1]) / 2;
        }
    }

    /*
     * Complete the 'quartiles' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> quartiles(List<int> arr)
    {
        arr.Sort();
        int arrmiddle = arr.Count / 2;
        int ft = (arr.Count % 2 == 1) ? arrmiddle : arrmiddle + 1;
        int lt = (arr.Count % 2 == 0) ? arrmiddle : arrmiddle + 1;

        List<int> firstquart = arr.GetRange(0, ft);
        List<int> lastquart = arr.GetRange(lt, arrmiddle);

        List<int> medians = new List<int>() {
            (int)median(firstquart),
            (int)median(arr),
            (int)median(lastquart)
        };

        return medians;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> data = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(dataTemp => Convert.ToInt32(dataTemp)).ToList();

        List<int> res = Result.quartiles(data);

        textWriter.WriteLine(String.Join("\n", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
