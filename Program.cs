using System;

namespace MathApp
{
    public class GeometricMeanCalculator
    {
        public static void Main()
        {
           Console.WriteLine("--- Програма для обчислення середнього геометричного модулів ---");
            
            Console.Write("Введіть перше число: ");
            double a = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Введіть друге число: ");
            double b = Convert.ToDouble(Console.ReadLine());

            double result = CalculateGeometricMean(a, b);
            Console.WriteLine($"Результат: {result:F4}");

            // Запуск автоматичних тестів
            RunTests();
        }

        public static double CalculateGeometricMean(double a, double b)
        {
            // Обчислюємо за формулою: sqrt(|a| * |b|)
            return Math.Sqrt(Math.Abs(a) * Math.Abs(b));
        }

        public static void RunTests()
        {
            Console.WriteLine("\n--- Запуск тестів ---");
            
            // Тест 1: Позитивні числа
            AssertTest(4, 16, 8, "Позитивні числа (4, 16)");

            // Тест 2: Від'ємні числа
            AssertTest(-4, -16, 8, "Від'ємні числа (-4, -16)");

            // Тест 3: Одне число нуль
            AssertTest(0, 25, 0, "Одне число нуль (0, 25)");

            // Тест 4: Різні знаки
            AssertTest(-2, 8, 4, "Різні знаки (-2, 8)");
        }

        private static void AssertTest(double a, double b, double expected, string testName)
        {
            double result = CalculateGeometricMean(a, b);
            bool isPassed = Math.Abs(result - expected) < 0.0001;
            
            Console.WriteLine($"{testName}: {(isPassed ? "ПРОЙДЕНО" : "ПОМИЛКА")}");
            if (!isPassed) Console.WriteLine($"   Очікувано: {expected}, Отримано: {result}");
        }
    }
}