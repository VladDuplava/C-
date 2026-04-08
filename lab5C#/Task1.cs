using System;

namespace ClassHierarchyApp
{
    // 1. Абстрактний базовий клас: Організація
    public abstract class Organization
    {
        // Властивості (поля, характерні для кожного класу)
        public string Name { get; set; }
        public int EmployeeCount { get; set; }

        // Поле для демонстрації індексатора (наприклад, філії)
        private string[] branches = new string[3];

        // Конструктор
        public Organization(string name, int employeeCount)
        {
            Name = name;
            EmployeeCount = employeeCount;
        }

        // Індексатор
        public string this[int index]
        {
            get 
            {
                if (index >= 0 && index < branches.Length)
                    return branches[index];
                return "Невідома філія";
            }
            set 
            {
                if (index >= 0 && index < branches.Length)
                    branches[index] = value;
            }
        }

        // Абстрактний метод (обов'язковий для реалізації в похідних класах)
        public abstract void Show();

        // Віртуальний метод (може бути перевизначений)
        public virtual void GetActivityType()
        {
            Console.WriteLine("Загальна комерційна або некомерційна діяльність.");
        }

        // Невіртуальний метод (успадковується як є)
        public void PrintBaseInfo()
        {
            Console.WriteLine($"[Базова інфо] Організація: {Name}, Співробітників: {EmployeeCount}");
        }

        // Перевантаження операцій порівняння (за кількістю співробітників)
        public static bool operator >(Organization o1, Organization o2)
        {
            return o1.EmployeeCount > o2.EmployeeCount;
        }

        public static bool operator <(Organization o1, Organization o2)
        {
            return o1.EmployeeCount < o2.EmployeeCount;
        }

        // Деструктор
        ~Organization()
        {
            // Викликається збирачем сміття (Garbage Collector)
            Console.WriteLine($"[{Name}] Знищено (виклик деструктора).");
        }
    }

    // 2. Похідний клас 1: Страхова компанія
    public class InsuranceCompany : Organization
    {
        public string InsuranceType { get; set; }

        public InsuranceCompany(string name, int employeeCount, string insuranceType) 
            : base(name, employeeCount)
        {
            InsuranceType = insuranceType;
        }

        public override void Show()
        {
            Console.WriteLine($"[Страхова компанія] Назва: {Name,-12} | Співробітників: {EmployeeCount,-6} | Тип страхування: {InsuranceType}");
        }

        public override void GetActivityType()
        {
            Console.WriteLine($"[{Name}] Діяльність: Надання страхових послуг, виплата відшкодувань.");
        }
    }

    // 3. Похідний клас 2: Нафтогазова компанія
    public class OilAndGasCompany : Organization
    {
        public double AnnualProductionTons { get; set; } // Річний видобуток в тоннах

        public OilAndGasCompany(string name, int employeeCount, double annualProduction) 
            : base(name, employeeCount)
        {
            AnnualProductionTons = annualProduction;
        }

        public override void Show()
        {
            Console.WriteLine($"[Нафтогазова комп.] Назва: {Name,-12} | Співробітників: {EmployeeCount,-6} | Видобуток (т/рік): {AnnualProductionTons}");
        }

        public override void GetActivityType()
        {
            Console.WriteLine($"[{Name}] Діяльність: Розвідка, видобуток та транспортування нафти і газу.");
        }
    }

    // 4. Похідний клас 3: Завод
    public class Factory : Organization
    {
        public string ProductType { get; set; }

        public Factory(string name, int employeeCount, string productType) 
            : base(name, employeeCount)
        {
            ProductType = productType;
        }

        public override void Show()
        {
            Console.WriteLine($"[Завод]             Назва: {Name,-12} | Співробітників: {EmployeeCount,-6} | Продукція: {ProductType}");
        }

        public override void GetActivityType()
        {
            Console.WriteLine($"[{Name}] Діяльність: Серійне виробництво матеріальних благ.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення масиву об'єктів (по декілька представників кожного типу)
            Organization[] organizations = new Organization[]
            {
                new InsuranceCompany("АСКА", 150, "Медичне страхування"),
                new InsuranceCompany("ПЗУ Україна", 450, "Автострахування"),
                new Factory("Азовсталь", 10000, "Металопрокат"),
                new Factory("Рошен", 3000, "Кондитерські вироби"),
                new OilAndGasCompany("Укрнафта", 20000, 1500000.5),
                new OilAndGasCompany("Нафтогаз", 50000, 3000000.0)
            };

            // Демонстрація роботи індексатора
            Console.WriteLine("--- Тестування індексатора ---");
            organizations[0][0] = "Київська філія";
            organizations[0][1] = "Львівська філія";
            Console.WriteLine($"Філії {organizations[0].Name}: 1. {organizations[0][0]}, 2. {organizations[0][1]}");
            Console.WriteLine();

            // Демонстрація віртуальних та невіртуальних методів
            Console.WriteLine("--- Тестування методів ---");
            organizations[2].PrintBaseInfo();     // Невіртуальний (з базового класу)
            organizations[2].GetActivityType();   // Віртуальний (перевизначений)
            Console.WriteLine();

            // Впорядкування масиву за полем базового класу (EmployeeCount)
            // Використовуємо алгоритм сортування бульбашкою та наші перевантажені оператори >
            Console.WriteLine("--- Впорядкування масиву за зростанням кількості співробітників ---");
            for (int i = 0; i < organizations.Length - 1; i++)
            {
                for (int j = 0; j < organizations.Length - i - 1; j++)
                {
                    // Використання перевантаженого оператора >
                    if (organizations[j] > organizations[j + 1])
                    {
                        Organization temp = organizations[j];
                        organizations[j] = organizations[j + 1];
                        organizations[j + 1] = temp;
                    }
                }
            }

            // Виведення відсортованого масиву через метод Show()
            Console.WriteLine("--- Результат роботи методу Show() для всіх елементів ---");
            foreach (var org in organizations)
            {
                org.Show();
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
            // По завершенні програми Garbage Collector викличе деструктори
        }
    }
}
