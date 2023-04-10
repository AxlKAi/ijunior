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
            int grandmamServiceMinutes = 10;
            Console.WriteLine("Вы заходите в поликлинику и видите огромную очередь из старушек.");
            Console.Write("Введите, сколько старушек в очереди перед вами ? :");
            grandmamCount = Convert.ToInt32(Console.ReadLine());
            queueTotalMinutes = grandmamCount * grandmamServiceMinutes;
            queueHours = queueTotalMinutes / 60;
            queueMinutes = queueTotalMinutes % (queueHours*60);
            Console.WriteLine($"Одна бабушка пробудет у доктора {grandmamServiceMinutes} минут.");
            Console.WriteLine($"Постарайтесь не упасть в обморок, вам еще ждать {queueHours} часов и {queueMinutes} минут"); ;
            Console.ReadLine();
        }
    }
}
