using System;

namespace Lab4
{
    public class Money
    {
        private int first;  // Номінал купюри
        private int second; // Кількість купюр

        public Money(int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        // --- 1. Індексатор ---
        public int this[int index]
        {
            get
            {
                if (index == 0) return first;
                if (index == 1) return second;
                throw new Exception("Помилка: Індекс має бути 0 (номінал) або 1 (кількість).");
            }
            set
            {
                if (index == 0) first = value;
                else if (index == 1) second = value;
                else Console.WriteLine("Помилка: Неможливо встановити значення за цим індексом.");
            }
        }

        // --- 2. Перевантаження операторів ---

        // Операції ++ та -- (одночасна зміна обох полів)
        public static Money operator ++(Money m)
        {
            m.first++;
            m.second++;
            return m;
        }

        public static Money operator --(Money m)
        {
            m.first--;
            m.second--;
            return m;
        }

        // Операція ! (перевірка чи second не нульове)
        public static bool operator !(Money m)
        {
            return m.second != 0;
        }

        // Бінарний + (додає до second значення скаляра)
        public static Money operator +(Money m, int scalar)
        {
            return new Money(m.first, m.second + scalar);
        }

        // --- 3. Перетворення типів ---

        // Перетворення Money в string (явне або неявне)
        public static implicit operator string(Money m)
        {
            return $"Купюра: {m.first}, Кількість: {m.second}";
        }

        // Перетворення string в Money (припустимо формат "номінал кількість")
        public static explicit operator Money(string s)
        {
            string[] parts = s.Split(' ');
            int f = int.Parse(parts[0]);
            int sec = int.Parse(parts[1]);
            return new Money(f, sec);
        }

        public void Show()
        {
            Console.WriteLine((string)this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Тестування Індексатора ---");
            Money m1 = new Money(100, 5);
            Console.WriteLine($"Індекс 0: {m1[0]}"); // 100
            Console.WriteLine($"Індекс 1: {m1[1]}"); // 5

            Console.WriteLine("\n--- Тестування Операторів ++ та -- ---");
            m1++;
            Console.WriteLine($"Після ++: {m1[0]}, {m1[1]}"); // 101, 6
            m1--;
            Console.WriteLine($"Після --: {m1[0]}, {m1[1]}"); // 100, 5

            Console.WriteLine("\n--- Тестування Оператора ! ---");
            Console.WriteLine($"Поле second не нульове? {!m1}"); // True

            Console.WriteLine("\n--- Тестування Бінарного + (скаляр) ---");
            Money m2 = m1 + 10;
            Console.WriteLine($"Додали 10 до кількості: {m2[1]} шт.");

            Console.WriteLine("\n--- Тестування Перетворення Типів ---");
            // В string (неявне)
            string info = m1; 
            Console.WriteLine($"Рядок з об'єкта: {info}");

            // Зі string (явне)
            string source = "500 3";
            Money m3 = (Money)source;
            Console.WriteLine($"Об'єкт з рядка: {m3[0]} грн, {m3[1]} шт.");

            Console.ReadKey();
        }
    }
}
