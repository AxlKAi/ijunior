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
            InitializeApplication();

            while (_isWorking)
            {
                _input.Update();
            }
        }

        private void InitializeApplication()
        {
            _windowsManager = new WindowsManager(_input);
            _input.OnExit += Exit;
            _input.OnF1Press += ShowHelpWindow;
            _input.OnReturn += ReturnEventCalled;
            _input.OnF2Press += ShowDemoWindow;
            _windowsManager.CreateWindow();
        }

        private void Exit()
        {
            _isWorking = false;
        }

        private void ShowHelpWindow()
        {
            var element1 = new UIelement(new List<string>() { "1", "2", "3" }, 1, 1, 10, 5);
            var element2 = new UIelement(new List<string>() { "4", "5", "6" }, 5, 5, 10, 5);
            element1.SetColor(ConsoleColor.Red, ConsoleColor.DarkGreen);
            element2.SetColor(ConsoleColor.Red, ConsoleColor.DarkBlue);

            var helpWindowText = new List<string>
            {
                "sadfasdf",
                "sadfasdf",
                "sadfasdf",
                "sadfasdf"
            };

            var window = _windowsManager.CreateWindow("Help", helpWindowText, 20, 10, 40, 15);
            window.AddChild(element1);
            element1.SetRoot(window);
            window.AddChild(element2);
            element2.SetRoot(window);
            element1.Show();
            element2.Show();
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

            var window =
            _windowsManager.CreateWindow("demo", helpWindowText, 30, 5, 15, 7);
        }

        public void ReturnEventCalled()
        {
            _windowsManager.CloseActiveWindow();
            _windowsManager.ShowBottomBorder("Close window");
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
            _inputSystem.SendKeySymbol += ShowBottomBorder;
            _inputSystem.OnEnterPress += OnEnterPressed;

            Console.CursorVisible = false;
            _windowWidth = Console.WindowWidth;
            _windowHeight = Console.WindowHeight;

            for (int i = _topLine.Length; i < _windowWidth; i++)
            {
                _topLine += " ";
            }

            ClearBackground();
        }

        public Window CreateWindow()
        {
            _activeWindow = new Window();
            _windows.Add(_activeWindow);
            ShowBottomBorder("Window created");
            return _activeWindow;
        }

        public Window CreateWindow(string title, List<string> text, int x = 10, int y = 4, int length = 20, int height = 5)
        {
            UnscribeActiveWindowToEvents();

            foreach (var window in _windows)
            {
                window.SetColor(window.ForegroundColor, ConsoleColor.DarkGray);
            }

            RenewWindows();

            _activeWindow = new Window(title, text, x, y, length, height);
            _windows.Add(_activeWindow);
            ShowBottomBorder($"{title} window created");
            SubscribeActiveWindowToEvents();
            return _activeWindow;
        }

        public void ShowBottomBorder(string s)
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
            UnscribeActiveWindowToEvents();
            _windows.Remove(_activeWindow);

            if (_windows.Count > 0)
            {
                _activeWindow = _windows[_windows.Count - 1];
                _activeWindow.SetColor(_activeWindow.ForegroundColor, ConsoleColor.Gray);
                SubscribeActiveWindowToEvents();
            }

            RenewWindows();
        }

        public void AddWindowElement(Window window, UIelement windowsElement)
        {
            //TODO &&&& ????
            //window.
        }

        public void OnEnterPressed()
        {
            _activeWindow.OnEnterPressed?.Invoke();
        }

        private void SubscribeActiveWindowToEvents()
        {
            _inputSystem.OnEnterPress += _activeWindow.OnEnterPress;
            _inputSystem.OnLeftArrowPress += _activeWindow.OnLeftArrowPress;
            _inputSystem.OnRightArrowPress += _activeWindow.OnRightArrowPress;
            _inputSystem.OnUpArrowPress += _activeWindow.OnUpArrowPress;
            _inputSystem.OnDownArrowPress += _activeWindow.OnDownArrowPress;
            _inputSystem.OnNumberPress += _activeWindow.OnNumberPress;
            _inputSystem.OnLetterPress += _activeWindow.OnLetterPress;
        }

        private void UnscribeActiveWindowToEvents()
        {
            _inputSystem.OnEnterPress -= _activeWindow.OnEnterPress;
            _inputSystem.OnLeftArrowPress -= _activeWindow.OnLeftArrowPress;
            _inputSystem.OnRightArrowPress -= _activeWindow.OnRightArrowPress;
            _inputSystem.OnUpArrowPress -= _activeWindow.OnUpArrowPress;
            _inputSystem.OnDownArrowPress -= _activeWindow.OnDownArrowPress;
            _inputSystem.OnNumberPress -= _activeWindow.OnNumberPress;
            _inputSystem.OnLetterPress -= _activeWindow.OnLetterPress;
        }

        private void RenewWindows()
        {
            ClearBackground();

            foreach (var window in _windows)
            {
                window.Show();
            }
        }

        private void ClearBackground()
        {
            Console.BackgroundColor = MainWindowBackgroundColor;
            Console.ForegroundColor = MainWindowForegroundColor;

            Console.Clear();

            ShowTopBorder();
        }

        private void ShowTopBorder()
        {
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


    //TODO сделать наследником WindowsElement ??
    class Window : UIelement
    {
        const string UpLeftSymbol = "╔";
        const string LowLeftSymbol = "╚";
        const string UpRightSymbol = "╗";
        const string LowRightSymbol = "╝";
        const string VerticalSymbol = "║";
        const string HorizontalSymbol = "═";
        const string TitleLeftBorder = "[ ";
        const string TitleRightBorder = " ]";

        const int ShadowHorizontalPadding = 2;
        const int ShadowVerticalPadding = 2;

        //TODO перенести события в базовый класс
        public Action OnEnterPressed;

        public string Title { get; protected set; }

        public ConsoleColor ShadowColor { get; protected set; } = ConsoleColor.Black;

        public Window() : this(DefaultX, DefaultY, DefaultLength, DefaultHeight) { }

        public Window(int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight) : this("", new List<string>(), x, y, length, height) { }

        public Window(string title, List<string> text, int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight)
        {
            Title = title;
            _rawText = text;

            PositionX = x;
            PositionY = y;
            Length = length;
            Height = height;

            Initialize();
        }

        override public void Show()
        {
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(PositionX, PositionY);

            foreach (string line in _lines)
            {
                Console.Write(line);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                DrawShadowSymbol();
                Console.SetCursorPosition(PositionX, Console.CursorTop);
            }

            DrawShadowBottomLine();

            Console.ForegroundColor = currentForeground;
            Console.BackgroundColor = currentBackground;

            ShowChildElements();
        }

        public void SetColor(ConsoleColor foreground, ConsoleColor background)
        {
            ForegroundColor = foreground;
            BackgroundColor = background;
        }

        //TODO delete this method
        override public void OnEnterPress()
        {
            _rawText.Add("Enter pressed...");
            Initialize();
        }

        override protected void Initialize()
        {
            _lines = new List<string>();

            string space = "";
            string graphicLine = "";
            string title = "";

            for (int i = 0; i < Length; i++)
            {
                graphicLine += HorizontalSymbol;
                space += " ";
            }

            title = UpLeftSymbol + HorizontalSymbol + TitleLeftBorder + Title + TitleRightBorder + graphicLine;
            title = title.Remove(Length + 1);

            title += UpRightSymbol;
            _lines.Add(title);

            for (int i = 0; i < Height; i++)
            {
                string s;

                if (i < _rawText.Count)
                    s = _rawText[i] + space;
                else
                    s = space;

                if (s.Length > Length)
                    s = s.Remove(Length);

                _lines.Add(VerticalSymbol + s + VerticalSymbol);
            }

            _lines.Add(LowLeftSymbol + graphicLine + LowRightSymbol);

            Show();
        }

        private void DrawShadowBottomLine()
        {
            Console.SetCursorPosition(PositionX + ShadowHorizontalPadding, PositionY + Height + ShadowVerticalPadding);

            for (int i = 0; i < Length; i++)
                DrawShadowSymbol();
        }

        private void DrawShadowSymbol(string shadowSprite = " ")
        {
            ConsoleColor currentBackground = Console.BackgroundColor;

            Console.BackgroundColor = ShadowColor;
            Console.Write(shadowSprite);
            Console.BackgroundColor = currentBackground;
        }

        private void ShowChildElements()
        {
            if (_childElements.Count == 0)
                return;

            foreach (var element in _childElements)
            {
                element.Show();
            }
        }
    }

    class UIelement
    {
        protected const int DefaultX = 1;
        protected const int DefaultY = 1;
        protected const int DefaultLength = 5;
        protected const int DefaultHeight = 5;

        protected List<string> _lines;
        protected List<string> _rawText;
        protected List<UIelement> _childElements = new List<UIelement>();
        protected UIelement _rootElement = null;

        public int PositionX { get; protected set; } = 1;
        public int PositionY { get; protected set; } = 1;
        public int Length { get; protected set; } = 5;
        public int Height { get; protected set; } = 5;

        public ConsoleColor BackgroundColor { get; protected set; } = ConsoleColor.Gray;
        public ConsoleColor ForegroundColor { get; protected set; } = ConsoleColor.Black;

        public UIelement() : this(new List<string>()) { }

        public UIelement(List<string> text, int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight)
        {
            _rawText = text;

            PositionX = x;
            PositionY = y;
            Length = length;
            Height = height;

            Initialize();
        }

        virtual public void Show()
        {
            int rootPositionX = 0;
            int rootPositionY = 0;

            if (_rootElement != null)
            {
                rootPositionX = _rootElement.PositionX;
                rootPositionY = _rootElement.PositionY;
            }

            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(PositionX + rootPositionX, PositionY + rootPositionY);

            foreach (string line in _lines)
            {
                Console.WriteLine(line);
                Console.SetCursorPosition(PositionX + rootPositionX, Console.CursorTop);
            }

            Console.ForegroundColor = currentForeground;
            Console.BackgroundColor = currentBackground;
        }

        virtual public void ChangeContent(List<string> text)
        {
            _rawText = text;

            Initialize();
        }

        virtual public void AddChild(UIelement element)
        {
            _childElements.Add(element);
        }

        virtual public void SetRoot(UIelement element)
        {
            _rootElement = element;
        }

        virtual public void SetColor(ConsoleColor foreground, ConsoleColor background)
        {
            ForegroundColor = foreground;
            BackgroundColor = background;
        }

        virtual public void OnLeftArrowPress() { }

        virtual public void OnRightArrowPress() { }

        virtual public void OnUpArrowPress() { }

        virtual public void OnDownArrowPress() { }

        virtual public void OnEnterPress() { }

        virtual public void OnNumberPress() { }

        virtual public void OnLetterPress() { }

        virtual protected void Initialize()
        {
            _lines = new List<string>();

            string space = "";

            for (int i = 0; i < Length; i++)
            {
                space += " ";
            }

            for (int i = 0; i < Height; i++)
            {
                string s;

                if (i < _rawText.Count)
                    s = _rawText[i] + space;
                else
                    s = space;

                if (s.Length > Length)
                    s = s.Remove(Length);

                _lines.Add(s);
            }

            //TODO по идее этот метод надо убрать отсюда, и вызывать отдельно при необходимости
            Show();
        }
    }

    class InputSystem
    {
        public event Action OnExit;
        public event Action OnReturn;
        public event Action OnF1Press;
        public event Action OnF2Press;
        public event Action OnLeftArrowPress;
        public event Action OnRightArrowPress;
        public event Action OnUpArrowPress;
        public event Action OnDownArrowPress;
        public event Action OnEnterPress;
        public event Action OnNumberPress;
        public event Action OnLetterPress;

        //TODO переделать на отдельно цифры и буквы
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
                    OnF1Press?.Invoke();
                    break;

                case ConsoleKey.F2:
                    OnF2Press?.Invoke();
                    break;

                case ConsoleKey.F4:
                    OnExit?.Invoke();
                    break;

                case ConsoleKey.Enter:
                    OnEnterPress?.Invoke();
                    break;

                default:
                    SendKeySymbol?.Invoke(key.Key.ToString());
                    break;
            }
        }
    }
}
