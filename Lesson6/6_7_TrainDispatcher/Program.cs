using System;
using System.Collections.Generic;
using System.Linq;

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

        public void ReturnEventCalled()
        {
            _windowsManager.CloseActiveWindow();
            _windowsManager.ShowBottomBorder("Close window");
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
            var element2 = new VerticalMenu(new List<string>() { "one", "two", "three" }, 5, 5, 10, 5);
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
            window.AddChild(element2);
            //element1.Show();
            //element2.Show();
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
            _windowsManager.CreateWindow("demo", helpWindowText, 30, 5, 25, 7);
            var input = new Input("123456", 2, 2, 10);
            input.SetColor(ConsoleColor.White, ConsoleColor.DarkBlue);
            input.SetNumbersOnly();
            input.SetHandlers(new List<Action<string>>() { ShowResultScreen });
            window.AddChild(input);
        }

        private void ShowResultScreen(string message)
        {
            var window = _windowsManager.CreateWindow("result", new List<string>() { $" Congratulations!", $" {message} is entered" }, 50, 15, 35, 5);
            window.SetColor(ConsoleColor.Green, ConsoleColor.Red);
            window.Show();
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

        //TODO change space to tab 
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
            _inputSystem.OnDeletePress += _activeWindow.OnDeletePress;
            _inputSystem.OnBackspacePress += _activeWindow.OnBackspacePress;
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
            _inputSystem.OnDeletePress -= _activeWindow.OnDeletePress;
            _inputSystem.OnBackspacePress -= _activeWindow.OnBackspacePress;
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
        /*
        override public void OnEnterPress()
        {
            _rawText.Add("Enter pressed...");
            Initialize();


        }
        */
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

    class Input : UIelement
    {
        protected ConsoleColor ForegroundCursorColor { get; private set; } = ConsoleColor.Yellow;
        protected ConsoleColor BackgroundCursorColor { get; private set; } = ConsoleColor.DarkGreen;

        protected int CursorPosition { get; private set; } = 0;

        protected bool IsNumberOnly { get; private set; } = false;
        protected bool IsLettersOnly { get; private set; } = false;

        private List<Action<string>> _handlers;

        public Input() : this("", DefaultX, DefaultY, DefaultLength) { }
        public Input(string text, int x = DefaultX, int y = DefaultY, int length = DefaultLength) : base(new List<string>() { text }, x, y, length, 1) { }

        //TODO добавить проверки на число

        //TODO добавить проверки на буквы через regular expresseion

        public override void Show()
        {
            base.Show();

            Console.SetCursorPosition(PositionX + RootPositionX + CursorPosition, PositionY + RootPositionY);

            Console.ForegroundColor = ForegroundCursorColor;
            Console.BackgroundColor = BackgroundCursorColor;

            Console.Write(_lines[0][CursorPosition]);

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
        }

        public void SetLettersOnly()
        {
            IsNumberOnly = false;
            IsLettersOnly = true;
        }

        public void SetNumbersOnly()
        {
            IsNumberOnly = true;
            IsLettersOnly = false;
        }

        public void SetHandlers(List<Action<string>> handlers)
        {
            _handlers = handlers;
        }

        public override void OnLeftArrowPress()
        {
            if (CursorPosition > 0)
            {
                CursorPosition--;
                Show();
            }
        }

        public override void OnRightArrowPress()
        {
            if (CursorPosition < _rawText[0].Length && CursorPosition < Length - 1)
            {
                CursorPosition++;
                Show();
            }
        }

        public override void OnNumberPress(int i)
        {
            if(IsLettersOnly == false)
                AddSymbol(i.ToString());
        }

        public override void OnDeletePress()
        {
            if(_rawText[0].Length > 0)
            {
                _rawText[0] = _rawText[0].Remove(CursorPosition, 1);

                if(_rawText[0].Length > 0 && CursorPosition > _rawText[0].Length - 1)
                {
                    CursorPosition = _rawText[0].Length - 1;
                }
                else if (_rawText[0].Length == 0)
                {
                    CursorPosition = 0;
                }

                Initialize();
                Show();
            }
        }

        public override void OnBackspacePress()
        {
            if(CursorPosition > 0 && _rawText[0].Length >= 1)
            {
                _rawText[0] = _rawText[0].Remove(CursorPosition-1, 1);
                CursorPosition--;

                Initialize();
                Show();
            }
        }

        public override void OnLetterPress(string str)
        {
            if (IsNumberOnly)
                return;

            System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-zA-Z]+$");
            
            if(str.Length == 1) 
                AddSymbol(str);
        }

        public override void OnEnterPress()
        {
            if (_handlers == null)
                return;

            if (_handlers.Count > 0)
                _handlers[0]?.Invoke(_rawText[0]);
        }

        protected virtual void AddSymbol(string symbol)
        {
            if(_rawText[0].Length < Length)
            {
                _rawText[0] = _rawText[0].Substring(0, CursorPosition) + symbol + _rawText[0].Substring(CursorPosition);
                Initialize();
                Show();
            }
        }
    }

    class VerticalMenu : UIelement
    {
        protected ConsoleColor ForegroundMenuColor { get; private set; } = ConsoleColor.White;
        protected ConsoleColor BackgroundMenuColor { get; private set; } = ConsoleColor.Blue;

        //TODO rename all protected fields with Upper letter
        protected int MenuPosition { get; private set; } = 0;

        public VerticalMenu(List<string> text, int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight) : base(text, x, y, length, height) { }

        public override void OnUpArrowPress()
        {
            if (MenuPosition > 0)
            {
                MenuPosition--;
                Show();
            }
        }

        public override void OnDownArrowPress()
        {
            if (MenuPosition < _rawText.Count - 1)
            {
                MenuPosition++;
                Show();
            }
        }

        public override void Show()
        {
            base.Show();

            Console.SetCursorPosition(PositionX + RootPositionX, PositionY + RootPositionY + MenuPosition);

            Console.ForegroundColor = ForegroundMenuColor;
            Console.BackgroundColor = BackgroundMenuColor;

            Console.Write(_lines[MenuPosition]);

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
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

        protected int RootPositionX = 0;
        protected int RootPositionY = 0;

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
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(PositionX + RootPositionX, PositionY + RootPositionY);

            foreach (string line in _lines)
            {
                Console.WriteLine(line);
                Console.SetCursorPosition(PositionX + RootPositionX, Console.CursorTop);
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
            element.SetRoot(this);
            Show();
        }

        virtual public void SetRoot(UIelement element)
        {
            _rootElement = element;

            if (_rootElement != null)
            {
                RootPositionX = _rootElement.PositionX;
                RootPositionY = _rootElement.PositionY;
            }
        }

        virtual public void SetColor(ConsoleColor foreground, ConsoleColor background)
        {
            ForegroundColor = foreground;
            BackgroundColor = background;
        }

        virtual public void OnLeftArrowPress()
        {
            if (_childElements != null)
                foreach (var child in _childElements)
                    child.OnLeftArrowPress();
        }

        virtual public void OnRightArrowPress()
        {
            if (_childElements != null)
                foreach (var child in _childElements)
                    child.OnRightArrowPress();
        }

        virtual public void OnUpArrowPress() 
        {
            if (_childElements != null)
                foreach (var child in _childElements)
                    child.OnUpArrowPress();
        }

        virtual public void OnDownArrowPress()
        {
            if (_childElements != null)
                foreach (var child in _childElements)
                    child.OnDownArrowPress();
        }

        virtual public void OnDeletePress()
        {
            if (_childElements != null)
                foreach (var child in _childElements)
                    child.OnDeletePress();
        }

        virtual public void OnBackspacePress()
        {
            if (_childElements != null)
                foreach (var child in _childElements)
                    child.OnBackspacePress();
        }

        virtual public void OnEnterPress() 
        {
            if (_childElements != null)
                foreach (var child in _childElements)
                    child.OnEnterPress();
        }

        virtual public void OnNumberPress(int i) 
        {
            if (_childElements != null)
                foreach (var child in _childElements)
                    child.OnNumberPress(i);
        }

        virtual public void OnLetterPress(string str) 
        {
            if (_childElements != null)
                foreach (var child in _childElements)
                    child.OnLetterPress(str);
        }

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
        public event Action OnDeletePress;
        public event Action OnEnterPress;
        public event Action OnBackspacePress;
        public event Action<int> OnNumberPress;
        public event Action<string> OnLetterPress;

        //TODO переделать на отдельно цифры и буквы
        public event Action<string> SendKeySymbol;

        public void Update()
        {
            ConsoleKeyInfo key;

            key = Console.ReadKey(true);

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

                case ConsoleKey.LeftArrow:
                    OnLeftArrowPress?.Invoke();
                    break;

                case ConsoleKey.RightArrow:
                    OnRightArrowPress?.Invoke();
                    break;

                case ConsoleKey.UpArrow:
                    OnUpArrowPress?.Invoke();
                    break;

                case ConsoleKey.DownArrow:
                    OnDownArrowPress?.Invoke();
                    break;

                case ConsoleKey.Delete:
                    OnDeletePress?.Invoke();
                    break;

                case ConsoleKey.Backspace:
                    OnBackspacePress?.Invoke();
                    break;

                case ConsoleKey.Enter:
                    OnEnterPress?.Invoke();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                case ConsoleKey.D6:
                case ConsoleKey.D7:
                case ConsoleKey.D8:
                case ConsoleKey.D9:
                    OnNumberPress?.Invoke((int)key.Key-48);
                    break;

                default:
                    OnLetterPress?.Invoke(key.KeyChar.ToString());
                    break;
            }
        }
    }
}
