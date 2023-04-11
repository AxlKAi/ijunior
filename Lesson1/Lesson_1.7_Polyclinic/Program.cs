using System;

namespace Polyclinic
{
    class Program
    {
        static void Main(string[] args)
        {
            int queueMinutes;
            int queueHours;
            int queueTotalMinutes;
            int grandmamCount;
            int grandmamServiceInMinutes = 10;
            int minutesInHour = 60;

            Console.WriteLine("Вы заходите в поликлинику и видите огромную очередь из старушек.");
            Console.Write("Введите, сколько старушек в очереди перед вами ? :");
            grandmamCount = Convert.ToInt32(Console.ReadLine());
            queueTotalMinutes = grandmamCount * grandmamServiceInMinutes;
            queueHours = queueTotalMinutes / minutesInHour;
            queueMinutes = queueTotalMinutes % minutesInHour;
            Console.WriteLine($"Одна бабушка пробудет у доктора {grandmamServiceInMinutes} минут.");
            Console.WriteLine($"Постарайтесь не упасть в обморок, вам еще ждать {queueHours} часов и {queueMinutes} минут"); ;
            Console.ReadLine();
        }
    }
}
