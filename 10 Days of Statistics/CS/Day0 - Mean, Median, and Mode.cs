using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    public static double mean(List<int> arr, int n)
    {
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
        }
        double ans = (double)sum / (long)n;
        return ans;
    }

    public static double median(List<int> arr, int n)
    {
        arr.Sort();
        int mid = n / 2;
        double ans = ((double)arr[mid] + (double)arr[mid - 1]) / 2;
        return ans;
    }

    public static int mode(List<int> X, int n)
    {
        int mode = 0, temp, count, max = 0;
        for (int i = 0; i < n; i++)
        {
            temp = X[i];
            count = 0;
            for (int j = 0; j < n; j++)
            {
                if (temp == X[j])
                {
                    count++;
                }
                if (count > max)
                {
                    max = count;
                    if (max == 1)
                    {
                        mode = X[0];
                    }
                    mode = temp;
                }
            }
        }
        return mode;
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        List<int> numbers = Console.ReadLine().Trim().Split(' ').Select(num => Convert.ToInt32(num)).ToList();

        Console.WriteLine(mean(numbers, n));

        Console.WriteLine(median(numbers, n));

        Console.WriteLine(mode(numbers, n));
    }
}
