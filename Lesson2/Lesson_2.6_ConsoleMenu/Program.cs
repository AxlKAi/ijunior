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
            const string CommandRed = "red";
            const string CommandYellow = "yellow";
            const string CommandBlue = "blue";
            const string CommandGreen = "green";
            const string CommandWhite = "white";
            const string CommandBackgroundBlue = "bgBlue";
            const string CommandBackgroundRed = "bgRed";
            const string CommandBackgroundDark = "bgDark";
            const string CommandAdultChannel = "XXX";
            const string CommandChildChannel = "q";
            const string CommandExit = "exit";

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
                    Console.WriteLine($"{CommandYellow} - Сделать седречко слоника желтым");
                    Console.WriteLine($"{CommandRed} - Сделать сердечко красным");
                    Console.WriteLine($"{CommandGreen} - Сделать слоника зеленым");
                    Console.WriteLine($"{CommandBlue} - Сделать слоника синим");
                    Console.WriteLine($"{CommandWhite} - Сделать слоника и сердечко белым");
                    Console.WriteLine($"{CommandAdultChannel} - Включить канал для взрослых");
                }
                else
                {                    
                    Console.WriteLine($"{CommandBackgroundBlue} - сделать фон синим");
                    Console.WriteLine($"{CommandBackgroundRed} - сделать фон красным");
                    Console.WriteLine($"{CommandBackgroundDark} - сделать фон черным");
                    Console.WriteLine($"{CommandChildChannel} - Включить канал для детей");                    
                }  
                
                Console.WriteLine("exit - Выйти из программы");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case CommandRed:
                        heartColor = ConsoleColor.Red;
                        break;

                    case CommandYellow:
                        heartColor = ConsoleColor.Yellow;
                        break;

                    case CommandBlue:
                        elefantColor = ConsoleColor.Blue;
                        break;

                    case CommandGreen:
                        elefantColor = ConsoleColor.Green;
                        break;

                    case CommandWhite:
                        heartColor = ConsoleColor.White;
                        elefantColor = ConsoleColor.White;
                        break;

                    case CommandBackgroundBlue:
                        AdultBackgroundColor = ConsoleColor.Blue;
                        break;

                    case CommandBackgroundRed:
                        AdultBackgroundColor = ConsoleColor.Red;
                        break;

                    case CommandBackgroundDark:
                        AdultBackgroundColor = ConsoleColor.Black;
                        break;                        

                    case CommandAdultChannel:
                        isChannelForChildren = false;
                        break;

                    case CommandChildChannel:
                        isChannelForChildren = true;
                        break;

                    case CommandExit:
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
