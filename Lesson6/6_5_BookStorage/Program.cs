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
        const string ShowAllEntrysCommand = "1";
        const string AddBookCommand = "2";
        const string DeleteBookCommand = "3";
        const string SearchByAutorCommand = "4";
        const string SearchByTitleCommand = "5";
        const string SearchByYearCommand = "6";
        const string ExitCommand = "7";

        public void Run()
        {
            BookStorage bookStorage = new BookStorage();
            bool isMainLoopActive = true;

            while (isMainLoopActive)
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
                        bookStorage.Find(BookStorage.FindBy.Autor);
                        break;

                    case SearchByTitleCommand:
                        bookStorage.Find(BookStorage.FindBy.Title);
                        break;

                    case SearchByYearCommand:
                        bookStorage.Find(BookStorage.FindBy.Year);
                        break;

                    case ExitCommand:
                        isMainLoopActive = !TryUserWantExit();
                        break;
                }

                WaitToPressKey();
            }
        }

        private void ShowMainMenu()
        {
            string showAllEntrys = "Показать всю базу.";
            string createBook = "Добавить книгу в базу.";
            string deleteBook = "Удалить книгу.";
            string searchByAutor = "Найти по автору.";
            string searchByTitle = "Найти по названию.";
            string searchByYear = "Найти по году.";
            string exitMenuText = "Выход.";

            Console.Clear();
            Console.WriteLine($"{ShowAllEntrysCommand}. {showAllEntrys}");
            Console.WriteLine($"{AddBookCommand}. {createBook}");
            Console.WriteLine($"{DeleteBookCommand}. {deleteBook}");
            Console.WriteLine($"{SearchByAutorCommand}. {searchByAutor}");
            Console.WriteLine($"{SearchByTitleCommand}. {searchByTitle}");
            Console.WriteLine($"{SearchByYearCommand}. {searchByYear}");
            Console.WriteLine($"{ExitCommand}. {exitMenuText}");
            Console.WriteLine();
        }

        private bool TryUserWantExit()
        {
            string userInput;
            Console.Write("Вы хотите выйти? (n - нет, другой - да):");
            userInput = Console.ReadLine();

            if (userInput == "n")
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

        public static bool ValidateName(string name)
        {
            name = System.Text.RegularExpressions.Regex.Replace(name, @"\s+", " ");

            if (name == "" || name == " ")
            {
                Console.WriteLine("Введено не корректная строка, " +
                    "она не может быть пустой или состоять только из пробелов.");
                return false;
            }
            else
                return true;
        }
    }

    class BookStorage
    {
        const int OlderstBookAgeYears = 800;

        private List<Book> _books = new List<Book>();

        public BookStorage()
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

        public enum FindBy { Autor, Title, Year }

        public void AddBook()
        {
            string title;
            string autor;
            int year;

            Console.WriteLine("Добавление книги.");
            Console.Write("Введите название:");
            title = Console.ReadLine();

            if (!Book.ValidateName(title))
            {
                Console.WriteLine("Название книги введено не правильно.");
                return;
            }

            Console.Write("Введите автора:");
            autor = Console.ReadLine();

            if (!Book.ValidateName(autor))
            {
                Console.WriteLine("Имя автора книги введено не правильно.");
                return;
            }

            Console.Write("Введите год издания:");

            if (Int32.TryParse(Console.ReadLine(), out year))
            {
                if (year <= DateTime.Now.Year && year >= DateTime.Now.Year - OlderstBookAgeYears)
                {
                    CreateBookEntry(title, autor, year);
                }
                else
                {
                    Console.WriteLine($"Введенный год не попадает в последние {OlderstBookAgeYears} лет.");
                }
            }
            else
            {
                Console.WriteLine("Вводите только цифры, не могу распознать ввод.");
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

        public void Find(FindBy findBy)
        {
            string searchString;
            int searchYear = 0;
            List<Book> findBooks = new List<Book>(); 

            Console.WriteLine("Введите строку для поиска.");
            searchString = Console.ReadLine();

            switch (findBy)
            {
                case FindBy.Autor:
                case FindBy.Title:
                    if (!Book.ValidateName(searchString))
                        return;
                    break;

                case FindBy.Year:
                    if (!Int32.TryParse(searchString, out searchYear))
                    {
                        Console.WriteLine("Не могу распознать число. Введите только цыфры.");
                        return;
                    }                        
                    break;
            }

            bool isContained = false;

            for (int i = 0; i < _books.Count; i++)
            {
                int containedPosition = -1;

                switch (findBy)
                {
                    case FindBy.Autor:
                        containedPosition = _books[i].Autor.IndexOf(searchString, StringComparison.OrdinalIgnoreCase);
                        break;

                    case FindBy.Title:
                        containedPosition = _books[i].Title.IndexOf(searchString, StringComparison.OrdinalIgnoreCase);
                        break;

                    case FindBy.Year:
                        containedPosition = _books[i].Year.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase);
                        break;
                }

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

            if (findBooks.Count > 0 )
            {
                string userInput;
                Console.Write("Вы хотите удалить все найденные книги? (y - да, другой - нет):");
                userInput = Console.ReadLine();

                if (userInput == "y")
                {
                    DeleteBooks(findBooks);
                }
            }
            else
            {
                Console.WriteLine($"Не удалось найти ничего похожего на {searchString}.");
            }
        }

        public void DeleteBook()
        {
            ShowAllEntires();

            int index;
            Console.WriteLine("Удаление книги. Введите индекс. ");

            if (Int32.TryParse(Console.ReadLine(), out index))
            {
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
            else
            {
                Console.WriteLine("Не могу распознать число, вводите только цифры.");
            }
        }

        private void DeleteBooks(List<Book> books)
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"Удаляю книгу {book.Title}");
                _books.Remove(book);
            }
        }

        private void CreateBookEntry(string title, string autor, int year)
        {
            Book book = new Book(title, autor, year);
            _books.Add(book);
            Console.WriteLine($"В хранилище добавлен шедевр \"{title}\" созданный \"{autor}\" в {year} году.");
        }
    }
}
