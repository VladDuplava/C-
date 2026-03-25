using System;

class ArrayTaskFull
{
    static void Main()
    {
        // 1. Запуск автоматичних тестів
        RunTests();

        Console.WriteLine("\n=== ЗАВДАННЯ 1: ОДНОВИМІРНИЙ МАСИВ ===");
        Console.Write("Введіть розмірність масиву: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            double[] array1D = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                array1D[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Середнє арифметичне (1D): {CalculateAverage1D(array1D):F2}");
        }

        Console.WriteLine("\n=== ЗАВДАННЯ 2: ДВОВИМІРНИЙ МАСИВ ===");
        Console.Write("Введіть кількість рядків: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців: ");
        int cols = int.Parse(Console.ReadLine());

        if (rows > 0 && cols > 0)
        {
            double[,] matrix2D = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Елемент [{i},{j}]: ");
                    matrix2D[i, j] = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine($"Середнє арифметичне (2D): {CalculateAverage2D(matrix2D):F2}");
        }
        
        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }

    // Методи обчислення
    public static double CalculateAverage1D(double[] array)
    {
        if (array.Length == 0) return 0;
        double sum = 0;
        foreach (var item in array) sum += item;
        return sum / array.Length;
    }

    public static double CalculateAverage2D(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double sum = 0;
        foreach (var item in matrix) sum += item;
        return sum / (rows * cols);
    }

    // Тести
    static void RunTests()
    {
        Console.WriteLine("--- ЗАПУСК АВТОМАТИЧНИХ ТЕСТІВ ---");
        
        // Тест 1D
        double[] test1D = { 2, 4, 6 }; // (2+4+6)/3 = 4
        Assert(CalculateAverage1D(test1D), 4.0, "Тест 1D (2,4,6)");

        // Тест 2D
        double[,] test2D = { { 1, 5 }, { 2, 8 } }; // (1+5+2+8)/4 = 4
        Assert(CalculateAverage2D(test2D), 4.0, "Тест 2D (матриця 2x2)");
        
        Console.WriteLine("----------------------------------");
    }

    static void Assert(double actual, double expected, string name)
    {
        if (Math.Abs(actual - expected) < 0.01)
            Console.WriteLine($"[OK] {name}");
        else
            Console.WriteLine($"[ПОМИЛКА] {name}: очікували {expected}, отримали {actual}");
    }
}
