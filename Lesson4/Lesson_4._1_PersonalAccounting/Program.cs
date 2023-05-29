using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson_4._1_PersonalAccounting
{
    class Program
    {
        const string AddToDossierMenuText = "Добавить в досье.";
        const int AddCommand = 1;
        const string ShowDossierMenuText = "Показать все досье.";
        const int ShowCommand = 2;
        const string DeletePersonMenuText = "Удалить запись из досье.";
        const int DeletePersonCommand = 3;
        const string FindByFamilyMenuText = "Найти по фамилии.";
        const int FindByFamilyCommand = 4;
        const string ExitMenuText = "Выход.";
        const int ExitCommand = 5;
        const string CancelEnterTextCommand = "no";

        //можно я разобью данные на 4 разных массива, которые связаны по index, он же id
        static string[] personsFamily = {"Петров", "Иванов", "Сидоров", "Иванкин"};
        static string[] personsName = {"Петр", "Иван", "Сидор", "Иванок"};
        static string[] personsPatronymic = {"Петрович", "Иванович", "Сидорович", "Иванкович"};
        static string[] personsPosition = {"Дилехтор", "Водитель приятеля", "Фантазёр", "Звездочет"};

        static void Main(string[] args)
        {
            bool isMainLoopActive = true;

            while (isMainLoopActive)
            {
                ShowMainMenu();
                string userInput = Console.ReadLine(); // Нам религия позволяет вот так инициализировать переменную после вывода меню ? 
                int choiseNumber;

                if (Int32.TryParse(userInput, out choiseNumber)) //? в if я поставлю парсинг импута, это норм ?
                {
                    switch (choiseNumber)
                    {
                        case 1:
                            AddToDossier();
                            break;

                        case 2:
                            ShowAllDosier();
                            WaitToPressKey();
                            break;

                        case 3:
                            DeletePersonByIndex();
                            WaitToPressKey();
                            break;

                        case 4:
                            FindByFamily();
                            WaitToPressKey();
                            break;

                        case 5:
                            isMainLoopActive = false;
                            break;
                    }
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

        static void ShowAllDosier()
        {
            if (personsFamily.Length > 0)
            {
                for (int i = 0; i < personsFamily.Length; i++)
                {
                    Console.WriteLine($" [{i}] {personsFamily[i]} {personsName[i]} {personsPatronymic[i]} --> {personsPosition[i]}");
                }
            }
            else
            {
                Console.WriteLine("Досье пусто...");
            }
        }

        static void AddToDossier()
        {
            string family = "";
            string name = "";
            string patronymic = "";
            string personPosition = "";

            Console.WriteLine($"Введите фамилию (или \"{CancelEnterTextCommand}\" для выхода)");
            family = ValidateEnter();

            // вот тут казалось бы дублирующийся код
            // 
            // не вижу особого смысла что-то уменьшать
            // это можно все в функцию ValidateEnter запихать, что-бы она возвращала bool 
            // но проблема что на каждом шаге мне все равно надо проверять не ввел ли 
            // пользователь команду выхода
            if (family == CancelEnterTextCommand)
            {
                return;
            }

            Console.WriteLine($"Введите имя (или \"{CancelEnterTextCommand}\" для выхода)");
            name = ValidateEnter();

            if (name == CancelEnterTextCommand)
            {
                return;
            }

            Console.WriteLine($"Введите отчество (или \"{CancelEnterTextCommand}\" для выхода)");
            patronymic = ValidateEnter();

            if (patronymic == CancelEnterTextCommand)
            {
                return;
            }

            Console.WriteLine($"Введите должность (или \"{CancelEnterTextCommand}\" для выхода)");
            personPosition = ValidateEnter();

            if (personPosition == CancelEnterTextCommand)
            {
                return;
            }

            Console.WriteLine($"Добавляем в базу: {family} {name} {patronymic} на должности {personPosition}");
            AddToArrays(family,name,patronymic,personPosition);
        }

        static string ValidateEnter()
        {
            bool isTextCheckProcess = true;
            string textLine = "";

            while (isTextCheckProcess)
            {
                Console.Write(":");
                textLine = Console.ReadLine();
                // нужно ли делать принудительно первый символ заглавным ?
                if (ValidateName(textLine))
                {
                    return textLine;
                }
                else
                {
                    Console.WriteLine("Вводимое значение должно содержать только символы русского или аглицкого алфавитов.");
                    Console.WriteLine("Строка не может быть пустой.");
                    Console.WriteLine($"Для выхода в предидущее меню наберите {CancelEnterTextCommand}");
                }
            }

            return textLine;
        }

        static bool ValidateName(string name)
        {
            if (name == "")
                return false;
            // надо ли добавлять проверки на фамилии и имена из нескольких слов или через дефис
            // надо ли делать отчечтво не обязательным ?
            return Regex.IsMatch(name, @"^[a-zA-Zа-яА-Я]+$");
        }

        static void AddToArrays(string family, string name, string patronymic, string personPosition)
        {
            AddToArray(ref personsFamily, family);
            AddToArray(ref personsName, name);
            AddToArray(ref personsPatronymic, patronymic);
            AddToArray(ref personsPosition, personPosition);
        }

        static void AddToArray(ref string[] oldArray, string newElement)
        {
            string[] newArray = new string[oldArray.Length + 1];
            for(int i=0; i<oldArray.Length; i++)
            {
                newArray[i] = oldArray[i];
            }
            newArray[newArray.Length - 1] = newElement;
            oldArray = newArray;
        }

        static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"{AddCommand}. {AddToDossierMenuText}");
            Console.WriteLine($"{ShowCommand}. {ShowDossierMenuText}");
            Console.WriteLine($"{DeletePersonCommand}. {DeletePersonMenuText}");
            Console.WriteLine($"{FindByFamilyCommand}. {FindByFamilyMenuText}");
            Console.WriteLine($"{ExitCommand}. {ExitMenuText}");
            Console.WriteLine();
        }

        static void DeletePersonByIndex()
        {
            string userInput;
            int deleteId;

            if (personsFamily.Length == 0)
            {
                Console.WriteLine("Досье пусто...");
                return;
            }

            ShowAllDosier();
            Console.WriteLine($"Введите id сотрудника для удаления (или \"{CancelEnterTextCommand}\" для выхода)");
            userInput = Console.ReadLine();

            if (userInput == CancelEnterTextCommand)
            {
                return;
            }

            if (Int32.TryParse(userInput, out deleteId))
            {
                if (deleteId < personsFamily.Length)
                {
                    Console.WriteLine($"Удаляю элемент {deleteId} из базы...");
                    DeleteFromArraysByIndex(deleteId);
                }
                else
                {
                    Console.WriteLine($"id = {deleteId} больше выходит за пределы массива. Введите число меньше.");
                }
            }
            else
            {
                Console.WriteLine("Не могу распарсить введенные данные. Пожалуйста, вводите только цифры.");
            }
        }

        static void DeleteFromArraysByIndex(int index)
        {
            DeleteFromArray(ref personsFamily, index);
            DeleteFromArray(ref personsName, index);
            DeleteFromArray(ref personsPatronymic, index);
            DeleteFromArray(ref personsPosition, index);
        }

        static void DeleteFromArray(ref string[] array, int index)
        {
            int newArraySize = array.Length - 1;

            if (index >= array.Length)
                return;

            // объявление переменной после проверок, норм ?
            string[] newArray = new string[newArraySize];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = index; i < newArray.Length; i++)
            {
                newArray[i] = array[i+1];
            }

            array = newArray;
        }

        static void FindByFamily()
        {
            string searchString; // так сделать ??? string searchString = ValidateEnter();
            Console.WriteLine($"Введите символы, без учета регистра, для поиска в строке по фамилии (или \"{CancelEnterTextCommand}\" для выхода)");
            searchString = ValidateEnter();

            if (searchString == CancelEnterTextCommand)
            {
                return;
            }

            for(int i=0; i<personsFamily.Length; i++)
            {
                int containedPosition = personsFamily[i].IndexOf(searchString, StringComparison.OrdinalIgnoreCase);
                bool isContained = containedPosition >= 0;

                if (isContained)
                    Console.WriteLine($"id =[{i}] Фамилия: {personsFamily[i]} содержит подстроку начиная с символа {containedPosition}.");
            }            
        }
    }
}
