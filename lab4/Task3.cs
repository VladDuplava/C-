using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonTask
{
    // 1. Оголошення СТРУКТУРИ
    public struct PersonStruct
    {
        public string FullName; // Прізвище, ім'я, по батькові
        public int BirthYear;   // Рік народження
        public double Height;   // Зріст
        public double Weight;   // Вага

        public override string ToString() => $"{FullName}, {BirthYear} р.н., {Height} см, {Weight} кг";
    }

    // 3. Оголошення ЗАПИСУ (Record)
    public record PersonRecord(string FullName, int BirthYear, double Height, double Weight);

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ВАРІАНТ 1: Використання СТРУКТУР ===");
            SolveWithStructs();

            Console.WriteLine("\n=== ВАРІАНТ 2: Використання КОРТЕЖІВ ===");
            SolveWithTuples();

            Console.WriteLine("\n=== ВАРІАНТ 3: Використання ЗАПИСІВ ===");
            SolveWithRecords();

            Console.ReadLine();
        }

        // --- РЕАЛІЗАЦІЯ ДЛЯ СТРУКТУР ---
        static void SolveWithStructs()
        {
            var people = new List<PersonStruct>
            {
                new PersonStruct { FullName = "Іванов Іван Іванович", BirthYear = 1990, Height = 180, Weight = 80 },
                new PersonStruct { FullName = "Петров Петро Петрович", BirthYear = 1985, Height = 175, Weight = 70 },
                new PersonStruct { FullName = "Сидоров Сидір Сидорович", BirthYear = 2000, Height = 180, Weight = 80 }
            };

            PrintList(people, "Початковий масив:");

            // Видалення (Зріст = 180, Вага = 80)
            double targetHeight = 180;
            double targetWeight = 80;
            people.RemoveAll(p => p.Height == targetHeight && p.Weight == targetWeight);
            PrintList(people, $"Після видалення елементів зі зростом {targetHeight} та вагою {targetWeight}:");

            // Додавання після вказаного прізвища
            string targetLastName = "Петров";
            int index = people.FindIndex(p => p.FullName.StartsWith(targetLastName));
            
            if (index != -1)
            {
                var newPerson = new PersonStruct { FullName = "Новий Микола Миколайович", BirthYear = 1995, Height = 170, Weight = 65 };
                people.Insert(index + 1, newPerson);
            }
            PrintList(people, $"Після додавання нового елемента після прізвища '{targetLastName}':");
        }

        // --- РЕАЛІЗАЦІЯ ДЛЯ КОРТЕЖІВ ---
        static void SolveWithTuples()
        {
            // Кортеж: (string FullName, int BirthYear, double Height, double Weight)
            var people = new List<(string FullName, int BirthYear, double Height, double Weight)>
            {
                ("Іванов Іван Іванович", 1990, 180, 80),
                ("Петров Петро Петрович", 1985, 175, 70),
                ("Сидоров Сидір Сидорович", 2000, 180, 80)
            };

            PrintListTuples(people, "Початковий масив:");

            // Видалення
            double targetHeight = 180;
            double targetWeight = 80;
            people.RemoveAll(p => p.Height == targetHeight && p.Weight == targetWeight);
            PrintListTuples(people, $"Після видалення елементів зі зростом {targetHeight} та вагою {targetWeight}:");

            // Додавання
            string targetLastName = "Петров";
            int index = people.FindIndex(p => p.FullName.StartsWith(targetLastName));
            
            if (index != -1)
            {
                var newPerson = ("Новий Микола Миколайович", 1995, 170, 65);
                people.Insert(index + 1, newPerson);
            }
            PrintListTuples(people, $"Після додавання нового елемента після прізвища '{targetLastName}':");
        }

        // --- РЕАЛІЗАЦІЯ ДЛЯ ЗАПИСІВ (RECORDS) ---
        static void SolveWithRecords()
        {
            var people = new List<PersonRecord>
            {
                new PersonRecord("Іванов Іван Іванович", 1990, 180, 80),
                new PersonRecord("Петров Петро Петрович", 1985, 175, 70),
                new PersonRecord("Сидоров Сидір Сидорович", 2000, 180, 80)
            };

            PrintList(people, "Початковий масив:");

            // Видалення
            double targetHeight = 180;
            double targetWeight = 80;
            people.RemoveAll(p => p.Height == targetHeight && p.Weight == targetWeight);
            PrintList(people, $"Після видалення елементів зі зростом {targetHeight} та вагою {targetWeight}:");

            // Додавання
            string targetLastName = "Петров";
            int index = people.FindIndex(p => p.FullName.StartsWith(targetLastName));
            
            if (index != -1)
            {
                var newPerson = new PersonRecord("Новий Микола Миколайович", 1995, 170, 65);
                people.Insert(index + 1, newPerson);
            }
            PrintList(people, $"Після додавання нового елемента після прізвища '{targetLastName}':");
        }

        // --- Допоміжні методи для виводу на екран ---
        static void PrintList<T>(List<T> list, string message)
        {
            Console.WriteLine(message);
            if (list.Count == 0) Console.WriteLine("  (порожньо)");
            foreach (var item in list)
            {
                Console.WriteLine($"  {item}");
            }
            Console.WriteLine();
        }

        static void PrintListTuples(List<(string FullName, int BirthYear, double Height, double Weight)> list, string message)
        {
            Console.WriteLine(message);
            if (list.Count == 0) Console.WriteLine("  (порожньо)");
            foreach (var item in list)
            {
                Console.WriteLine($"  {item.FullName}, {item.BirthYear} р.н., {item.Height} см, {item.Weight} кг");
            }
            Console.WriteLine();
        }
    }
}
