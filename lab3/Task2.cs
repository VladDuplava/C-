using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationHierarchy
{
    // Базовий клас
    public class Organization
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }

        public Organization(string name, int employeeCount)
        {
            Name = name;
            EmployeeCount = employeeCount;
        }

        // Віртуальний метод для перевизначення у похідних класах
        public virtual void Show()
        {
            Console.WriteLine($"[Організація] Назва: {Name}, Співробітників: {EmployeeCount}");
        }
    }

    // Похідний клас: Страхова компанія
    public class InsuranceCompany : Organization
    {
        public double TotalInsuranceCapital { get; set; }

        public InsuranceCompany(string name, int employees, double capital) 
            : base(name, employees)
        {
            TotalInsuranceCapital = capital;
        }

        public override void Show()
        {
            Console.WriteLine($"[Страхова компанія] Назва: {Name}, Співробітників: {EmployeeCount}, Капітал: {TotalInsuranceCapital} млн грн");
        }
    }

    // Похідний клас: Нафтогазова компанія
    public class OilGasCompany : Organization
    {
        public int DepositsCount { get; set; }

        public OilGasCompany(string name, int employees, int deposits) 
            : base(name, employees)
        {
            DepositsCount = deposits;
        }

        public override void Show()
        {
            Console.WriteLine($"[Нафтогазова компанія] Назва: {Name}, Співробітників: {EmployeeCount}, Родовищ: {DepositsCount}");
        }
    }

    // Похідний клас: Завод
    public class Factory : Organization
    {
        public string ProductType { get; set; }

        public Factory(string name, int employees, string product) 
            : base(name, employees)
        {
            ProductType = product;
        }

        public override void Show()
        {
            Console.WriteLine($"[Завод] Назва: {Name}, Співробітників: {EmployeeCount}, Тип продукції: {ProductType}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо список базового типу
            List<Organization> organizations = new List<Organization>();

            // Функція наповнення масиву різними об'єктами
            FillData(organizations);

            Console.WriteLine("--- Виведення впорядкованого масиву за типами об'єктів --- \n");

            // Впорядкування за типом (спочатку Страхові, потім Нафтогазові, потім Заводи)
            var sortedList = organizations.OrderBy(x => x.GetType().Name).ToList();

            foreach (var org in sortedList)
            {
                org.Show();
            }

            Console.ReadKey();
        }

        static void FillData(List<Organization> list)
        {
            list.Add(new Factory("Антонов", 5000, "Літаки"));
            list.Add(new InsuranceCompany("Оранта", 1200, 550.5));
            list.Add(new OilGasCompany("Укрнафта", 15000, 42));
            list.Add(new Factory("Рошен", 2000, "Кондитерські вироби"));
            list.Add(new InsuranceCompany("ПЗУ Україна", 800, 320.0));
            list.Add(new OilGasCompany("Нафтогаз", 25000, 89));
        }
    }
}
