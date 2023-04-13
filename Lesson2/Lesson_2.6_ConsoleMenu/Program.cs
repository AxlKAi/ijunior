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
            const string commandBackgroundBlue = "bgBlue";
            const string commandBackgroundRed = "bgRed";
            const string commandBackgroundDark = "bgDark";
            const string commandAdultChannel = "XXX";
            const string commandChildChannel = "q";
            const string commandExit = "exit";

            bool isChannelForChildren = true;
            bool isMainLoopActive = true;
            ConsoleColor heartColor = ConsoleColor.White;
            ConsoleColor elefantColor = ConsoleColor.White;
            ConsoleColor AdultBackgroundColor = ConsoleColor.Black;
            ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
            ConsoleColor DefaultForegroundColor = ConsoleColor.White;
            string userCommand = "";

            Console.OutputEncoding = Encoding.UTF8;

            while (isMainLoopActive)
            {
                Console.Clear();

                if (isChannelForChildren)
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
                    Console.ForegroundColor = DefaultForegroundColor;
                    Console.WriteLine("Вы смотрите детский интерактивный ТВ канал.");
                }
                else
                {
                    Console.BackgroundColor = AdultBackgroundColor;
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
                    Console.BackgroundColor = DefaultBackgroundColor;
                    Console.WriteLine("Вы смотрите взрослый ТВ канал, уберите детей от экрана ! \n");                    
                }
                Console.WriteLine("Наберите команду");

                if (isChannelForChildren)
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
                    Console.WriteLine($"{commandBackgroundBlue} - сделать фон синим");
                    Console.WriteLine($"{commandBackgroundRed} - сделать фон красным");
                    Console.WriteLine($"{commandBackgroundDark} - сделать фон черным");
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

                    case commandBackgroundBlue:
                        AdultBackgroundColor = ConsoleColor.Blue;
                        break;

                    case commandBackgroundRed:
                        AdultBackgroundColor = ConsoleColor.Red;
                        break;

                    case commandBackgroundDark:
                        AdultBackgroundColor = ConsoleColor.Black;
                        break;                        

                    case commandAdultChannel:
                        isChannelForChildren = false;
                        break;

                    case commandChildChannel:
                        isChannelForChildren = true;
                        break;

                    case commandExit:
                        isMainLoopActive = false;
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
