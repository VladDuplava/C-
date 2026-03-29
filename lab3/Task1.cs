using System;

namespace WalletApp
{
    // Клас Money, що моделює купюри певного номіналу
    public class Money
    {
        // Поля (захищені)
        protected int nominal;
        protected int num;

        // Конструктор
        public Money(int nominal, int num)
        {
            this.nominal = nominal;
            this.num = num;
        }

        // Властивості
        public int Nominal
        {
            get { return nominal; }
            set { if (value > 0) nominal = value; }
        }

        public int Num
        {
            get { return num; }
            set { if (value >= 0) num = value; }
        }

        // Властивість тільки для читання: загальна сума грошей
        public int TotalAmount
        {
            get { return nominal * num; }
        }

        // Методи
        public void DisplayInfo()
        {
            Console.WriteLine($"Номінал: {nominal} грн, Кількість: {num} шт. (Всього: {TotalAmount} грн)");
        }

        public bool CanAfford(int price)
        {
            return TotalAmount >= price;
        }

        public int HowManyCanBuy(int price)
        {
            if (price <= 0) return 0;
            return TotalAmount / price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Тестування створення екземпляра та властивостей
            Console.WriteLine("--- Тест класу Money ---");
            Money myMoney = new Money(100, 5);
            myMoney.DisplayInfo();
            
            // Зміна значень через властивості
            myMoney.Num = 10;
            Console.WriteLine($"Після оновлення кількості: {myMoney.TotalAmount} грн");

            // 2. Тестування методів
            int productPrice = 250;
            Console.WriteLine($"\nЧи вистачить на товар за {productPrice} грн? " + 
                              (myMoney.CanAfford(productPrice) ? "Так" : "Ні"));
            Console.WriteLine($"Скільки штук товару по {productPrice} грн можна купити? " + 
                              $"{myMoney.HowManyCanBuy(productPrice)} шт.");

            // 3. Робота з масивом об'єктів (гаманець) та масивом товарів
            Console.WriteLine("\n--- Тестування масивів (Гаманець та Товари) ---");
            
            // Масив об'єктів Money (різні купюри в гаманці)
            Money[] wallet = {
                new Money(10, 5),   // 50
                new Money(50, 2),   // 100
                new Money(200, 1)   // 200
            };

            int totalInWallet = 0;
            foreach (var cash in wallet)
            {
                cash.DisplayInfo();
                totalInWallet += cash.TotalAmount;
            }
            Console.WriteLine($"Загальна сума в гаманці: {totalInWallet} грн");

            // Масив цін товарів
            int[] products = { 45, 120, 350, 500 };

            Console.WriteLine("\nРезультати покупок:");
            foreach (int price in products)
            {
                bool canBuy = totalInWallet >= price;
                Console.WriteLine($"Товар ціною {price} грн: " + 
                                  (canBuy ? "Можна купити" : "Недостатньо коштів"));
            }

            Console.ReadKey();
        }
    }
}
