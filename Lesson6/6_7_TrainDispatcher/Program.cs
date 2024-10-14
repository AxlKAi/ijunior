using System;
using System.Collections.Generic;

namespace _6_7_TrainDispatcher
{
    /*
     Реализовать класс диспетчера, который создает поезда.
Консольное меню состоит из двух пунктов: создания поезда и завершения работы.
Создание поезда состоит из нескольких шагов. 
- Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
- Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
- Сформировать поезд - вы создаете сам поезд и добавляете ему столько вагонов, сколько хватит для перевозки всех пассажиров. Вагон содержит сколько может поместить в себе пассажиров. Можно сделать как одинаковую вместимость всех вагонов, так и разную.
- Показываете полную информацию о созданном поезде. 
Шаги создания поезда должны быть в строгой последовательности не зависящем от выбора пользователя.
Диспетчер содержит все созданные поезда и перед выбором в консольном меню показать короткую информацию каждого поезда.

Город
	Название
	id - у городов может быть одинаковое название

Вагон
	id
	тип (Сидячий вагон / Плацкартный вагон / Общий вагон / Купейный вагон)
	мест кол-во максимум
	мест заполнено

Поезд 
	id
	Город 1
	Город 2
	Вагонов List
	Пассажиров кол-во {Property}
	- показать поезд

Диспетчер
	Поезда List
	- создание поезда (направление, билеты продать, )
	- завершение работы

	*/
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
        private bool _isWorking = true;
        private InputSystem _input = new InputSystem();
        private MainInterface _userInterface = new MainInterface();

        public void Run()
        {
            _input.OnExit += Exit;
            _input.ShowHelp += ShowHelpWindow;
            _input.SendKeySymbol += LogMessage;
            _userInterface.CreateWindow();

            while (_isWorking)
            {
                _input.Update();
            }
        }

        private void Exit()
        {
            _isWorking = false;
        }

        private void LogMessage(string s)
        {
            _userInterface.WriteBottomLine(s);
        }

        private void ShowHelpWindow()
        {
            var helpWindowText = new List<string>
            {
                "sadfasdf",
                "sadfasdf",
                "sadfasdf",
                "sadfasdf"
            };

            _userInterface.CreateWindow("Help", helpWindowText);
        }
    }

    class MainInterface
    {
        const ConsoleColor MainWindowBackgroundColor = ConsoleColor.DarkBlue;
        const ConsoleColor MainWindowForegroundColor = ConsoleColor.Yellow;
        const ConsoleColor TopMenuBackgroundColor = ConsoleColor.Cyan;
        const ConsoleColor TopMenuForegroundColor = ConsoleColor.Black;
        const ConsoleColor BottomLineForegroundColor = ConsoleColor.Black;
        const ConsoleColor BottomLineBackgroundColor = ConsoleColor.White;

        private string _topLine;
        private int _windowWidth;
        private int _windowHeight;

        private List<Window> _windows = new List<Window>();

        public MainInterface()
        {
            Console.BackgroundColor = MainWindowBackgroundColor;
            Console.ForegroundColor = MainWindowForegroundColor;
            Console.CursorVisible = false;
            Console.Clear();

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                _topLine += " ";
            }

            Console.ForegroundColor = TopMenuForegroundColor;
            Console.BackgroundColor = TopMenuBackgroundColor;

            Console.SetCursorPosition(0, 0);
            Console.Write(_topLine);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(" Space - create train     F1 - About     F4 - close window");

            Console.BackgroundColor = MainWindowBackgroundColor;
            Console.ForegroundColor = MainWindowForegroundColor;

            _windowWidth = Console.WindowWidth;
            _windowHeight = Console.WindowHeight;
            Console.WriteLine($"Width:{_windowWidth}");
            Console.WriteLine($"Height:{_windowHeight}");
        }

        public void CreateWindow()
        {

            _windows.Add(new Window());
            WriteBottomLine("Window created");
        }

        public void CreateWindow(string title, List<string> text)
        {
            _windows.Add(new Window(title, text));
            WriteBottomLine($"{title} window created");
        }

        public void ShowHelpWindow()
        {

        }

        public void WriteBottomLine(string s)
        {
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            Console.ForegroundColor = BottomLineForegroundColor;
            Console.BackgroundColor = BottomLineBackgroundColor;

            Console.SetCursorPosition(0, _windowHeight - 1);

            for (int i = 0; i < _windowWidth; i++)
                Console.Write(" ");

            Console.SetCursorPosition(0, _windowHeight - 1);
            Console.Write(s);

            Console.ForegroundColor = currentForeground;
            Console.BackgroundColor = currentBackground;
        }
    }

    class Window
    {
        const string UpLeftSymbol = "╔";
        const string LowLeftSymbol = "╚";
        const string UpRightSymbol = "╗";
        const string LowRightSymbol = "╝";
        const string VerticalSymbol = "║";
        const string HorizontalSymbol = "═";
        const string TitleLeftBorder = "[ ";
        const string TitleRightBorder = " ]";

        const int DefaultX = 10;
        const int DefaultY = 4;
        const int DefaultLength = 40;
        const int DefaultHeight = 8;
        const int ShadowHorizontalPadding = 2;
        const int ShadowVerticalPadding = 2;

        const ConsoleColor BackgrounColor = ConsoleColor.White;
        const ConsoleColor ForegroundColor = ConsoleColor.Black;
        const ConsoleColor ShadowColor = ConsoleColor.Black;

        private List<string> _lines;

        private int _xPosition;
        private int _yPosition;
        private int _length;
        private int _height;
        private int _titlePadding = 8; 
        private string _title;

        public Window() : this(DefaultX, DefaultY, DefaultLength, DefaultHeight) { }

        public Window(int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight) : this("", new List<string>(), x, y, length, height) { }

        public Window(string title, List<string> text, int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight)
        {
            _title = title;
            CreateWindow(text, x, y, length, height);
        }

        private void CreateWindow(List<string> text, int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight)
        {
            _lines = new List<string>();

            _xPosition = x;
            _yPosition = y;
            _length = length;
            _height = height;

            string space = "";
            string graphicLine = "";
            string title = "";

            for (int i = 0; i < length; i++)
            {
                graphicLine += HorizontalSymbol;
                space += " ";
            }

            title = UpLeftSymbol + HorizontalSymbol + TitleLeftBorder + _title + TitleRightBorder + graphicLine;
            title = title.Remove(length + 1);

            title += UpRightSymbol;            
            _lines.Add(title);

            for (int i = 0; i < height; i++)
            {
                string s;

                if (i < text.Count)
                    s = text[i] + space;
                else
                    s = space;

                if (s.Length > _length)
                    s = s.Remove(length);

                _lines.Add(VerticalSymbol + s + VerticalSymbol);
            }

            _lines.Add(LowLeftSymbol + graphicLine + LowRightSymbol);

            DrawWindow();
        }

        private void DrawWindow()
        {
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgrounColor;
            Console.SetCursorPosition(_xPosition, _yPosition);

            foreach (string line in _lines)
            {
                Console.Write(line);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                DrawShadowSymbol();
                Console.SetCursorPosition(_xPosition, Console.CursorTop);
            }

            DrawShadowBottomLine();

            Console.ForegroundColor = currentForeground;
            Console.BackgroundColor = currentBackground;
        }

        private void DrawShadowBottomLine()
        {
            Console.SetCursorPosition(_xPosition + ShadowHorizontalPadding, _yPosition + _height + ShadowVerticalPadding);

            for (int i = 0; i < _length; i++)
                DrawShadowSymbol();
        }

        private void DrawShadowSymbol(string shadowSprite = " ")
        {
            ConsoleColor currentBackground = Console.BackgroundColor;

            Console.BackgroundColor = ShadowColor;
            Console.Write(shadowSprite);
            Console.BackgroundColor = currentBackground;
        }
    }

    class InputSystem
    {
        public event Action OnExit;
        public event Action ShowHelp;
        public event Action<string> SendKeySymbol;

        public void Update()
        {
            ConsoleKeyInfo key;

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    OnExit?.Invoke();
                    break;

                case ConsoleKey.F1:
                    ShowHelp?.Invoke();
                    break;

                case ConsoleKey.F4:
                    OnExit?.Invoke();
                    break;

                default:
                    SendKeySymbol?.Invoke(key.Key.ToString());
                    break;
            }
        }
    }
}
