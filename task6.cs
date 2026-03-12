using System;

namespace ExpressionApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Обчислення математичного виразу ---");

            // Введення даних
            Console.Write("Введіть ціле число n: ");
            if (!int.TryParse(Console.ReadLine(), out int n)) return;

            Console.Write("Введіть ціле число m: ");
            if (!int.TryParse(Console.ReadLine(), out int m)) return;

            // Перевірка на ділення на нуль
            if (m == 0 || m == -1)
            {
                Console.WriteLine("Помилка: ділення на нуль (m не може бути 0 або -1).");
            }
            else
            {
                double result = (n + m) * ((double)(n + 1) / (m + 1) + 5.0 / m);

                Console.WriteLine($"\nРезультат виразу: {result:F4}");
            }
        }
    }
}