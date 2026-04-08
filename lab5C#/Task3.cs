using System;

namespace PersonaHierarchyApp
{
    // 1. Абстрактний базовий клас
    public abstract class Persona
    {
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public Persona(string surname, DateTime birthDate)
        {
            Surname = surname;
            BirthDate = birthDate;
        }

        // Віртуальний метод для виведення інформації
        public abstract void ShowInfo();

        // Метод для визначення віку на момент поточної дати
        public virtual int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            
            // Коригування віку, якщо день народження ще не настав у поточному році
            if (BirthDate.Date > today.AddYears(-age)) 
            {
                age--;
            }
            return age;
        }
    }

    // 2. Похідний клас: Абітурієнт
    public class Abiturient : Persona
    {
        public string Faculty { get; set; }

        public Abiturient(string surname, DateTime birthDate, string faculty) 
            : base(surname, birthDate)
        {
            Faculty = faculty;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[Абітурієнт] Прізвище: {Surname,-15} | Вік: {GetAge(),-2} | Факультет: {Faculty}");
        }
    }

    // 3. Похідний клас: Студент
    public class Student : Persona
    {
        public string Faculty { get; set; }
        public int Course { get; set; }

        public Student(string surname, DateTime birthDate, string faculty, int course) 
            : base(surname, birthDate)
        {
            Faculty = faculty;
            Course = course;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[Студент]    Прізвище: {Surname,-15} | Вік: {GetAge(),-2} | Факультет: {Faculty,-15} | Курс: {Course}");
        }
    }

    // 4. Похідний клас: Викладач (в завданні вказано 'Викладати', виправлено за змістом)
    public class Teacher : Persona
    {
        public string Faculty { get; set; }
        public string Position { get; set; }
        public int ExperienceYears { get; set; } // Стаж

        public Teacher(string surname, DateTime birthDate, string faculty, string position, int experienceYears) 
            : base(surname, birthDate)
        {
            Faculty = faculty;
            Position = position;
            ExperienceYears = experienceYears;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[Викладач]   Прізвище: {Surname,-15} | Вік: {GetAge(),-2} | Факультет: {Faculty,-15} | Посада: {Position,-10} | Стаж: {ExperienceYears} р.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення бази (масиву) з n персон
            Persona[] database = new Persona[]
            {
                new Abiturient("Іваненко", new DateTime(2006, 5, 12), "Кібернетика"),
                new Abiturient("Петренко", new DateTime(2007, 10, 25), "Економіка"),
                new Student("Коваленко", new DateTime(2004, 3, 18), "Кібернетика", 3),
                new Student("Шевченко", new DateTime(2002, 11, 5), "Право", 4),
                new Teacher("Бойко", new DateTime(1975, 8, 14), "Кібернетика", "Професор", 20),
                new Teacher("Мельник", new DateTime(1985, 2, 28), "Економіка", "Доцент", 12)
            };

            // 1. Виведення повної інформації з бази на екран
            Console.WriteLine("--- ПОВНА БАЗА ПЕРСОН ---");
            foreach (var person in database)
            {
                person.ShowInfo();
            }

            // 2. Організація пошуку персон у заданому віковому діапазоні
            Console.WriteLine("\n--- ПОШУК ЗА ВІКОМ ---");
            Console.Write("Введіть мінімальний вік: ");
            if (!int.TryParse(Console.ReadLine(), out int minAge)) minAge = 0;

            Console.Write("Введіть максимальний вік: ");
            if (!int.TryParse(Console.ReadLine(), out int maxAge)) maxAge = 100;

            Console.WriteLine($"\nРезультати пошуку (вік від {minAge} до {maxAge} років):");
            bool found = false;

            foreach (var person in database)
            {
                int currentAge = person.GetAge();
                if (currentAge >= minAge && currentAge <= maxAge)
                {
                    person.ShowInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Жодної персони в заданому діапазоні не знайдено.");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
