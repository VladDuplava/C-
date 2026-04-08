using System;

namespace ClassHierarchyApp2
{
    // 1. Абстрактний базовий клас: Організація
    public abstract class Organization
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }

        // Конструктор 1 (без параметрів)
        public Organization()
        {
            Name = "Невідома організація";
            EmployeeCount = 0;
            Console.WriteLine(" [+] Базовий конструктор: Organization()");
        }

        // Конструктор 2 (один параметр)
        public Organization(string name)
        {
            Name = name;
            EmployeeCount = 0;
            Console.WriteLine($" [+] Базовий конструктор: Organization(string name) -> {Name}");
        }

        // Конструктор 3 (всі параметри)
        public Organization(string name, int employeeCount)
        {
            Name = name;
            EmployeeCount = employeeCount;
            Console.WriteLine($" [+] Базовий конструктор: Organization(string name, int count) -> {Name}");
        }

        // Деструктор базового класу
        ~Organization()
        {
            Console.WriteLine($" [-] Базовий деструктор: ~Organization() для '{Name}'");
        }

        public abstract void Show();
    }

    // 2. Похідний клас 1: Страхова компанія
    public class InsuranceCompany : Organization
    {
        public string InsuranceType { get; set; }

        // Конструктор 1
        public InsuranceCompany() : base()
        {
            InsuranceType = "Загальне";
            Console.WriteLine("  [++] Похідний конструктор: InsuranceCompany()");
        }

        // Конструктор 2
        public InsuranceCompany(string name, string insuranceType) : base(name)
        {
            InsuranceType = insuranceType;
            Console.WriteLine("  [++] Похідний конструктор: InsuranceCompany(string, string)");
        }

        // Конструктор 3
        public InsuranceCompany(string name, int employeeCount, string insuranceType) 
            : base(name, employeeCount)
        {
            InsuranceType = insuranceType;
            Console.WriteLine("  [++] Похідний конструктор: InsuranceCompany(string, int, string)");
        }

        ~InsuranceCompany()
        {
            Console.WriteLine($"  [--] Похідний деструктор: ~InsuranceCompany() для '{Name}'");
        }

        public override void Show() { /* Реалізація опущена для стислості */ }
    }

    // 3. Похідний клас 2: Нафтогазова компанія
    public class OilAndGasCompany : Organization
    {
        public double AnnualProduction { get; set; }

        // Конструктор 1
        public OilAndGasCompany() : base()
        {
            AnnualProduction = 0.0;
            Console.WriteLine("  [++] Похідний конструктор: OilAndGasCompany()");
        }

        // Конструктор 2
        public OilAndGasCompany(string name, double annualProduction) : base(name)
        {
            AnnualProduction = annualProduction;
            Console.WriteLine("  [++] Похідний конструктор: OilAndGasCompany(string, double)");
        }

        // Конструктор 3
        public OilAndGasCompany(string name, int employeeCount, double annualProduction) 
            : base(name, employeeCount)
        {
            AnnualProduction = annualProduction;
            Console.WriteLine("  [++] Похідний конструктор: OilAndGasCompany(string, int, double)");
        }

        ~OilAndGasCompany()
        {
            Console.WriteLine($"  [--] Похідний деструктор: ~OilAndGasCompany() для '{Name}'");
        }

        public override void Show() { }
    }

    // 4. Похідний клас 3: Завод
    public class Factory : Organization
    {
        public string ProductType { get; set; }

        // Конструктор 1
        public Factory() : base()
        {
            ProductType = "Невідомий продукт";
            Console.WriteLine("  [++] Похідний конструктор: Factory()");
        }

        // Конструктор 2
        public Factory(string name, string productType) : base(name)
        {
            ProductType = productType;
            Console.WriteLine("  [++] Похідний конструктор: Factory(string, string)");
        }

        // Конструктор 3
        public Factory(string name, int employeeCount, string productType) 
            : base(name, employeeCount)
        {
            ProductType = productType;
            Console.WriteLine("  [++] Похідний конструктор: Factory(string, int, string)");
        }

        ~Factory()
        {
            Console.WriteLine($"  [--] Похідний деструктор: ~Factory() для '{Name}'");
        }

        public override void Show() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- СТВОРЕННЯ ОБ'ЄКТІВ (ВИКЛИК КОНСТРУКТОРІВ) ---\n");

            // Створюємо масив і викликаємо ВСІ можливі конструктори
            Organization[] orgs = new Organization[]
            {
                // Страхові компанії
                new InsuranceCompany(),
                new InsuranceCompany("АСКА", "Медичне"),
                new InsuranceCompany("ПЗУ", 150, "Авто"),

                // Нафтогазові компанії
                new OilAndGasCompany(),
                new OilAndGasCompany("Укрнафта", 5000.5),
                new OilAndGasCompany("Нафтогаз", 50000, 10000.0),

                // Заводи
                new Factory(),
                new Factory("Рошен", "Цукерки"),
                new Factory("Азовсталь", 10000, "Метал")
            };

            Console.WriteLine("\n--- ЗНИЩЕННЯ ОБ'ЄКТІВ (ВИКЛИК ДЕСТРУКТОРІВ) ---\n");

            // Видаляємо посилання на масив, щоб Garbage Collector міг очистити пам'ять
            orgs = null;

            // Примусовий виклик збирача сміття для демонстрації роботи деструкторів
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("\nРобота програми завершена.");
        }
    }
}
