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
                    Console.WriteLine("yellow - Сделать седречко слоника желтым");
                    Console.WriteLine("red - Сделать сердечко красным");
                    Console.WriteLine("green - Сделать слоника зеленым");
                    Console.WriteLine("blue - Сделать слоника синим");
                    Console.WriteLine("white - Сделать слоника и сердечко белым");
                    Console.WriteLine("xxx - Включить канал для взрослых");
                }
                else
                {                    
                    Console.WriteLine("bgBlue - сделать фон синим");
                    Console.WriteLine("bgRed - сделать фон красным");
                    Console.WriteLine("bgDark - сделать фон черным");
                    Console.WriteLine("q - Включить канал для детей");                    
                }                    
                Console.WriteLine("exit - Выйти из программы");

                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "red":
                        heartColor = ConsoleColor.Red;
                        break;

                    case "yellow":
                        heartColor = ConsoleColor.Yellow;
                        break;

                    case "blue":
                        elefantColor = ConsoleColor.Blue;
                        break;

                    case "green":
                        elefantColor = ConsoleColor.Green;
                        break;

                    case "white":
                        heartColor = ConsoleColor.White;
                        elefantColor = ConsoleColor.White;
                        break;

                    case "bgBlue":
                        xxxBackgroundColor = ConsoleColor.Blue;
                        break;

                    case "bgRed":
                        xxxBackgroundColor = ConsoleColor.Red;
                        break;

                    case "bgDark":
                        xxxBackgroundColor = ConsoleColor.Black;
                        break;                        

                    case "xxx":
                        isItChannelForChildren = false;
                        break;

                    case "q" :
                        isItChannelForChildren = true;
                        break;

                    case "exit":
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
