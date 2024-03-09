using System;
using System.Collections.Generic;

namespace Lesson_5_4_PersonalAccountingProgressive
{
    class Program
    {

        static void Main(string[] args)
        {
            const string AddCommand = "1";
            const string ShowCommand = "2";
            const string DeletePersonCommand = "3";
            const string ExitCommand = "4";

            Dictionary<string, string> personsPositions= new Dictionary<string, string>()
            {
                ["Петров Петр Петрович"] = "Дилехтор",
                ["Иванов Иван Иванович"] = "Водитель",
                ["Сидоров Сидор Сидорович"] = "приятеля",
                ["Иванкин Иванок Иванкович"] = "Фантазёр",
            };

            bool isMainLoopActive = true;

            while (isMainLoopActive)
            {
                ShowMainMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddCommand:
                        AddToDossier(personsPositions);
                        WaitToPressKey();
                        break;

                    case ShowCommand:
                        ShowAllDosier(personsPositions);
                        WaitToPressKey();
                        break;

                    case DeletePersonCommand:
                        DeletePersonByFullName(personsPositions);
                        WaitToPressKey();
                        break;

                    case ExitCommand:
                        isMainLoopActive = false;
                        break;
                }
            }

            Console.WriteLine("\nДосвиданья!");
            Console.ReadLine();

            void ShowMainMenu()
            {
                string addToDossierMenuText = "Добавить в досье.";
                string showDossierMenuText = "Показать все досье.";
                string deletePersonMenuText = "Удалить запись из досье.";
                string exitMenuText = "Выход.";

                Console.Clear();
                Console.WriteLine($"{AddCommand}. {addToDossierMenuText}");
                Console.WriteLine($"{ShowCommand}. {showDossierMenuText}");
                Console.WriteLine($"{DeletePersonCommand}. {deletePersonMenuText}");
                Console.WriteLine($"{ExitCommand}. {exitMenuText}");
                Console.WriteLine();
            }
        }

        static void WaitToPressKey()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения.....");
            Console.ReadKey();
        }

        static void ShowAllDosier(Dictionary<string, string> personsPositions)
        {
            if (personsPositions.Count > 0)
            {
                foreach (var person in personsPositions)
                {
                    Console.WriteLine($"{person.Key} --> {person.Value}");
                }
            }
            else
            {
                Console.WriteLine("Досье пусто...");
            }
        }

        static void AddToDossier(Dictionary<string, string> personsPositions)
        {
            string personFullName;
            string personPosition;
            bool isValidateName;
            bool isValidatePosition;

            Console.WriteLine($"Введите Фамилию Имя и Отчество сотрудника.");
            isValidateName = TryReadText(out personFullName);

            Console.WriteLine($"Введите должность сотрудника.");
            isValidatePosition = TryReadText(out personPosition);

            if (isValidatePosition && isValidateName)
            {
                if (personsPositions.ContainsKey(personFullName) == false)
                {
                    Console.WriteLine($"Добавляем в базу: {personFullName} на должности {personPosition}");
                    personsPositions.Add(personFullName, personPosition);
                }
                else
                {
                    Console.WriteLine($"Элемент: {personFullName} уже существует на должности {personsPositions[personFullName]}");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных, поля не могут быть пустыми или содержать только пробелы. ФИО не моежт дублироваться.");
            }
        }

        static bool TryReadText(out string textInput)
        {
            Console.Write(":");
            textInput = Console.ReadLine();
            textInput = System.Text.RegularExpressions.Regex.Replace(textInput, @"\s+", " ");

            if (textInput == "" || textInput == " ")
                return false;
            else
                return true;
        }

        static void DeletePersonByFullName(Dictionary<string,string> personsPositions)
        {
            const string CancelEnterTextCommand = "no";

            if (personsPositions.Count == 0)
            {
                Console.WriteLine("Досье пусто...");
                return;
            }

            ShowAllDosier(personsPositions);

            Console.WriteLine($"Введите ФИО сотрудника для удаления (или \"{CancelEnterTextCommand}\" для выхода)");
            string userInput = Console.ReadLine();

            if (userInput == CancelEnterTextCommand)
            {
                return;
            }

            if (personsPositions.ContainsKey(userInput))
            {
                Console.WriteLine($"Удаляю  ФИО \"{userInput}\" на должности {personsPositions[userInput]} из базы...");
                personsPositions.Remove(userInput);
            }
            else
            {
                Console.WriteLine($"Не могу найти ФИО=\"{userInput}\".");
            }
        }
    }
}
