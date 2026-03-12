using System;

namespace GeometryApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Введіть координату x:");
            if (!double.TryParse(Console.ReadLine(), out double x)) return;

            Console.WriteLine("Введіть координату y:");
            if (!double.TryParse(Console.ReadLine(), out double y)) return;

            // Обчислюємо квадрат відстані до центру (x^2 + y^2)
            double distanceSq = x * x + y * y;

            // Перевірка умов
            if (Math.Abs(distanceSq - 9) < 0.0001 || Math.Abs(distanceSq - 49) < 0.0001)
            {
                Console.WriteLine("На межі");
            }
            else if (distanceSq > 9 && distanceSq < 49)
            {
                Console.WriteLine("Так");
            }
            else
            {
                Console.WriteLine("Ні");
            }
        }
    }
}