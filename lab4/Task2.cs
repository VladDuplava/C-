using System;
using System.Linq;

namespace Lab4_VectorLong
{
    public class VectorLong
    {
        // Поля (захищені)
        protected long[] IntArray;
        protected uint size;
        protected int codeError;
        protected static uint num_vl = 0; // Статичний лічильник об'єктів

    

        // 1. Без параметрів
        public VectorLong()
        {
            size = 1;
            IntArray = new long[size];
            IntArray[0] = 0;
            num_vl++;
        }

        // 2. З одним параметром (розмір)
        public VectorLong(uint size)
        {
            this.size = size;
            IntArray = new long[size];
            for (int i = 0; i < size; i++) IntArray[i] = 0;
            num_vl++;
        }

        // 3. З двома параметрами (розмір та початкове значення)
        public VectorLong(uint size, long initialValue)
        {
            this.size = size;
            IntArray = new long[size];
            for (int i = 0; i < size; i++) IntArray[i] = initialValue;
            num_vl++;
        }

        // --- ДЕСТРУКТОР ---
        ~VectorLong()
        {
            Console.WriteLine("\n[Деструктор]: Об'єкт VectorLong видалено з пам'яті.");
        }

        // --- ВЛАСТИВОСТІ ---
        public uint Size => size; // Тільки для читання

        public int CodeError
        {
            get => codeError;
            set => codeError = value;
        }

        // --- МЕТОДИ ---
        public void Input()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Введіть елемент [{i}]: ");
                if (long.TryParse(Console.ReadLine(), out long val))
                    IntArray[i] = val;
            }
        }

        public void Display(string message = "Вектор")
        {
            Console.WriteLine($"{message}: [{string.Join(", ", IntArray)}]");
        }

        public static uint GetNumVectors() => num_vl;

        // --- ІНДЕКСАТОР ---
        public long this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    codeError = -1; // Помилка індексу
                    return 0;
                }
                return IntArray[index];
            }
            set
            {
                if (index < 0 || index >= size) codeError = -1;
                else IntArray[index] = value;
            }
        }

        // --- ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ ---

        // Унарні ++ та --
        public static VectorLong operator ++(VectorLong v)
        {
            for (int i = 0; i < v.size; i++) v.IntArray[i]++;
            return v;
        }

        public static VectorLong operator --(VectorLong v)
        {
            for (int i = 0; i < v.size; i++) v.IntArray[i]--;
            return v;
        }

        // Константи true і false
        public static bool operator true(VectorLong v) 
            => v.size > 0 && v.IntArray.Any(x => x != 0);
        public static bool operator false(VectorLong v) 
            => v.size == 0 || v.IntArray.All(x => x == 0);

        // Логічне !
        public static bool operator !(VectorLong v) => v.size == 0;

        // Побітове ~ (заперечення)
        public static VectorLong operator ~(VectorLong v)
        {
            VectorLong res = new VectorLong(v.size);
            for (int i = 0; i < v.size; i++) res.IntArray[i] = ~v.IntArray[i];
            return res;
        }

        // Бінарний + (вектор + вектор)
        public static VectorLong operator +(VectorLong v1, VectorLong v2)
        {
            uint maxSize = Math.Max(v1.size, v2.size);
            uint minSize = Math.Min(v1.size, v2.size);
            VectorLong res = new VectorLong(maxSize);
            
            // Заповнюємо з більшого вектора
            VectorLong longer = v1.size >= v2.size ? v1 : v2;
            Array.Copy(longer.IntArray, res.IntArray, maxSize);

            // Додаємо елементи меншого
            for (int i = 0; i < minSize; i++) res.IntArray[i] = v1.IntArray[i] + v2.IntArray[i];
            return res;
        }

        // Бінарний + (вектор + скаляр long)
        public static VectorLong operator +(VectorLong v, long scalar)
        {
            VectorLong res = new VectorLong(v.size);
            for (int i = 0; i < v.size; i++) res.IntArray[i] = v.IntArray[i] + scalar;
            return res;
        }

        // Оператори порівняння
        public static bool operator ==(VectorLong v1, VectorLong v2)
        {
            if (v1.size != v2.size) return false;
            return v1.IntArray.SequenceEqual(v2.IntArray);
        }

        public static bool operator !=(VectorLong v1, VectorLong v2) => !(v1 == v2);

        public static bool operator >(VectorLong v1, VectorLong v2)
        {
            if (v1.size != v2.size) return false;
            for (int i = 0; i < v1.size; i++) if (v1.IntArray[i] <= v2.IntArray[i]) return false;
            return true;
        }

        public static bool operator <(VectorLong v1, VectorLong v2)
        {
            if (v1.size != v2.size) return false;
            for (int i = 0; i < v1.size; i++) if (v1.IntArray[i] >= v2.IntArray[i]) return false;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Тестування конструкторів та статичного поля ---");
            VectorLong v1 = new VectorLong(3, 10);
            VectorLong v2 = new VectorLong(3, 5);
            VectorLong vDefault = new VectorLong();
            
            v1.Display("Вектор V1 (10, 10, 10)");
            v2.Display("Вектор V2 (5, 5, 5)");
            Console.WriteLine($"Всього створено об'єктів: {VectorLong.GetNumVectors()}");

            Console.WriteLine("\n--- Тестування індексатора та codeError ---");
            Console.WriteLine($"V1[0] = {v1[0]}");
            v1[99] = 100; // Спроба доступу до неіснуючого індексу
            if (v1.CodeError == -1) Console.WriteLine("Помилка! Вихід за межі масиву (CodeError = -1)");

            Console.WriteLine("\n--- Тестування арифметики та унарних операцій ---");
            v1++;
            v1.Display("V1 після ++");

            VectorLong vSum = v1 + v2;
            vSum.Display("Сума V1 + V2");

            VectorLong vScalar = v1 + 100;
            vScalar.Display("V1 + 100 (скаляр)");

            Console.WriteLine("\n--- Тестування логіки та порівняння ---");
            Console.WriteLine($"Чи v1 == v2? {v1 == v2}");
            Console.WriteLine($"Чи v1 > v2? {v1 > v2} (має бути true, бо 11 > 5)");
            
            if (v1) Console.WriteLine("Вектор V1 містить ненульові значення (true)");

            Console.WriteLine("\n--- Тестування побітової операції ~ ---");
            VectorLong vNot = ~v2;
            vNot.Display("Результат ~V2");

            Console.WriteLine("\nНатисніть Enter, щоб завершити роботу та викликати деструктори...");
            Console.ReadLine();
        }
    }
}
