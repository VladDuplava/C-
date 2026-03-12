using System;
using System.Globalization;

namespace MathOperations
{
    class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Обчислення суми двох дійсних чисел ---");

            Console.Write("Введіть перше число: ");
            double num1 = ReadDouble();

            Console.Write("Введіть друге число: ");
            double num2 = ReadDouble();

            // Виклик функції
            double result = Sum(num1, num2);

            Console.WriteLine($"\nРезультат: {num1} + {num2} = {result}");
        }

        // Функція (метод) для обчислення суми
        public static double Sum(double a, double b)
        {
            return a + b;
        }
        
        static double ReadDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                
                Console.Write("Помилка! Введіть число (наприклад, 5.5): ");
            }
        }
    }
}