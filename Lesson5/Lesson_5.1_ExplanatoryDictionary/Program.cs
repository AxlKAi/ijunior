using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplanatoryDictionary
{
    class Program
    {
        const string ExitCommand = "EXIT";
        static void Main(string[] args)
        {
            bool isMainLoopActive = true;

            var wordsDictionary = new Dictionary<string, string>()
            {
                ["ВАГОН"] = "Несамоходное (при оборудовании мотором самоходное) транспортное средство движущееся по рельсам",
                ["БАБОЧКА"] = "Насекомое с двумя парами крыльев разнообразной окраски, покрытых мельчайшими чешуйками.",
                ["ДА"] = "да, частица. Употр. при ответе для выражения утверждения, согласия. Все здесь? Да. Ты меня понял? Да."
            };

            Console.WriteLine("Содержание словаря:");

            foreach (var word in wordsDictionary)
            {
                Console.WriteLine($"{word.Key} : {word.Value}");
                Console.WriteLine();
            }

            while(isMainLoopActive)
            {
                Console.Write($"Введите какое слово найти ({ExitCommand} для выхода) :");
                string searchString = Console.ReadLine();
                searchString = searchString.ToUpper();

                if (wordsDictionary.ContainsKey(searchString))
                {
                    Console.WriteLine($"{searchString} --> {wordsDictionary[searchString]}");
                }
                else if(searchString == ExitCommand)
                {
                    isMainLoopActive = false;
                    Console.WriteLine("Программа завершается, нажмите любую клавишу.");
                }
                else
                {
                    Console.WriteLine($"Слова \"{searchString}\" не найдено в словаре.");
                }
            }

            Console.ReadKey();
        }
    }
}
