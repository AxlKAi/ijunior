using System;
using System.Globalization;
using System.Text;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandRubToUsd = "RubToUsd";
            const string NumberCommandRubToUsd = "1";
            const string CommandRubToEur = "RubToEur";
            const string NumberCommandRubToEur = "2";
            const string CommandEurToUsd = "EurToUsd";
            const string NumberCommandEurToUsd = "3";
            const string CommandEurToRub = "EurToRub";
            const string NumberCommandEurToRub = "4";
            const string CommandUsdToRub = "UsdToRub";
            const string NumberCommandUsdToRub = "5";
            const string CommandUsdToEur = "UsdToEur";
            const string NumberCommandUsdToEur = "6";
            const string CommandExit = "exit";
            const string NumberCommandExit = "7";

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
                Console.WriteLine($"{NumberCommandRubToUsd}.Поменять рубли на доллары (команда {CommandRubToUsd})");
                Console.WriteLine($"{NumberCommandRubToEur}.Поменять рубли на евро (команда {CommandRubToEur})");
                Console.WriteLine($"{NumberCommandEurToUsd}.Поменять евро на доллары (команда {CommandEurToUsd})");
                Console.WriteLine($"{NumberCommandEurToRub}.Поменять евро на рубли (команда {CommandEurToRub})");
                Console.WriteLine($"{NumberCommandUsdToRub}.Поменять доллары на рубли (команда {CommandUsdToRub})");
                Console.WriteLine($"{NumberCommandUsdToEur}.Поменять доллары на евро (команда {CommandUsdToEur})");
                Console.WriteLine($"{NumberCommandExit}.Выход из программы (команда {CommandExit})");
                userChoise = Console.ReadLine();

                switch (userChoise)
                {
                    case CommandRubToUsd:
                    case NumberCommandRubToUsd:
                        Console.Write("Сколько РУБЛЕЙ на USD хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceRub >= currencyForExchange)
                        {
                            balanceRub -= currencyForExchange;
                            balanceUsd += currencyForExchange * coefficientRubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно РУБЛЕЙ");
                            Console.ReadLine();
                        }

                        break;

                    case CommandRubToEur:
                    case NumberCommandRubToEur:
                        Console.Write("Сколько РУБЛЕЙ на EURO хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceRub >= currencyForExchange)
                        {
                            balanceRub -= currencyForExchange;
                            balanceEur += currencyForExchange * coefficientRubToEur;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно РУБЛЕЙ");
                            Console.ReadLine();
                        }

                        break;

                    case CommandEurToUsd:
                    case NumberCommandEurToUsd:
                        Console.Write("Сколько EURO на USD хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceEur >= currencyForExchange)
                        {
                            balanceEur -= currencyForExchange;
                            balanceUsd += currencyForExchange * coefficientEurToUsd;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно EUR");
                            Console.ReadLine();
                        }

                        break;

                    case CommandEurToRub:
                    case NumberCommandEurToRub:
                        Console.Write("Сколько EURO на РУБЛИ хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceEur >= currencyForExchange)
                        {
                            balanceEur -= currencyForExchange;
                            balanceRub += currencyForExchange * coefficientEurToRub;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно EUR");
                            Console.ReadLine();
                        }

                        break;

                    case CommandUsdToRub:
                    case NumberCommandUsdToRub:
                        Console.Write("Сколько USD на РУБЛИ хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceUsd >= currencyForExchange)
                        {
                            balanceUsd -= currencyForExchange;
                            balanceRub += currencyForExchange * coefficientUsdToRub;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно USD");
                            Console.ReadLine();
                        }

                        break;

                    case CommandUsdToEur:
                    case NumberCommandUsdToEur:
                        Console.Write("Сколько USD на EUR хотите обменять ?: ");
                        currencyForExchange = Convert.ToSingle(Console.ReadLine());

                        if (balanceUsd >= currencyForExchange)
                        {
                            balanceUsd -= currencyForExchange;
                            balanceEur += currencyForExchange * coefficientUsdToEur;
                        }
                        else
                        {
                            Console.WriteLine("У Вас не достаточно USD");
                            Console.ReadLine();
                        }

                        break;
                        
                    case CommandExit:
                    case NumberCommandExit:
                        isMainLoopActive = false;

                        break;
                }
            }

            Console.WriteLine("Завершение работы программы. Нажмите ENTER что бы закрыть окно");
            Console.ReadLine();
        }
    }
}
