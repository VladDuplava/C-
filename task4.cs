using System;

namespace CardGame
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть номер масті (1-4): ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Введіть номер карти (6-14): ");
            int k = int.Parse(Console.ReadLine());

            string cardName = GetCardName(k);
            string suitName = GetSuitName(m);

            if (cardName == "Помилка" || suitName == "Помилка")
            {
                Console.WriteLine("Некоректні дані! Перевірте діапазони: масть 1-4, карта 6-14.");
            }
            else
            {
                Console.WriteLine($"Ваша карта: {cardName} {suitName}");
            }
        }

        static string GetCardName(int k)
        {
            return k switch
            {
                6 => "шістка",
                7 => "сімка",
                8 => "вісімка",
                9 => "дев'ятка",
                10 => "десятка",
                11 => "валет",
                12 => "дама",
                13 => "король",
                14 => "туз",
                _ => "Помилка"
            };
        }

        static string GetSuitName(int m)
        {
            return m switch
            {
                1 => "пік",
                2 => "треф",
                3 => "бубен",
                4 => "чирва",
                _ => "Помилка"
            };
        }
    }
}