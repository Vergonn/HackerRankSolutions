using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    public static void Main(String[] args) {
        
        List<int> m = Console.ReadLine().Trim().Split(' ').Select(num => Convert.ToInt32(num)).ToList().ToList();
        
        double[,] X = new double[m[1], m[0] + 1];
        double[,] Y = new double[m[1], 1];
        for (int row = 0; row < m[1]; row++) 
        {
            X[row, 0] = 1;
            List<double> s = Console.ReadLine().Trim().Split(' ').Select(num => Convert.ToDouble(num)).ToList();
            for (int col = 1; col <= m[0]; col++) 
            {
                X[row, col] = s[col-1];
            }
            Y[row, 0] = s[s.Count-1];
        }

        /* Calculate B */
        double[,] xtx = multiply(transpose(X), X);
        double[,] xtxInv = invert(xtx);
        double[,] xty = multiply(transpose(X), Y);
        double[,] B = multiply(xtxInv, xty);
        
        int sizeB = B.GetLength(0);
        
        /* Calculate and print values for the "q" feature sets */
        int q = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < q; i++) 
        {
            double result = B[0, 0];
            List<double> s = Console.ReadLine().Trim().Split(' ').Select(num => Convert.ToDouble(num)).ToList();
            
            for (int row = 1; row < sizeB; row++) 
            {
                result += s[row-1] * B[row, 0];
            }
            Console.WriteLine(result.ToString(".0#"));
        }
    }
    
    /* Multiplies 2 matrices in O(n^3) time */
    public static double[,] multiply(double[,] A, double[,] B) {
        int aRows = A.GetLength(0);
        int aCols = A.GetLength(1);
        int bRows = B.GetLength(0);
        int bCols = B.GetLength(1);
        
        double[,] C = new double[aRows, bCols];
        int cRows = C.GetLength(0);
        int cCols = C.GetLength(1);
        
        for (int row = 0; row < cRows; row++)
            for (int col = 0; col < cCols; col++)
                for (int k = 0; k < aCols; k++)
                    C[row, col] += A[row, k] * B[k, col];
                    
        return C;
    }
    
    public static double[,] transpose(double[,] matrix) {
        /* Create new array with switched dimensions */
        int originalRows = matrix.GetLength(0);
        int originalCols = matrix.GetLength(1);
        int rows = originalCols;
        int cols = originalRows;
        double[,] result = new double[rows, cols];
        
        /* Fill our new 2D array */
        for (int row = 0; row < originalRows; row++)
            for (int col = 0; col < originalCols; col++)
                result[col, row] = matrix[row, col];
                
        return result;
    }
    
    public static double[,] invert(double[,] a) 
    {
        int n = a.GetLength(0);
        double[,] x = new double[n, n];
        double[,] b = new double[n, n];
        int[] index = new int[n];
        for (int i=0; i<n; ++i) 
            b[i, i] = 1;
 
         // Transform the matrix into an upper triangle
        gaussian(a, index);
 
         // Update the matrix b[i][j] with the ratios stored
        for (int i=0; i<n-1; ++i)
            for (int j=i+1; j<n; ++j)
                for (int k=0; k<n; ++k)
                    b[index[j], k] -= a[index[j], i]*b[index[i], k];
 
         // Perform backward substitutions
        for (int i=0; i<n; ++i) 
        {
            x[n-1, i] = b[index[n-1], i]/a[index[n-1], n-1];
            for (int j=n-2; j>=0; --j) 
            {
                x[j, i] = b[index[j], i];
                for (int k=j+1; k<n; ++k) 
                {
                    x[j, i] -= a[index[j], k]*x[k, i];
                }
                x[j, i] /= a[index[j], j];
            }
        }
        return x;
    }
 
    public static void gaussian(double[,] a, int[] index) 
    {
        int n = index.Length;
        double[] c = new double[n];
 
         // Initialize the index
        for (int i=0; i<n; ++i) 
            index[i] = i;
 
         // Find the rescaling factors, one from each row
        for (int i=0; i<n; ++i) 
        {
            double c1 = 0;
            for (int j=0; j<n; ++j) 
            {
                double c0 = Math.Abs(a[i, j]);
                if (c0 > c1) c1 = c0;
            }
            c[i] = c1;
        }
 
         // Search the pivoting element from each column
        int k = 0;
        for (int j=0; j<n-1; ++j) 
        {
            double pi1 = 0;
            for (int i=j; i<n; ++i) 
            {
                double pi0 = Math.Abs(a[index[i], j]);
                pi0 /= c[index[i]];
                if (pi0 > pi1) 
                {
                    pi1 = pi0;
                    k = i;
                }
            }
 
           // Interchange rows according to the pivoting order
            int itmp = index[j];
            index[j] = index[k];
            index[k] = itmp;
            for (int i=j+1; i<n; ++i)     
            {
                double pj = a[index[i], j]/a[index[j], j];
 
                // Record pivoting ratios below the diagonal
                a[index[i], j] = pj;
 
                // Modify other elements accordingly
                for (int l=j+1; l<n; ++l)
                    a[index[i], l] -= pj*a[index[j], l];
            }
        }
    }
}
