using System;

namespace ProgrammUnderPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "zzz";
            string userInput;
            bool userGrantAccess = false;
            int tryCount = 3;

            while (tryCount > 0)
            {
                Console.WriteLine($"Введите пароль (осталось {tryCount} попыток) :");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    userGrantAccess = true;
                    break;
                }

                tryCount--;
            }

            if (userGrantAccess)
            {
                Console.WriteLine("Пин-код от моей карточки 2456, но это секрет.");
            }
            else
            {
                Console.WriteLine("Вы не знаете пароль, доступ запрещен. ");
            }

            Console.WriteLine("Нажмите клавишу для завершение программы.");
            Console.ReadKey();
        }
    }
}
