using System;

namespace Lesson_4._1_PersonalAccounting
{
    class Program
    {
        const string AddPersonCommand = "1";
        const string ShowAllPersonsCommand = "2";
        const string DeletePersonCommand = "3";
        const string FindByFamilyCommand = "4";
        const string ExitCommand = "5";
        const string CancelTextCommand = "no";

        const char WordsSeparator = ' ';

        static void Main(string[] args)
        {
            string[] personsFullName = { "Петров Петр Петрович", "Иванов Иван Иванович", "Сидоров Сидор Сидорович", "Иванкин Иванок Иванкович" };
            string[] personsPosition = { "Дилехтор", "Водитель приятеля", "Фантазёр", "Звездочет" };

            bool isMainLoopActive = true;

            while (isMainLoopActive)
            {
                ShowMainMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddPersonCommand:
                        AddToDossier(ref personsFullName, ref personsPosition);
                        break;

                    case ShowAllPersonsCommand:
                        ShowAllDosier(personsFullName, personsPosition);
                        break;

                    case DeletePersonCommand:
                        DeletePersonByIndex(ref personsFullName, ref personsPosition);
                        break;

                    case FindByFamilyCommand:
                        ShowBySurname(personsFullName);                        
                        break;

                    case ExitCommand:
                        isMainLoopActive = false;
                        Console.WriteLine("\nДосвиданья!");
                        break;
                }

                WaitToPressKey();
            }
        }

        static void WaitToPressKey()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения.....");
            Console.ReadKey();
        }

        static void ShowAllDosier(string[] personsFullName, string[] personsPosition)
        {
            if (personsFullName.Length > 0)
            {
                for (int i = 0; i < personsFullName.Length; i++)
                {
                    Console.WriteLine($" [{i}] {personsFullName[i]} - {personsPosition[i]}");
                }
            }
            else
            {
                Console.WriteLine("Досье пусто...");
            }
        }

        static void AddToDossier(ref string[] personsFullName, ref string[] personsPosition)
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
                Console.WriteLine($"Добавляем в базу: {personFullName} на должности {personPosition}");
                personsFullName = AddToArray(personsFullName, personFullName);
                personsPosition = AddToArray(personsPosition, personPosition);
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных, поля не могут быть пустыми или содержать только пробелы.");
            }
        }

        static string[] AddToArray(string[] array, string addingElement)
        {
            string[] bufferArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                bufferArray[i] = array[i];
            }

            bufferArray[bufferArray.Length - 1] = addingElement;
            return bufferArray;
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

        static void ShowMainMenu()
        {
            string addToDossierMenuText = "Добавить в досье.";
            string showDossierMenuText = "Показать все досье.";
            string deletePersonMenuText = "Удалить запись из досье.";
            string findByFamilyMenuText = "Найти по фамилии.";
            string exitMenuText = "Выход.";

            Console.Clear();
            Console.WriteLine($"{AddPersonCommand}. {addToDossierMenuText}");
            Console.WriteLine($"{ShowAllPersonsCommand}. {showDossierMenuText}");
            Console.WriteLine($"{DeletePersonCommand}. {deletePersonMenuText}");
            Console.WriteLine($"{FindByFamilyCommand}. {findByFamilyMenuText}");
            Console.WriteLine($"{ExitCommand}. {exitMenuText}");
            Console.WriteLine();
        }

        static void DeletePersonByIndex(ref string[] personsFullName, ref string[] personsPosition)
        {
            if (personsPosition.Length == 0 || personsFullName.Length == 0)
            {
                Console.WriteLine("Досье пусто...");
                return;
            }

            ShowAllDosier(personsFullName, personsPosition);

            Console.WriteLine($"Введите id сотрудника для удаления (или \"{CancelTextCommand}\" для выхода)");
            string userInput = Console.ReadLine();

            if (userInput == CancelTextCommand)
            {
                return;
            }

            int deleteId;

            if (Int32.TryParse(userInput, out deleteId))
            {
                Console.WriteLine($"Удаляю элемент {deleteId} из базы...");

                if (deleteId >= 0 && deleteId <= personsFullName.Length)
                {
                    personsFullName = DeleteFromArrayByIndex(personsFullName, deleteId);
                    personsPosition = DeleteFromArrayByIndex(personsPosition, deleteId);
                }
                else
                {
                    Console.WriteLine($"id = {deleteId} выходит за пределы массива. Введите число меньше.");
                }
            }
            else
            {
                Console.WriteLine("Не могу распарсить введенные данные. Пожалуйста, вводите только цифры.");
            }
        }

        static string[] DeleteFromArrayByIndex(string[] array, int index)
        {           
            int bufferArraySize = array.Length - 1;
            string[] bufferArray = new string[bufferArraySize];

            for (int i = 0; i < index; i++)
            {
                bufferArray[i] = array[i];
            }

            for (int i = index; i < bufferArray.Length; i++)
            {
                bufferArray[i] = array[i + 1];
            }

            return bufferArray;
        }

        static void ShowBySurname(string[] personsFullName)
        {
            string searchString; 
            Console.WriteLine($"Введите символы, без учета регистра, для поиска в строке по фамилии (или \"{CancelTextCommand}\" для выхода)");

            if (TryReadText(out searchString) == false)
            {
                Console.WriteLine("Строка для поиска не может быть пустой или содержать только пробелы.");
                return;
            }

            string[] surnames = new string[personsFullName.Length];

            for (int i = 0; i < personsFullName.Length; i++)
            {
                surnames[i] = personsFullName[i].Split(WordsSeparator)[0];
            }

            bool isAtLeastOneContain = false;
            bool isContained = false;

            for (int i = 0; i < surnames.Length; i++)
            {
                int containedPosition = surnames[i].IndexOf(searchString, StringComparison.OrdinalIgnoreCase);
                isContained = containedPosition >= 0;

                if (isContained)
                {
                    containedPosition++;
                    Console.WriteLine($"id =[{i}] Фамилия: {surnames[i]} " +
                        $"содержит подстроку начиная с символа {containedPosition}.");
                    isAtLeastOneContain = true;
                }                    
            }

            if(isAtLeastOneContain == false)
                Console.WriteLine($"Не удалось найти ничего похожего на {searchString}.");
        }
    }
}
