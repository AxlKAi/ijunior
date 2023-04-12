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
            Random rand;
            int userChoise;

            Console.OutputEncoding = Encoding.UTF8;
            rand = new Random();
            currencyRub = Convert.ToSingle(rand.Next(startMinimumCurrencyAmmount, startMaximumCurrencyAmmount));
            currencyEur = Convert.ToSingle(rand.Next(startMinimumCurrencyAmmount, startMaximumCurrencyAmmount));
            currencyUsd = Convert.ToSingle(rand.Next(startMinimumCurrencyAmmount, startMaximumCurrencyAmmount));
            
            while(true)
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
                if (userChoise == 7)
                    break;

                Console.Write("Сколько хотите обменять ?: ");
                currencyForExchange = Convert.ToSingle(Console.ReadLine());

                switch (userChoise)
                {
                    case 1:
                        if (currencyRub>=currencyForExchange)
                        {
                            currencyRub -= currencyForExchange;
                            currencyUsd += currencyForExchange * coefficientRubToUsd;
                        }
                        break;

                    case 2:
                        if (currencyRub >= currencyForExchange)
                        {
                            currencyRub -= currencyForExchange;
                            currencyEur += currencyForExchange * coefficientRubToEur;
                        }
                        break;

                    case 3:
                        if (currencyEur >= currencyForExchange)
                        {
                            currencyEur -= currencyForExchange;
                            currencyUsd += currencyForExchange / coefficientUsdToEur;
                        }
                        break;

                    case 4:
                        if (currencyEur >= currencyForExchange)
                        {
                            currencyEur -= currencyForExchange;
                            currencyRub += currencyForExchange / coefficientRubToEur;
                        }
                        break;

                    case 5:
                        if (currencyUsd >= currencyForExchange)
                        {
                            currencyUsd -= currencyForExchange;
                            currencyRub += currencyForExchange / coefficientRubToUsd;
                        }
                        break;

                    case 6:
                        if (currencyUsd >= currencyForExchange)
                        {
                            currencyUsd -= currencyForExchange;
                            currencyEur += currencyForExchange * coefficientUsdToEur;
                        }
                        break;
                }
            }

            Console.WriteLine("Завершение работы программы. Нажмите ENTER что бы закрыть окно");
            Console.ReadLine();
        }
    }
}
