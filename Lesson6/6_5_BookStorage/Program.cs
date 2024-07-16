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

                        bookStorage.Find(bookStorage.SearchAutorPattern); 
                        break;

                    case SearchByTitleCommand:
                        bookStorage.Find(bookStorage.SearchTitlePattern);
                        break;

                    case SearchByYearCommand:
                        bookStorage.Find(bookStorage.SearchYearPattern);
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
            {
                return true;
            }                
        }
    }

    class BookStorage
    {
        private const int OlderstBookYear = 868;
        private const string PositiveAnswer = "y";

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

        public delegate int? StringSearchPattern(int listIndex, string searchableLetters);

        public void AddBook()
        {
            string title;
            string autor;
            int year;

            Console.WriteLine("Добавление книги.");
            Console.Write("Введите название:");
            title = Console.ReadLine();

            if (Book.ValidateName(title) == false)
            {
                Console.WriteLine("Название книги введено не правильно.");
                return;
            }

            Console.Write("Введите автора:");
            autor = Console.ReadLine();

            if (Book.ValidateName(autor) == false)
            {
                Console.WriteLine("Имя автора книги введено не правильно.");
                return;
            }

            Console.Write("Введите год издания:");

            if (Int32.TryParse(Console.ReadLine(), out year))
            {
                if (year <= DateTime.Now.Year && year >= OlderstBookYear)
                {
                    CreateBookEntry(title, autor, year);
                }
                else
                {
                    Console.WriteLine($"Введенный год не попадает в период с {OlderstBookYear} года до текущей даты.");
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

        public int? SearchAutorPattern(int index, string searchText) => _books[index].Autor.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);

        public int? SearchTitlePattern(int index, string searchText) => _books[index].Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);

        public int? SearchYearPattern(int index, string searchText)
        {
            int searchYear;

            if (Int32.TryParse(searchText, out searchYear) == false)
            {
                Console.WriteLine("Не могу распарсить число. Вводите только цифры.");
                return null;
            }
            else
            {
                return _books[index].Year.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase);
            }            
        }

        public void Find(StringSearchPattern searchPattern)
        {
            string searchString;
            List<Book> findBooks = new List<Book>();

            Console.WriteLine("Введите строку для поиска.");
            searchString = Console.ReadLine();

            if (Book.ValidateName(searchString) == false)
            {
                Console.WriteLine("Не корректная строка для поиска.");
                return;
            }

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

        private void AskDeleteBooks(List<Book> books)
        {
            string userInput;

            Console.Write("Вы хотите удалить все найденные книги? (y - да, другой - нет):");
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
    }
}
