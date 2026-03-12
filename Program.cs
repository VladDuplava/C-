using System;

namespace NumberCheck
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Введіть ціле число: ");
            if (int.TryParse(Console.ReadLine(), out int number)) //tryparse це перетворення тексту на число якщо це можливо 
            {
                bool result = EndsWithSeven(number);
                Console.WriteLine(result 
                    ? $"Так, число {number} закінчується на 7." 
                    : $"Ні, число {number} не закінчується на 7.");
            }
            else
            {
                Console.WriteLine("Помилка: введіть коректне ціле число.");
            }

            // Запуск тестів
            RunTests();
        }

        public static bool EndsWithSeven(int n)
        {
          
            return Math.Abs(n) % 10 == 7;
        }

        public static void RunTests()
        {
            Console.WriteLine("\n--- Автоматичні тести ---");
            Console.WriteLine($"Тест 1 (27): {EndsWithSeven(27)} (Очікувано: True)");
            Console.WriteLine($"Тест 2 (10): {EndsWithSeven(10)} (Очікувано: False)");
            Console.WriteLine($"Тест 3 (-17): {EndsWithSeven(-17)} (Очікувано: True)");
            Console.WriteLine($"Тест 4 (7): {EndsWithSeven(7)} (Очікувано: True)");
            Console.WriteLine($"Тест 5 (0): {EndsWithSeven(0)} (Очікувано: False)");
        }
    }
}