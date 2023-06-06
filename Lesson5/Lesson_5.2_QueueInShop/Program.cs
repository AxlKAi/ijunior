using System;
using System.Collections.Generic;

namespace Lesson_5._2_QueueInShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int minimuSellPrice = 100;
            int maximumSellPrice = 1000;
            int queueDeep = 10;
            int totalSum = 0;

            var buyersReceipts =  GenerateRandomQueue(minimuSellPrice, maximumSellPrice, queueDeep);

            while (buyersReceipts.Count > 0)
            {
                ServeСustomer(ref buyersReceipts, ref totalSum);
            }

            Console.ReadKey();
        }

        static Queue<int> GenerateRandomQueue(int minimuSellPrice, int maximumSellPrice, int queueDeep)
        {
            var queue = new Queue<int>(queueDeep);
            Random random = new Random();

            for (int i = 0; i < queueDeep; i++)
            {
                queue.Enqueue(random.Next(minimuSellPrice, maximumSellPrice));
            }

            return queue;
        }

        static void ServeСustomer(ref Queue<int> buyersReceipts, ref int totalSum)
        {
            int receipt = buyersReceipts.Dequeue();

            totalSum += receipt;
            Console.WriteLine($"Покупатель приобрел товаров на сумму {receipt}, общий счет магазина:{totalSum}");
            Console.WriteLine("Нажмите клавишу для обработки следующего покупателя.");
            Console.ReadKey();
        }
    }
}
