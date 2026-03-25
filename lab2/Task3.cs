using System;

class MatrixColumnSwap
{
    static void Main()
    {
        // 1. Запуск тестів
        RunTests();

        Console.WriteLine("\n--- Ручне введення ---");
        Console.Write("Введіть розмірність квадратної матриці (n): ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nПочаткова матриця:");
            PrintMatrix(matrix);

            // Виконуємо перестановку
            SwapColumns(matrix);

            Console.WriteLine("\nМатриця після перестановки стовпців:");
            PrintMatrix(matrix);
        }
    }

    // Метод для перестановки стовпців
    public static void SwapColumns(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // Йдемо до середини стовпців (cols / 2)
        for (int j = 0; j < cols / 2; j++)
        {
            int targetCol = cols - 1 - j; // Індекс стовпця з кінця

            for (int i = 0; i < rows; i++)
            {
                // Класичний обмін значень через тимчасову змінну
                int temp = matrix[i, j];
                matrix[i, j] = matrix[i, targetCol];
                matrix[i, targetCol] = temp;
            }
        }
    }

    // Тестування
    static void RunTests()
    {
        Console.WriteLine("=== ЗАПУСК ТЕСТІВ ===");
        
        // Матриця 3x3: [1,2,3], [4,5,6], [7,8,9]
        // Очікуємо: [3,2,1], [6,5,4], [9,8,7]
        int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        SwapColumns(matrix);

        bool pass = matrix[0, 0] == 3 && matrix[0, 2] == 1 && matrix[1, 1] == 5;
        Console.WriteLine(pass ? "[OK] Тест 3х3 пройдено" : "[FAIL] Тест 3х3 не пройшов");
        Console.WriteLine("=====================");
    }

    // Допоміжний метод для виводу
    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
    }
}
