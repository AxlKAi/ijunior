using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            const string commandRed = "red";
            const string commandYellow = "yellow";
            const string commandBlue = "blue";
            const string commandGreen = "green";
            const string commandWhite = "white";
            const string commandBgBlue = "bgBlue";
            const string commandBgRed = "bgRed";
            const string commandBgDark = "bgDark";
            const string commandAdultChannel = "XXX";
            const string commandChildChannel = "q";
            const string commandExit = "exit";

            bool isItChannelForChildren = true;
            bool mainLoopActive = true;
            ConsoleColor heartColor = ConsoleColor.White;
            ConsoleColor elefantColor = ConsoleColor.White;
            ConsoleColor xxxBackgroundColor = ConsoleColor.Black;
            string userCommand = "";

            Console.OutputEncoding = Encoding.UTF8;

            while (mainLoopActive)
            {
                Console.Clear();

                if (isItChannelForChildren)
                {
                    Console.ForegroundColor = heartColor;
                    Console.WriteLine("░░▄███▄███▄");
                    Console.WriteLine("░░█████████");
                    Console.WriteLine("░░▒▀█████▀░");
                    Console.WriteLine("░░▒░░▀█▀");
                    Console.ForegroundColor = elefantColor;
                    Console.WriteLine("░░▒░░█░");
                    Console.WriteLine("░░▒░█");
                    Console.WriteLine("░░░█");
                    Console.WriteLine("░░█░░░░███████");
                    Console.WriteLine("░██░░░██▓▓███▓██▒");
                    Console.WriteLine("██░░░█▓▓▓▓▓▓▓█▓████");
                    Console.WriteLine("██░░██▓▓▓(◐)▓█▓█▓█");
                    Console.WriteLine("███▓▓▓█▓▓▓▓▓█▓█▓▓▓▓█");
                    Console.WriteLine("▀██▓▓█░██▓▓▓▓██▓▓▓▓▓█");
                    Console.WriteLine("░▀██▀░░█▓▓▓▓▓▓▓▓▓▓▓▓▓█");
                    Console.WriteLine("░░░░▒░░░█▓▓▓▓▓█▓▓▓▓▓▓█");
                    Console.WriteLine("░░░░▒░░░█▓▓▓▓█▓█▓▓▓▓▓█");
                    Console.WriteLine("░▒░░▒░░░█▓▓▓█▓▓▓█▓▓▓▓█");
                    Console.WriteLine("░▒░░▒░░░█▓▓▓█░░░█▓▓▓█");
                    Console.WriteLine("░▒░░▒░░██▓██░░░██▓▓█");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Вы смотрите детский интерактивный ТВ канал.");
                }
                else
                {
                    Console.BackgroundColor = xxxBackgroundColor;
                    Console.WriteLine("⠄⠄⣿⣿⣿⣿⠘⡿⢛⣿⣿⣿⣿⣿⣧⢻⣿⣿⠃⠸⣿⣿⣿⠄⠄⠄⠄⠄");
                    Console.WriteLine("⠄⠄⣿⣿⣿⣿⢀⠼⣛⣛⣭⢭⣟⣛⣛⣛⠿⠿⢆⡠⢿⣿⣿⠄⠄⠄⠄⠄");
                    Console.WriteLine("⠄⠄⠸⣿⣿⢣⢶⣟⣿⣖⣿⣷⣻⣮⡿⣽⣿⣻⣖⣶⣤⣭⡉⠄⠄⠄⠄⠄");
                    Console.WriteLine("⠄⠄⠄⢹⠣⣛⣣⣭⣭⣭⣁⡛⠻⢽⣿⣿⣿⣿⢻⣿⣿⣿⣽⡧⡄⠄⠄⠄");
                    Console.WriteLine("⠄⠄⠄⠄⣼⣿⣿⣿⣿⣿⣿⣿⣿⣶⣌⡛⢿⣽⢘⣿⣷⣿⡻⠏⣛⣀⠄⠄");
                    Console.WriteLine("⠄⠄⠄⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⠙⡅⣿⠚⣡⣴⣿⣿⣿⡆⠄");
                    Console.WriteLine("⠄⠄⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠄⣱⣾⣿⣿⣿⣿⣿⣿⠄");
                    Console.WriteLine("⠄⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢸⣿⣿⣿⣿⣿⣿⣿⣿⠄");
                    Console.WriteLine("⠄⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠣⣿⣿⣿⣿⣿⣿⣿⣿⣿⠄");
                    Console.WriteLine("⠄⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠑⣿⣮⣝⣛⠿⠿⣿⣿⣿⣿⠄");
                    Console.WriteLine("⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⠄⠄⠄⠄⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠄\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Вы смотрите взрослый ТВ канал, уберите детей от экрана ! \n");                    
                }

                Console.WriteLine("Наберите команду");

                if (isItChannelForChildren)
                {
                    Console.WriteLine($"{commandYellow} - Сделать седречко слоника желтым");
                    Console.WriteLine($"{commandRed} - Сделать сердечко красным");
                    Console.WriteLine($"{commandGreen} - Сделать слоника зеленым");
                    Console.WriteLine($"{commandBlue} - Сделать слоника синим");
                    Console.WriteLine($"{commandWhite} - Сделать слоника и сердечко белым");
                    Console.WriteLine($"{commandAdultChannel} - Включить канал для взрослых");
                }
                else
                {                    
                    Console.WriteLine($"{commandBgBlue} - сделать фон синим");
                    Console.WriteLine($"{commandBgRed} - сделать фон красным");
                    Console.WriteLine($"{commandBgDark} - сделать фон черным");
                    Console.WriteLine($"{commandChildChannel} - Включить канал для детей");                    
                }                    
                Console.WriteLine("exit - Выйти из программы");

                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case commandRed:
                        heartColor = ConsoleColor.Red;
                        break;

                    case commandYellow:
                        heartColor = ConsoleColor.Yellow;
                        break;

                    case commandBlue:
                        elefantColor = ConsoleColor.Blue;
                        break;

                    case commandGreen:
                        elefantColor = ConsoleColor.Green;
                        break;

                    case commandWhite:
                        heartColor = ConsoleColor.White;
                        elefantColor = ConsoleColor.White;
                        break;

                    case commandBgBlue:
                        xxxBackgroundColor = ConsoleColor.Blue;
                        break;

                    case commandBgRed:
                        xxxBackgroundColor = ConsoleColor.Red;
                        break;

                    case commandBgDark:
                        xxxBackgroundColor = ConsoleColor.Black;
                        break;                        

                    case commandAdultChannel:
                        isItChannelForChildren = false;
                        break;

                    case commandChildChannel:
                        isItChannelForChildren = true;
                        break;

                    case commandExit:
                        mainLoopActive = false;
                        break;

                    default:
                        Console.WriteLine("Не узнаю такую команду. Нажмите ENTER для повторной попытки.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
