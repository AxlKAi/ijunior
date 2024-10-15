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
        private WindowsManager _windowsManager;

        public void Run()
        {                   
            _windowsManager = new WindowsManager(_input);
            _input.OnExit += Exit;
            _input.ShowHelp += ShowHelpWindow;
            _input.OnReturn += ReturnEventCalled;
            _input.ShowDemo += ShowDemoWindow;
            _windowsManager.CreateWindow();

            while (_isWorking)
            {
                _input.Update();
            }
        }

        private void Exit()
        {
            _isWorking = false;
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

            _windowsManager.CreateWindow("Help", helpWindowText, 20, 10, 40, 15);
        }

        private void ShowDemoWindow()
        {
            var helpWindowText = new List<string>
            {
                "demo",
                "demo",
                "sadfasdf",
                "sadfasdf"
            };

            _windowsManager.CreateWindow("demo", helpWindowText, 30, 5, 15, 7);
        }

        public void ReturnEventCalled()
        {
            _windowsManager.CloseActiveWindow();
            _windowsManager.WriteBottomLine("Close window");
        }

    }

    class WindowsManager
    {
        const ConsoleColor MainWindowBackgroundColor = ConsoleColor.DarkBlue;
        const ConsoleColor MainWindowForegroundColor = ConsoleColor.Yellow;
        const ConsoleColor TopMenuBackgroundColor = ConsoleColor.Cyan;
        const ConsoleColor TopMenuForegroundColor = ConsoleColor.Black;
        const ConsoleColor BottomLineForegroundColor = ConsoleColor.Black;
        const ConsoleColor BottomLineBackgroundColor = ConsoleColor.White;

        private string _topLine = "     Space - create train     F1 - About     F4 - close window ";
        private int _windowWidth;
        private int _windowHeight;
        private InputSystem _inputSystem;

        private List<Window> _windows = new List<Window>();
        private Window _activeWindow;

        public WindowsManager(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
            _inputSystem.SendKeySymbol += WriteBottomLine;
            _inputSystem.OnEnterPressed += OnEnterPressed;

            Console.CursorVisible = false;
            _windowWidth = Console.WindowWidth;
            _windowHeight = Console.WindowHeight;

            for (int i = _topLine.Length; i < _windowWidth; i++)
            {
                _topLine += " ";
            }

            DrawBackground();
        }

        public void CreateWindow()
        {
            _activeWindow = new Window();
            _windows.Add(_activeWindow);
            WriteBottomLine("Window created");
        }

        public void CreateWindow(string title, List<string> text, int x = 10, int y=4, int length=20, int height=5)
        {
            foreach (var window in _windows)
                window.ChangeColor(window.ForegroundColor, ConsoleColor.DarkGray);

            RenewWindows();

            _activeWindow = new Window(title, text, x, y, length, height);
            _windows.Add(_activeWindow);
            WriteBottomLine($"{title} window created");
            _activeWindow.OnEnterPressed += _activeWindow.AddString;
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

        public void CloseActiveWindow()
        {
            _windows.Remove(_activeWindow);
            RenewWindows();

            if (_windows.Count > 0)
                _activeWindow = _windows[_windows.Count - 1];
        }

        public void OnEnterPressed()
        {
            _activeWindow.OnEnterPressed?.Invoke();
        }

        private void RenewWindows()
        {
            DrawBackground();

            foreach (var window in _windows)
            {
                window.DrawWindow();
            }
        }

        private void DrawBackground()
        {
            Console.BackgroundColor = MainWindowBackgroundColor;
            Console.ForegroundColor = MainWindowForegroundColor;

            Console.Clear();

            Console.ForegroundColor = TopMenuForegroundColor;
            Console.BackgroundColor = TopMenuBackgroundColor;

            Console.SetCursorPosition(0, 0);
            Console.Write(" --------- building -------------- ");
            Console.SetCursorPosition(0, 0);
            Console.Write(_topLine);

            Console.BackgroundColor = MainWindowBackgroundColor;
            Console.ForegroundColor = MainWindowForegroundColor;
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

        public Action OnEnterPressed;

        private List<string> _lines;
        private List<string> _rawText;

        private int _xPosition;
        private int _yPosition;
        private int _length;
        private int _height;
        private string _title;

        public ConsoleColor BackgrounColor { get; private set; }  = ConsoleColor.Gray;
        public ConsoleColor ForegroundColor { get; private set; } = ConsoleColor.Black;
        public ConsoleColor ShadowColor { get; private set; } = ConsoleColor.Black;

        public Window() : this(DefaultX, DefaultY, DefaultLength, DefaultHeight) { }

        public Window(int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight) : this("", new List<string>(), x, y, length, height) { }

        public Window(string title, List<string> text, int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight)
        {
            _title = title;
            InitializeWindow(text, x, y, length, height);
        }

        public void DrawWindow()
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

        public void ChangeColor(ConsoleColor foreground, ConsoleColor background)
        {
            ForegroundColor = foreground;
            BackgrounColor = background;
        }

        //TODO delete this method
        public void AddString()
        {
            _rawText.Add("Enter pressed...");
            BuildWindow();
        }

        private void InitializeWindow(List<string> text, int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight)
        {
            _rawText = text;

            _xPosition = x;
            _yPosition = y;
            _length = length;
            _height = height;

            BuildWindow();
        }

        private void BuildWindow()
        {
            _lines = new List<string>();

            string space = "";
            string graphicLine = "";
            string title = "";

            for (int i = 0; i < _length; i++)
            {
                graphicLine += HorizontalSymbol;
                space += " ";
            }

            title = UpLeftSymbol + HorizontalSymbol + TitleLeftBorder + _title + TitleRightBorder + graphicLine;
            title = title.Remove(_length + 1);

            title += UpRightSymbol;
            _lines.Add(title);

            for (int i = 0; i < _height; i++)
            {
                string s;

                if (i < _rawText.Count)
                    s = _rawText[i] + space;
                else
                    s = space;

                if (s.Length > _length)
                    s = s.Remove(_length);

                _lines.Add(VerticalSymbol + s + VerticalSymbol);
            }

            _lines.Add(LowLeftSymbol + graphicLine + LowRightSymbol);

            DrawWindow();
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
        public event Action OnReturn;
        public event Action ShowHelp;
        public event Action ShowDemo;
        public event Action OnEnterPressed;
        public event Action<string> SendKeySymbol;

        public void Update()
        {
            ConsoleKeyInfo key;

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    OnReturn?.Invoke();
                    break;

                case ConsoleKey.F1:
                    ShowHelp?.Invoke();
                    break;

                case ConsoleKey.F2:
                    ShowDemo?.Invoke();
                    break;

                case ConsoleKey.F4:
                    OnExit?.Invoke();
                    break;

                case ConsoleKey.Enter:
                    OnEnterPressed?.Invoke();
                    break;

                default:
                    SendKeySymbol?.Invoke(key.Key.ToString());
                    break;
            }
        }
    }
}
