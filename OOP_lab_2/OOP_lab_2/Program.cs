using System;
using System.Drawing;
using System.Linq;
using System.Numerics;

class lab2
{
    static void Main(string[] args)
    {

        Console.WriteLine("Task 1.1");
        task_1_1();
        Console.WriteLine("Task 1.2");
        task_1_2();
        Console.WriteLine("Task 1.3");
        task_1_3(2, 6);
        Console.WriteLine("Task 2.1");
        task_2_1();
        Console.WriteLine("Task 2.2");
        task_2_2();
        Console.WriteLine("Task 2.3");
        task_2_3();
    }
   
    public static void task_1_1()
    {
        int n = 10;
        double[] x = new double[n];
        double[] y = new double[n];
        double[] z = new double[2 * n];
        int z_index = 0; 
        

        for (int i = 0; i < n; i++)
        {
            Random rnd = new Random();
            x[i] = rnd.Next(0, 50)-25;
            y[i] = rnd.Next(0, 50)-25;
        }
        Console.WriteLine("x = [{0}]", string.Join(", ", x));
        Console.WriteLine("y = [{0}]", string.Join(", ", y));

        for (int i = 0; i < n; i++) 
        {
            if (x[i] > 0)
            {
                z[z_index] = x[i];
                z_index++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (y[i] > 0)
            {
                z[z_index] = y[i];
                z_index++;
            }
        }
        double[] result= new double[z_index];
        for (int i = 0; i < z_index; i++)
        {
            result[i] = z[i];
        }


         Console.WriteLine("z = [{0}]", string.Join(", ", result));
    }

    public static void task_1_2()
    {
        int n = 5;
        double[] a = new double[n];
        double[] b = new double[n];
        double[] c = new double[n];
        double[] result = new double[n];
        


        for (int i = 0; i < n; i++)
        {
            Random rnd = new Random();
            a[i] = rnd.Next(0, 10) - 5;
            b[i] = rnd.Next(0, 10) - 5;
            c[i] = rnd.Next(0, 10) - 5;
        }
        Console.WriteLine("a = [{0}]", string.Join(", ", a));
        Console.WriteLine("b = [{0}]", string.Join(", ", b));
        Console.WriteLine("c = [{0}]", string.Join(", ", c));

        for (int i = 0; i < n; i++) 
        {
            result[i] = 2 * (a[i] + c[i]) - b[i];
        }

        Console.WriteLine("result = [{0}]", string.Join(", ", result));
    }

    public static void task_1_3(int a, int b)
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        
        int[] result = new int[arr.Length];
        int index = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= a && arr[i] <= b)
            {
                result[index] = arr[i];
                index++;
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < a || arr[i] > b)
            {
                result[index] = arr[i];
                index++;
            }
        }

        Console.WriteLine("Original array: [{0}]", string.Join(", ", arr));
        Console.WriteLine("Created array: [{0}]", string.Join(", ", result));
    }

    public static void task_2_1()
    {
        int[,] matrix = new int[,] {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };
        int length = matrix.GetLength(0);
        int length1 = matrix.GetLength(1);
        int k = 3;
        int[,] temp = new int[length,length1];
        int[,] temp1 = new int[length, length1];


        Console.WriteLine("Initial Matrix:");
        PrintMatrix(matrix);

        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            for (int i = 0; i < k; i ++)
            {
                temp[j,i] = matrix[j,i];

            }
        }
        int index = 0, index1 =0;

        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            index = 0;
            for (int i = k; i < matrix.GetLength(1); i++)
            {
                temp1[j,index] = matrix[j,i];
                index++;
            }
        }
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            for (int i = 0; i < matrix.GetLength(1)-k; i++)
            {
                matrix[j, i] = temp1[j, i];  
            }
        }
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            index1 = 0;
            for (int i = matrix.GetLength(1) - k; i < matrix.GetLength(1); i++)
            {
                matrix[j, i] = temp[j, index1];
                index1++;
            }
        }
        

/*
        for (int j = 0; j < matrix.GetLength(0); j ++)
        {
            for (int i = 0; i < matrix.GetLength(1); i += 2)
            {
                int[,] temp = new int[1, 1];
                temp[0, 0] = matrix[j, i];
                matrix[j, i] = matrix[j , i + 1];
                matrix[j, i + 1] = temp[0, 0];
            }
        }*/
         
        Console.WriteLine("Resulting matrix shift "+k+" times: ");
        PrintMatrix(matrix);
    }

    public static void task_2_2()
    {
        int[,] matrix = {
                             {3,5,0,8,1,0},
                             {2,1,0,9,5,0},
                             {0,0,0,0,0,0},
                             {7,8,0,3,3,0},
                             {0,0,0,0,0,0},
                             {9,2,0,9,5,0},
                             {0,0,0,0,0,0},
                        };
        
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        
        List<int> ls1 = new List<int>();
        List<int> ls2 = new List<int>();

        Console.WriteLine("Original matrix");
   
        for (int i = 0; i < rows; ++i)
        {
            bool check = false;
            for (int j = 0; j < cols; ++j)
            {
                Console.Write("  " + matrix[i, j]);
                if (matrix[i, j] != 0) check = true;
            }
            if (!check) ls1.Add(i);
            Console.WriteLine();
        }
       
        for (int i = 0; i < cols; ++i)
        {
            bool check = false;
            for (int j = 0; j < rows; ++j)
            {
                if (matrix[j, i] != 0) check = true;
            }
            if (!check) ls2.Add(i);

        }
     
        Console.WriteLine("Compact matrix:");

        for (int i = 0; i < rows; ++i)
        {
            if (!ls1.Contains(i))
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (!ls2.Contains(j))
                    {
                        Console.Write("  " + matrix[i, j]);
                    }

                }

            }
            if (!ls1.Contains(i))
                Console.WriteLine();
        }
    }

    public static void task_2_3()
    {
        int[][] matrix = new int[][]
        {
             new int[] { -1, -2, -3 },
             new int[] { 4, 5, 6 },
             new int[] { -7, -8, 9 }
        };

        int row = -1;
        for (int i = 0; i < matrix.Length; i++)
        {
            bool containsPositive = false;
            for (int j = 0; j < matrix.Length; j++)
            {
                if (matrix[i][j] > 0)
                {
                    containsPositive = true;
                    break;
                }
            }
            if (containsPositive)
            {
                row = i;
                break;
            }
        }
        Console.WriteLine("Matrix:");
        for (int i = 0; i < matrix.Length; i++)
        {
            for(int j =0; j<matrix.Length; j++)
            {
                Console.Write(" "+matrix[i][j]);
            }
            Console.WriteLine();
        }
        row++;
        if (row >= 0)
        {
            Console.WriteLine("The first row with positive number is: " + row);
        }
        else
        {
            Console.WriteLine("Matrix didn't have positive number elements(");
        }
    }
   
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}