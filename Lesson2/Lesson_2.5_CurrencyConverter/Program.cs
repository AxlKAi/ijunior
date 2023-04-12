using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            float currencyRub = 0;
            float currencyUsd = 0;
            float currencyEur = 0;
            float currencyForExchange;
            float coefficientRubToUsd = .012168f;
            float coefficientRubToEur = .011145f; 
            float coefficientUsdToEur = .92f;
            int startMinimumCurrencyAmmount = 10;
            int startMaximumCurrencyAmmount = 1000;
            int userChoise;
            bool mainLoopActive = true;
            Random rand;

            Console.OutputEncoding = Encoding.UTF8;
            rand = new Random();
            currencyRub = Convert.ToSingle(rand.Next(startMinimumCurrencyAmmount, startMaximumCurrencyAmmount)/coefficientRubToUsd);
            currencyEur = Convert.ToSingle(rand.Next(startMinimumCurrencyAmmount, startMaximumCurrencyAmmount));
            currencyUsd = Convert.ToSingle(rand.Next(startMinimumCurrencyAmmount, startMaximumCurrencyAmmount));
            
            while(mainLoopActive)
            {
                Console.Clear();
                Console.Write("Рублей " + currencyRub.ToString("C", new CultureInfo("ru-RU"))+"  ");
                Console.Write($"Долларов "+ currencyUsd.ToString("C", new CultureInfo("en-US")) + "  ");
                Console.WriteLine($"Евро "+ currencyEur.ToString("C", new CultureInfo("de-DE")) + "  ");
                Console.WriteLine("1.Поменять рубли на доллары");
                Console.WriteLine("2.Поменять рубли на евро");
                Console.WriteLine("3.Поменять евро на доллары");
                Console.WriteLine("4.Поменять евро на рубли");
                Console.WriteLine("5.Поменять доллары на рубли");
                Console.WriteLine("6.Поменять доллары на евро");
                Console.WriteLine("7.Выход из программы");
                userChoise = Convert.ToInt32(Console.ReadLine());

                switch (userChoise)
                {
                    case 1:
                        Console.Write("Сколько РУБЛЕЙ на USD хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (currencyRub >= currencyForExchange)
                        {
                            currencyRub -= currencyForExchange;
                            currencyUsd += currencyForExchange * coefficientRubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно РУБЛЕЙ");
                            Console.ReadLine();
                        }
                        break;

                    case 2:
                        Console.Write("Сколько РУБЛЕЙ на EURO хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (currencyRub >= currencyForExchange)
                        {
                            currencyRub -= currencyForExchange;
                            currencyEur += currencyForExchange * coefficientRubToEur;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно РУБЛЕЙ");
                            Console.ReadLine();
                        }
                        break;

                    case 3:
                        Console.Write("Сколько EURO на USD хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (currencyEur >= currencyForExchange)
                        {
                            currencyEur -= currencyForExchange;
                            currencyUsd += currencyForExchange / coefficientUsdToEur;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно EUR");
                            Console.ReadLine();
                        }
                        break;

                    case 4:
                        Console.Write("Сколько EURO на РУБЛИ хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (currencyEur >= currencyForExchange)
                        {
                            currencyEur -= currencyForExchange;
                            currencyRub += currencyForExchange / coefficientRubToEur;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно EUR");
                            Console.ReadLine();
                        }
                        break;

                    case 5:
                        Console.Write("Сколько USD на РУБЛИ хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (currencyUsd >= currencyForExchange)
                        {
                            currencyUsd -= currencyForExchange;
                            currencyRub += currencyForExchange / coefficientRubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно USD");
                            Console.ReadLine();
                        }
                        break;

                    case 6:
                        Console.Write("Сколько USD на EUR хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (currencyUsd >= currencyForExchange)
                        {
                            currencyUsd -= currencyForExchange;
                            currencyEur += currencyForExchange * coefficientUsdToEur;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно USD");
                            Console.ReadLine();
                        }
                        break;
                    case 7:
                        mainLoopActive = false;
                        break;
                }
            }

            Console.WriteLine("Завершение работы программы. Нажмите ENTER что бы закрыть окно");
            Console.ReadLine();
        }
    }
}
