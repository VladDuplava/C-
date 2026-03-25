using System;

class JaggedArrayTask
{
    static void Main()
    {
        // 1. Тестування
        RunTests();

        Console.WriteLine("\n--- Ручне введення ---");
        
        Console.Write("Введіть кількість рядків у східчастому масиві: ");
        int n = int.Parse(Console.ReadLine());

        // Створення східчастого масиву
        int[][] jaggedArray = new int[n][];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть кількість елементів для рядка {i}: ");
            int m = int.Parse(Console.ReadLine());
            jaggedArray[i] = new int[m];

            for (int j = 0; j < m; j++)
            {
                Console.Write($"  Елемент [{i}][{j}]: ");
                jaggedArray[i][j] = int.Parse(Console.ReadLine());
            }
        }

        Console.Write("\nВведіть задане число (X) для порівняння: ");
        int x = int.Parse(Console.ReadLine());

        // Виклик логіки
        int[] counts = CountElementsGreaterThanX(jaggedArray, x);

        Console.WriteLine("\nРезультат (кількість елементів > X у кожному рядку):");
        for (int i = 0; i < counts.Length; i++)
        {
            Console.WriteLine($"Рядок {i}: {counts[i]}");
        }
    }

    // Основна логіка
    public static int[] CountElementsGreaterThanX(int[][] array, int x)
    {
        int[] result = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            int count = 0;
            // Перевіряємо кожен елемент у поточному рядку
            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] > x)
                {
                    count++;
                }
            }
            result[i] = count; // Записуємо результат у новий масив
        }
        return result;
    }

    // Тести
    static void RunTests()
    {
        Console.WriteLine("=== ЗАПУСК ТЕСТІВ ===");

        // Створюємо тестовий східчастий масив
        int[][] testArray = new int[3][];
        testArray[0] = new int[] { 1, 10, 5 };    // 1 ел > 6
        testArray[1] = new int[] { 7, 8, 9, 10 }; // 4 ел > 6
        testArray[2] = new int[] { 2, 3 };       // 0 ел > 6

        int[] results = CountElementsGreaterThanX(testArray, 6);

        bool pass = results[0] == 1 && results[1] == 4 && results[2] == 0;
        Console.WriteLine(pass ? "[OK] Тест пройдено" : "[FAIL] Помилка в обчисленнях");
        Console.WriteLine("=====================");
    }
}
