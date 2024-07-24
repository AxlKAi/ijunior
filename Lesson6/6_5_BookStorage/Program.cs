using System;
using System.Collections.Generic;

namespace _6_5_BookStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();

            application.Run();
        }
    }

    class Application
    {
        private const string ShowAllEntrysCommand = "1";
        private const string AddBookCommand = "2";
        private const string DeleteBookCommand = "3";
        private const string SearchByAutorCommand = "4";
        private const string SearchByTitleCommand = "5";
        private const string SearchByYearCommand = "6";
        private const string ExitCommand = "7";
        private const string NegotiveAnswer = "n";

        public void Run()
        {
            BookStorage bookStorage = new BookStorage();
            bool isExit = false;

            while (isExit == false)
            {
                ShowMainMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAllEntrysCommand:
                        bookStorage.ShowAllEntires();
                        break;

                    case AddBookCommand:
                        bookStorage.AddBook();
                        break;

                    case DeleteBookCommand:
                        bookStorage.DeleteBook();
                        break;

                    case SearchByAutorCommand:
                        bookStorage.Find(bookStorage.SearchAutorPattern);
                        break;

                    case SearchByTitleCommand:
                        bookStorage.Find(bookStorage.SearchTitlePattern);
                        break;

                    case SearchByYearCommand:
                        bookStorage.Find(bookStorage.SearchYearPattern);
                        break;

                    case ExitCommand:
                        isExit = TryExit();
                        break;
                }

                WaitToPressKey();
            }
        }

        private void ShowMainMenu()
        {
            string showAllEntrysMessage = "Показать всю базу.";
            string createBookMessage = "Добавить книгу в базу.";
            string deleteBookMessage = "Удалить книгу.";
            string searchByAutorMessage = "Найти по автору.";
            string searchByTitleMessage = "Найти по названию.";
            string searchByYearMessage = "Найти по году.";
            string exitMenuTextMessage = "Выход.";

            Console.Clear();
            Console.WriteLine($"{ShowAllEntrysCommand}. {showAllEntrysMessage}");
            Console.WriteLine($"{AddBookCommand}. {createBookMessage}");
            Console.WriteLine($"{DeleteBookCommand}. {deleteBookMessage}");
            Console.WriteLine($"{SearchByAutorCommand}. {searchByAutorMessage}");
            Console.WriteLine($"{SearchByTitleCommand}. {searchByTitleMessage}");
            Console.WriteLine($"{SearchByYearCommand}. {searchByYearMessage}");
            Console.WriteLine($"{ExitCommand}. {exitMenuTextMessage}");
            Console.WriteLine();
        }

        private bool TryExit()
        {
            string userInput;

            Console.Write($"Вы хотите выйти? ({NegotiveAnswer} - нет, другой - да):");
            userInput = Console.ReadLine();

            if (userInput == NegotiveAnswer)
            {
                return false;
            }
            else
            {
                Console.WriteLine("До свиданья....");
                return true;
            }
        }

        private void WaitToPressKey()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения.....");
            Console.ReadKey();
        }
    }

    class Book
    {
        public Book(string title, string autor, int year)
        {
            Title = title;
            Autor = autor;
            Year = year;
        }

        public string Autor { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
    }

    class BookStorage
    {
        private const int OlderstBookYear = 868;
        private const string PositiveAnswer = "y";

        private List<Book> _books = new List<Book>();

        public BookStorage()
        {
            Fill();
        }

        public delegate int? StringSearchPattern(int listIndex, string searchableLetters);

        public void AddBook()
        {
            string title;
            string autor;
            int year;

            Console.WriteLine("Добавление книги.");
            Console.Write("Введите название:");
            title = Console.ReadLine();

            if (IsValidString(title) == false)
                return;

            Console.Write("Введите автора:");
            autor = Console.ReadLine();

            if (IsValidString(autor) == false)
                return;

            Console.Write("Введите год издания:");
            year = ReadInt(Console.ReadLine());

            if (year <= DateTime.Now.Year && year >= OlderstBookYear)
            {
                CreateBookEntry(title, autor, year);
            }
            else
            {
                Console.WriteLine($"Введенный год не попадает в период с {OlderstBookYear} года до текущей даты.");
                return;
            }
        }

        public void ShowAllEntires()
        {
            Console.WriteLine("База данных:");

            for (int i = 0; i < _books.Count; i++)
                Console.WriteLine($"[{i}] {_books[i].Autor} | {_books[i].Title} " +
                    $"| {_books[i].Year} ");

            Console.WriteLine();
        }

        public int? SearchAutorPattern(int index, string searchText) =>
            _books[index].Autor.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);

        public int? SearchTitlePattern(int index, string searchText) =>
            _books[index].Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);

        public int? SearchYearPattern(int index, string searchText)
        {
            int searchYear = ReadInt(searchText);

            if (searchYear >= 0)
            {
                return _books[index].Year.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                return null;
            }
        }

        public void Find(StringSearchPattern searchPattern)
        {
            string searchString;
            List<Book> findBooks = new List<Book>();

            Console.WriteLine("Введите строку для поиска.");
            searchString = Console.ReadLine();

            if (IsValidString(searchString) == false)
                return;

            bool isContained = false;

            for (int i = 0; i < _books.Count; i++)
            {
                int? containedPosition = -1;

                containedPosition = searchPattern(i, searchString);

                if (containedPosition == null)
                    break;

                isContained = containedPosition >= 0;

                if (isContained)
                {
                    findBooks.Add(_books[i]);

                    containedPosition++;
                    Console.WriteLine($"id =[{i}] Книга: {_books[i].Title} " +
                        $"Автор: {_books[i].Autor} Год: {_books[i].Year}" +
                        $" содержит подстроку начиная с символа {containedPosition}.");
                }
            }

            if (findBooks.Count > 0)
            {
                AskDeleteBooks(findBooks);
            }
            else
            {
                Console.WriteLine($"Не удалось найти ничего похожего на {searchString}.");
            }
        }

        public void DeleteBook()
        {
            ShowAllEntires();

            Console.WriteLine("Удаление книги. Введите индекс. ");
            int index = ReadInt(Console.ReadLine());

            if (index >= 0 && index < _books.Count)
            {
                Console.WriteLine($"Книга \"{_books[index].Title}\" за авторством \"{_books[index].Autor}\" будет удалена.");
                _books.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Указанный индекс выходит за рамки границ хранилища.");
            }
        }

        private void Fill()
        {
            CreateBookEntry("Война и мир", "Лев Толстой", 1865);
            CreateBookEntry("В чём моя вера?", "Лев Толстой", 1884);
            CreateBookEntry("Исповедь", "Лев Толстой", 1884);
            CreateBookEntry("Идиот", "Достоевский", 1867);
            CreateBookEntry("Бесы", "Достоевский", 1871);
            CreateBookEntry("Братья Карамазовы", "Достоевский", 1879);
            CreateBookEntry("Братство Кольца", "Толкин Джон Рональд Руэл", 1954);
            CreateBookEntry("Две крепости", "Толкин Джон Рональд Руэл", 1954);
            CreateBookEntry("Возвращение короля", "Толкин Джон Рональд Руэл", 1954);
        }

        private void AskDeleteBooks(List<Book> books)
        {
            string userInput;

            Console.Write($"Вы хотите удалить все найденные книги? ({PositiveAnswer} - да, другой - нет):");
            userInput = Console.ReadLine();

            if (userInput == PositiveAnswer)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"Удаляю книгу {book.Title}");
                    _books.Remove(book);
                }
            }
        }

        private void CreateBookEntry(string title, string autor, int year)
        {
            Book book = new Book(title, autor, year);
            _books.Add(book);
            Console.WriteLine($"В хранилище добавлен шедевр \"{title}\" созданный \"{autor}\" в {year} году.");
        }

        private int ReadInt(string text)
        {
            string errorMessage = "Не могу распознать число, вводите только цифры.";
            int number;

            if (Int32.TryParse(text, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine(errorMessage);
                return -1;
            }
        }

        private bool IsValidString(string name)
        {
            name = System.Text.RegularExpressions.Regex.Replace(name, @"\s+", " ");

            if (name == "" || name == " ")
            {
                Console.WriteLine("Введена не корректная строка, " +
                    "она не может быть пустой или состоять только из пробелов.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
