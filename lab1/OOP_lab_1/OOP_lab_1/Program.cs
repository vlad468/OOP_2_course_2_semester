using System;
class lab1
{
    static void Main(string[] args)
    {
        int choose=0; bool loop = true;
        TOpMatrix to1 = new TOpMatrix(0) ;
        TOpMatrix to2 = new TOpMatrix(0);
        while (loop)
        {
            Console.WriteLine("1. Create a first matrix");
            Console.WriteLine("2. Create a second matrix");
            Console.WriteLine("3. Make second matrix from first one");
            Console.WriteLine("4. Matrix set, JUMP TO OPERATIONS");
            Console.WriteLine("5. Exit");

            try
            {
                choose = int.Parse(Console.ReadLine());
                if (choose <= 0 && choose > 5)
                {
                    throw new Exception("Wrong enter");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter the valid num");
            }

            switch (choose)
            {
                case 1:
                    int size, init = 0;
                    Console.WriteLine("Enter size of matrix");
                    try
                    {
                        size = int.Parse(Console.ReadLine());
                        to1 = new TOpMatrix(size);

                        Console.WriteLine("Enter the matrix filling method");
                        Console.WriteLine("1. Manual");
                        Console.WriteLine("2. Random");
                        init = int.Parse(Console.ReadLine());
                        if (init > 2 && init < 1)
                        {
                            throw new Exception("Wrong enter");
                        }
                        switch (init)
                        {
                            case 1:
                                to1.setMatrix();
                                break;

                            case 2:
                                to1.autoSetMatrix();
                                break;
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please enter the valid num");
                    }
                    break;
                case 2:

                    Console.WriteLine("Enter size of matrix");
                    try
                    {
                        size = int.Parse(Console.ReadLine());
                        to2 = new TOpMatrix(size);

                        Console.WriteLine("Enter the matrix filling method");
                        Console.WriteLine("1. Manual");
                        Console.WriteLine("2. Random");
                        init = int.Parse(Console.ReadLine());
                        if (init > 2 && init < 1)
                        {
                            throw new Exception("Wrong enter");
                        }
                        switch (init)
                        {
                            case 1:
                                to2.setMatrix();
                                break;

                            case 2:
                                to2.autoSetMatrix();
                                break;
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please enter the valid num");
                    }
                    break;
                case 3:
                    to2 = new TOpMatrix(to1);
                    break;
                case 4:
                    if(to1.isEmpty() && to2.isEmpty())
                    {
                        Console.WriteLine("One or two matrix isn't set");
                    }
                    else { loop = false; }
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong operation");
                    break;

            }
        }

        //Second switch
        Console.Clear();
        loop = true; choose = 0;
        TMatrix res = new TMatrix(0);
        while (loop)
        {
            Console.WriteLine("1. Print matrix");
            Console.WriteLine("2. Add matrix");
            Console.WriteLine("3. Subtract matrix");
            Console.WriteLine("4. Multiply matrix");
            Console.WriteLine("5. Min/Max/Sum of result matrix");
            Console.WriteLine("6.Exit");
            try
            {
                choose = int.Parse(Console.ReadLine());
                if (choose <= 0 && choose > 6)
                {
                    throw new Exception("Wrong enter");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter the valid num");
            }
            switch (choose)
            {
                case 1:
                    int choise = 0;
                    Console.Clear();
                    Console.WriteLine("1. Print first matrix");
                    Console.WriteLine("2. Print second matrix");
                    Console.WriteLine("3. Print res matrix");
                    Console.WriteLine("4. Print all matrix");
                    try
                    {
                        choise = int.Parse(Console.ReadLine());
                        if (choise <= 0 && choise > 4)
                        {
                            throw new Exception("Wrong enter");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please enter the valid num");
                    }
                    switch (choise) {
                        case 1:
                            to1.printMatrix();
                            break;
                        case 2:
                            to2.printMatrix(); break;
                        case 3:
                            res.printMatrix(); break;
                        case 4:
                            to1.printMatrix();
                            to2.printMatrix();
                            res.printMatrix();
                            break;
                    }
            

                break;
                case 2:
                    res = new TMatrix(to1 + to2);
                    break;
                case 3:
                    res = new TMatrix(to1 - to2);
                    break;
                case 4:
                    res = new TMatrix(to1 * to2);
                    break;
                case 5:
                    int max, min, sum;
                    if (res.isEmpty())
                    {
                        Console.WriteLine("Result matrix isn't set");
                    }
                    else
                    {
                        max = res.findMax();
                        min = res.findMin();
                        sum = res.sumOfElements();
                        Console.WriteLine("Minimal number is: " + min);
                        Console.WriteLine("Maximal number is: " + max);
                        Console.WriteLine("Sum of the all elements in matrix: " + sum);
                    }
                    break;
                case 6: 
                    Environment.Exit(0);
                    break; 
                default: Console.WriteLine("Wrong insert");
                    break;
            }
        }

    }
}

class TMatrix {
    protected int size;
    protected int[,] matrix;

    public TMatrix() { }

    public TMatrix(int size) { 
        this.size = size;
        matrix= new int[size, size];
    }

    public TMatrix(TMatrix matrix)
    {
        this.size = matrix.size;
        this.matrix = matrix.matrix;
    }

    public bool isEmpty()
    {
        bool res = true;
        if(size > 0)
        {
            res = false;
        }
        return res;
        
    }

    public void setMatrix()
    {
        int k = 0;
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                {
                    int a = 0;
                    Console.WriteLine("Enter  " + k + " element of matrix: ");
                    try
                    {
                        a = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please enter the valid num");
                    }

                    matrix[i,j] = a;
                    k++;

                }
            }
    }

    public void autoSetMatrix()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                {
                    int a;
                    Random rnd = new Random();
                    a = rnd.Next(0, 10);

                    matrix[i,j] = a;

                }
            }
        Console.WriteLine("Successfully set");
    }

    public void printMatrix()
    {
        Console.WriteLine("The resulting matrix: ");
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                Console.Write(matrix[i,j]+"\t");

            }
            Console.WriteLine();

        } 
    }

    public int findMax()
    {
        int max = int.MinValue;
        for (int i = 0; i < size; i++){
            for (int j = 0; j < size; j++) {
                if (matrix[i,j]> max)
                {
                    max = matrix[i,j];
                }

            }
        }
                
                
         return max;
    }

    public int findMin()
    {
        int min = int.MaxValue;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }

            }
        }

        return min;
    }

    public int sumOfElements()
    {
        int sum = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                sum+= matrix[i, j];
            }
        }

        return sum;
    }

}

class TOpMatrix : TMatrix
{
    public TOpMatrix(int size) : base(size)
    {
    }

    public TOpMatrix(TOpMatrix matrix) {
        this.size = matrix.size;
        this.matrix = matrix.matrix;
    }

    public static TOpMatrix operator +(TOpMatrix a, TOpMatrix b) {
        if(a.size != b.size) {
            Console.WriteLine("Error, matrix have different sizes");
            return new TOpMatrix(0);
        }
        int size = a.size;
        TOpMatrix res = new TOpMatrix(a.size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                res.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
            }
        }
        return res;
    }

    public static TOpMatrix operator -(TOpMatrix a, TOpMatrix b)
    {
        if (a.size != b.size)
        {
            Console.WriteLine("Error, matrix have different sizes");
            return new TOpMatrix(0);
        }
        int size = a.size;
        TOpMatrix res = new TOpMatrix(a.size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                res.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
            }
        }
        return res;
    }

    public static TOpMatrix operator *(TOpMatrix a, TOpMatrix b)
    {
        if (a.size != b.size)
        {
            Console.WriteLine("Error, matrix have different sizes");
            return new TOpMatrix(0);
        }
        int size = a.size;
        TOpMatrix res = new TOpMatrix(size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                res.matrix[i, j] = 0;

                for (int k = 0; k < size; k++)
                {
                    res.matrix[i, j] += a.matrix[i, k] * b.matrix[k, j];
                }
            }
        }
        return res;
    }
}
