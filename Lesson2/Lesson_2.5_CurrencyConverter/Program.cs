using System;
using System.Globalization;
using System.Text;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandRubToUsd = "rd";
            const string MenuRubToUsd = "1";
            const string CommandRubToEur = "re";
            const string MenuRubToEur = "2";
            const string CommandEurToUsd = "ed";
            const string MenuEurToUsd = "3";
            const string CommandEurToRub = "er";
            const string MenuEurToRub = "4";
            const string CommandUsdToRub = "dr";
            const string MenuUsdToRub = "5";
            const string CommandUsdToEur = "de";
            const string MenuUsdToEur = "6";
            const string CommandExit = "exit";
            const string MenuExit = "7";

            float balanceRub;
            float balanceUsd;
            float balanceEur;
            float currencyForExchange;
            float coefficientRubToUsd = .012168f;
            float coefficientRubToEur = .011145f; 
            float coefficientUsdToEur = .92f;
            float coefficientUsdToRub = 1/coefficientRubToUsd;
            float coefficientEurToRub = 1/coefficientRubToEur;
            float coefficientEurToUsd = 1/coefficientUsdToEur;
            int startMinimumCurrencyAmmount = 10;
            int startMaximumCurrencyAmmount = 1000;
            string userChoise;
            bool isMainLoopActive = true;
            Random random;

            Console.OutputEncoding = Encoding.UTF8;
            random = new Random();
            balanceRub = Convert.ToSingle(random.Next(startMinimumCurrencyAmmount, startMaximumCurrencyAmmount)* coefficientUsdToRub);
            balanceEur = Convert.ToSingle(random.Next(startMinimumCurrencyAmmount, startMaximumCurrencyAmmount));
            balanceUsd = Convert.ToSingle(random.Next(startMinimumCurrencyAmmount, startMaximumCurrencyAmmount));
            
            while(isMainLoopActive)
            {
                Console.Clear();
                Console.Write("Рублей " + balanceRub.ToString("C", new CultureInfo("ru-RU"))+"  ");
                Console.Write($"Долларов "+ balanceUsd.ToString("C", new CultureInfo("en-US")) + "  ");
                Console.WriteLine($"Евро "+ balanceEur.ToString("C", new CultureInfo("de-DE")) + "  ");
                Console.WriteLine();
                Console.WriteLine($"{MenuRubToUsd}.Поменять рубли на доллары (команда {CommandRubToUsd}) по курсу {coefficientRubToUsd}");
                Console.WriteLine($"{MenuRubToEur}.Поменять рубли на евро (команда {CommandRubToEur}) по курсу {coefficientRubToEur}");
                Console.WriteLine($"{MenuEurToUsd}.Поменять евро на доллары (команда {CommandEurToUsd}) курсу {coefficientEurToUsd}");
                Console.WriteLine($"{MenuEurToRub}.Поменять евро на рубли (команда {CommandEurToRub}) по курсу {coefficientEurToRub}");
                Console.WriteLine($"{MenuUsdToRub}.Поменять доллары на рубли (команда {CommandUsdToRub}) по курсу {coefficientUsdToRub}");
                Console.WriteLine($"{MenuUsdToEur}.Поменять доллары на евро (команда {CommandUsdToEur}) по курсу {coefficientUsdToEur}");
                Console.WriteLine($"{MenuExit}.Выход из программы (команда {CommandExit})");
                userChoise = Console.ReadLine();

                switch (userChoise)
                {
                    case CommandRubToUsd:
                    case MenuRubToUsd:
                        Console.Write("Сколько РУБЛЕЙ на USD хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceRub >= currencyForExchange)
                        {
                            float usdToBuy = currencyForExchange * coefficientRubToUsd;
                            balanceRub -= currencyForExchange;
                            balanceUsd += usdToBuy;

                            Console.WriteLine($"Вы обменяли {currencyForExchange} РУБЛЕЙ на {usdToBuy} ДОЛЛАРОВ.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно РУБЛЕЙ");
                            Console.ReadLine();
                        }

                        break;

                    case CommandRubToEur:
                    case MenuRubToEur:
                        Console.Write("Сколько РУБЛЕЙ на EURO хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceRub >= currencyForExchange)
                        {
                            float eurToBuy = currencyForExchange * coefficientRubToEur;
                            balanceRub -= currencyForExchange;
                            balanceEur += eurToBuy;

                            Console.WriteLine($"Вы обменяли {currencyForExchange} РУБЛЕЙ на {eurToBuy} ЕВРО.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно РУБЛЕЙ");
                            Console.ReadLine();
                        }

                        break;

                    case CommandEurToUsd:
                    case MenuEurToUsd:
                        Console.Write("Сколько EURO на USD хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceEur >= currencyForExchange)
                        {
                            float usdToBuy = currencyForExchange * coefficientEurToUsd;
                            balanceEur -= currencyForExchange;
                            balanceUsd += usdToBuy;

                            Console.WriteLine($"Вы обменяли {currencyForExchange} ЕВРО на {usdToBuy} ДОЛЛАРОВ.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно EUR");
                            Console.ReadLine();
                        }

                        break;

                    case CommandEurToRub:
                    case MenuEurToRub:
                        Console.Write("Сколько EURO на РУБЛИ хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceEur >= currencyForExchange)
                        {
                            float eurToBuy = currencyForExchange * coefficientEurToRub;
                            balanceEur -= currencyForExchange;
                            balanceRub += eurToBuy;

                            Console.WriteLine($"Вы обменяли {currencyForExchange} ЕВРО на {eurToBuy} РУБЛЕЙ.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно EUR");
                            Console.ReadLine();
                        }

                        break;

                    case CommandUsdToRub:
                    case MenuUsdToRub:
                        Console.Write("Сколько USD на РУБЛИ хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceUsd >= currencyForExchange)
                        {
                            float usdToBuy = currencyForExchange * coefficientUsdToRub;
                            balanceUsd -= currencyForExchange;
                            balanceRub += usdToBuy;

                            Console.WriteLine($"Вы обменяли {currencyForExchange} ДОЛЛАРОВ на {usdToBuy} РУБЛЕЙ.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно USD");
                            Console.ReadLine();
                        }

                        break;

                    case CommandUsdToEur:
                    case MenuUsdToEur:
                        Console.Write("Сколько USD на EUR хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceUsd >= currencyForExchange)
                        {
                            float usdToBuy = currencyForExchange * coefficientUsdToEur;
                            balanceUsd -= currencyForExchange;
                            balanceEur += usdToBuy;

                            Console.WriteLine($"Вы обменяли {currencyForExchange} ДОЛЛАРОВ на {usdToBuy} ЕВРО.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно USD");
                            Console.ReadLine();
                        }

                        break;
                        
                    case CommandExit:
                    case MenuExit:
                        isMainLoopActive = false;

                        break;
                }
            }

            Console.WriteLine("Завершение работы программы. Нажмите ENTER что бы закрыть окно");
            Console.ReadLine();
        }
    }
}
