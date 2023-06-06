using System;

namespace Lesson_4._1_PersonalAccounting
{
    class Program
    {
        /*         
        Доработать. 
        1) - Если возвращается одно значение, то нужно использовать return, а не ref или out. [исправил метод AddToArray]
        2) - пустые строки исправил 
        3) - bool isUserInputNumber , я с названием перемудрил, переименовал в isNumber 
        4) - ?? if (index >= array.Length || index < 0) - логичнее эту проверку вынесите в метод - DeletePersonByIndex. 
        5) - Если using не используется, то его следует удалить.
        */

        const string AddCommand = "1";
        const string ShowCommand = "2";
        const string DeletePersonCommand = "3";
        const string FindByFamilyCommand = "4";
        const string ExitCommand = "5";
        const string CancelEnterTextCommand = "no";

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
                    case AddCommand:
                        AddToDossier(ref personsFullName, ref personsPosition);
                        WaitToPressKey();
                        break;

                    case ShowCommand:
                        ShowAllDosier(personsFullName, personsPosition);
                        WaitToPressKey();
                        break;

                    case DeletePersonCommand:
                        DeletePersonByIndex(ref personsFullName, ref personsPosition);
                        WaitToPressKey();
                        break;

                    case FindByFamilyCommand:
                        FindByFamily(personsFullName);
                        WaitToPressKey();
                        break;

                    case ExitCommand:
                        isMainLoopActive = false;
                        break;
                }
            }

            Console.WriteLine("\nДосвиданья!");
            Console.ReadLine();
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
                    Console.WriteLine($" [{i}] {personsFullName[i]} --> {personsPosition[i]}");
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
            isValidateName = ReadValidateText(out personFullName);

            Console.WriteLine($"Введите должность сотрудника.");
            isValidatePosition = ReadValidateText(out personPosition);

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

        static bool ReadValidateText(out string textInput)
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
            Console.WriteLine($"{AddCommand}. {addToDossierMenuText}");
            Console.WriteLine($"{ShowCommand}. {showDossierMenuText}");
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

            Console.WriteLine($"Введите id сотрудника для удаления (или \"{CancelEnterTextCommand}\" для выхода)");
            string userInput = Console.ReadLine();

            if (userInput == CancelEnterTextCommand)
            {
                return;
            }

            int deleteId;
            bool isNumber = Int32.TryParse(userInput, out deleteId);

            if (isNumber && deleteId < personsFullName.Length)
            {
                Console.WriteLine($"Удаляю элемент {deleteId} из базы...");
                DeleteFromArrayByIndex(ref personsFullName, deleteId);
                DeleteFromArrayByIndex(ref personsPosition, deleteId);
            }
            else if (isNumber && deleteId >= personsFullName.Length)
            {
                Console.WriteLine($"id = {deleteId} больше выходит за пределы массива. Введите число меньше.");
            }
            else
            {
                Console.WriteLine("Не могу распарсить введенные данные. Пожалуйста, вводите только цифры.");
            }
        }

        static void DeleteFromArrayByIndex(ref string[] array, int index)
        {
            if (index >= array.Length || index < 0)
                return;

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

            array = bufferArray;
        }

        static void FindByFamily(string[] personsFullName)
        {
            bool isValidateInputSearch;
            string searchString; // так сделать ??? string searchString = ValidateEnter();
            Console.WriteLine($"Введите символы, без учета регистра, для поиска в строке по фамилии (или \"{CancelEnterTextCommand}\" для выхода)");
            isValidateInputSearch = ReadValidateText(out searchString);

            if (!isValidateInputSearch)
            {
                Console.WriteLine("Строка для поиска не может быть пустой или содержать только пробелы.");
                return;
            }

            string[] familyArray = new string[personsFullName.Length];

            for (int i = 0; i < personsFullName.Length; i++)
            {
                familyArray[i] = personsFullName[i].Split(WordsSeparator)[0];
            }

            for (int i = 0; i < familyArray.Length; i++)
            {
                int containedPosition = familyArray[i].IndexOf(searchString, StringComparison.OrdinalIgnoreCase);
                bool isContained = containedPosition >= 0;

                if (isContained)
                    Console.WriteLine($"id =[{i}] Фамилия: {familyArray[i]} содержит подстроку начиная с символа {containedPosition}.");
            }
        }
    }
}
