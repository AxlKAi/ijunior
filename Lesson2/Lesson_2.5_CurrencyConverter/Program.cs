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
            const string CommandRubToUsd = "RubToUsd";
            const string NumCommandRubToUsd = "1";
            const string CommandRubToEur = "RubToEur";
            const string NumCommandRubToEur = "2";
            const string CommandEurToUsd = "EurToUsd";
            const string NumCommandEurToUsd = "3";
            const string CommandEurToRub = "EurToRub";
            const string NumCommandEurToRub = "4";
            const string CommandUsdToRub = "UsdToRub";
            const string NumCommandUsdToRub = "5";
            const string CommandUsdToEur = "UsdToEur";
            const string NumCommandUsdToEur = "6";
            const string CommandExit = "exit";
            const string NumCommandExit = "7";

            float currencyRub = 0;
            float currencyUsd = 0;
            float currencyEur = 0;
            float currencyForExchange;
            float coefficientRubToUsd = .012168f;
            float coefficientRubToEur = .011145f; 
            float coefficientUsdToEur = .92f;
            int startMinimumCurrencyAmmount = 10;
            int startMaximumCurrencyAmmount = 1000;
            string userChoise;
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
                Console.WriteLine($"{NumCommandRubToUsd}.Поменять рубли на доллары (команда {CommandRubToUsd})");
                Console.WriteLine($"{NumCommandRubToEur}.Поменять рубли на евро (команда {CommandRubToEur})");
                Console.WriteLine($"{NumCommandEurToUsd}.Поменять евро на доллары (команда {CommandEurToUsd})");
                Console.WriteLine($"{NumCommandEurToRub}.Поменять евро на рубли (команда {CommandEurToRub})");
                Console.WriteLine($"{NumCommandUsdToRub}.Поменять доллары на рубли (команда {CommandUsdToRub})");
                Console.WriteLine($"{NumCommandUsdToEur}.Поменять доллары на евро (команда {CommandUsdToEur})");
                Console.WriteLine($"{NumCommandExit}.Выход из программы (команда {CommandExit})");
                userChoise = Console.ReadLine();

                switch (userChoise)
                {
                    case CommandRubToUsd:
                    case NumCommandRubToUsd:
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

                    case CommandRubToEur:
                    case NumCommandRubToEur:
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

                    case CommandEurToUsd:
                    case NumCommandEurToUsd:
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

                    case CommandEurToRub:
                    case NumCommandEurToRub:
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

                    case CommandUsdToRub:
                    case NumCommandUsdToRub:
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

                    case CommandUsdToEur:
                    case NumCommandUsdToEur:
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
                        
                    case CommandExit:
                    case NumCommandExit:
                        mainLoopActive = false;
                        break;
                }
            }

            Console.WriteLine("Завершение работы программы. Нажмите ENTER что бы закрыть окно");
            Console.ReadLine();
        }
    }
}
