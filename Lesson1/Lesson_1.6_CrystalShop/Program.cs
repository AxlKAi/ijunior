using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1._6_CrystalShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int walletAmmount;
            int crystalCost = 12;
            int crystals;

            Console.WriteLine("Вы находитесь в магазине кристалов.");
            Console.Write("Введите сумму денег которую вы с собой взяли:");
            walletAmmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Стоимость одного кристала {crystalCost}");
            Console.Write("Введите сколько кристалов хотите купить:");
            crystals = Convert.ToInt32(Console.ReadLine());
            walletAmmount -= crystals * crystalCost;
            Console.WriteLine($"Вы преобрели {crystals} кристалов, в кошельке осталось {walletAmmount}");
        }
    }
}
