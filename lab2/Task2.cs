using System;
using System.Collections.Generic;

class MaxElementTask
{
    static void Main()
    {
        // 1. Автоматичне тестування
        RunTests();

        Console.WriteLine("\n--- Ручне введення даних ---");
        
        Console.Write("Введіть кількість елементів (n): ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            double[] numbers = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                numbers[i] = double.Parse(Console.ReadLine());
            }

            // Виклик методу для отримання номерів
            List<int> result = GetIndicesNotEqualToMax(numbers);

            if (result.Count == 0)
            {
                Console.WriteLine("Усі елементи однакові (збігаються з максимальним).");
            }
            else
            {
                Console.WriteLine("Номери (індекси) елементів, що не збігаються з максимальним:");
                Console.WriteLine(string.Join(", ", result));
            }
        }
        else
        {
            Console.WriteLine("Помилка: введіть ціле число більше 0.");
        }
    }

    // Основна логіка: повертає список індексів
    public static List<int> GetIndicesNotEqualToMax(double[] array)
    {
        List<int> indices = new List<int>();
        if (array.Length == 0) return indices;

        // 1. Знаходимо максимум
        double max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max) max = array[i];
        }

        // 2. Знаходимо індекси елементів, які не рівні максимуму
        for (int i = 0; i < array.Length; i++)
        {
            if (Math.Abs(array[i] - max) > 0.000001) // Перевірка на нерівність дійсних чисел
            {
                indices.Add(i);
            }
        }
        return indices;
    }

    // Тести
    static void RunTests()
    {
        Console.WriteLine("=== ЗАПУСК ТЕСТІВ ===");

        // Тест 1: Звичайний масив
        double[] t1 = { 1.5, 5.0, 2.3, 5.0, 0.1 }; // Макс = 5.0. Не рівні: індекси 0, 2, 4
        var res1 = GetIndicesNotEqualToMax(t1);
        Assert(string.Join(",", res1), "0,2,4", "Тест 1: Різні числа");

        // Тест 2: Усі числа однакові
        double[] t2 = { 7, 7, 7 }; // Макс = 7. Не рівних немає.
        var res2 = GetIndicesNotEqualToMax(t2);
        Assert(string.Join(",", res2), "", "Тест 2: Однакові числа");

        // Тест 3: Від'ємні числа
        double[] t3 = { -10, -2, -10 }; // Макс = -2. Не рівні: індекси 0, 2
        var res3 = GetIndicesNotEqualToMax(t3);
        Assert(string.Join(",", res3), "0,2", "Тест 3: Від'ємні числа");

        Console.WriteLine("=====================");
    }

    static void Assert(string actual, string expected, string name)
    {
        if (actual == expected)
            Console.WriteLine($"[OK] {name}");
        else
            Console.WriteLine($"[FAIL] {name}: Очікували {expected}, отримали {actual}");
    }
}
