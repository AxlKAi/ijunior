using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_7_TrainDispatcher
{
    class WindowsManager
    {
        const ConsoleColor MainWindowBackgroundColor = ConsoleColor.DarkBlue;
        const ConsoleColor MainWindowForegroundColor = ConsoleColor.Yellow;
        const ConsoleColor TopMenuBackgroundColor = ConsoleColor.Cyan;
        const ConsoleColor TopMenuForegroundColor = ConsoleColor.Black;
        const ConsoleColor BottomLineForegroundColor = ConsoleColor.Black;
        const ConsoleColor BottomLineBackgroundColor = ConsoleColor.White;

        //TODO change space to tab 
        private string _topLine = "   F5 - View trains     F1 - About     F4 - close window ";
        private int _windowWidth;
        private int _windowHeight;
        private InputSystem _inputSystem;
        private string _lastLog;

        private int _lastWindowIndex = 0;
        private Dictionary<string, Window> _windows = new Dictionary<string, Window>();

        private Window _activeWindow;

        public WindowsManager(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
            _inputSystem.SendKeySymbol += ShowLog;

            Console.CursorVisible = false;

            _windowWidth = Console.WindowWidth;
            _windowHeight = Console.WindowHeight;

            for (int i = _topLine.Length; i < _windowWidth; i++)
            {
                _topLine += " ";
            }

            ClearBackground();
        }

        public Window CreateWindow(string title, List<string> text, int x = 10, int y = 4, int length = 20, int height = 5, string windowTag = "")
        {
            if(windowTag == "")
            {
                windowTag = (++_lastWindowIndex).ToString();
            }

            foreach (KeyValuePair<string, Window> window in _windows)
            {
            // do something with window.Value or window.Key
                window.Value.SetActive(false);

                //TODO по хорошему тут надо не все окна перерисовывать, 
                // а только последнее активное делать серым
                RenewWindows();
            }

            var newWindow = new Window(title, text, x, y, length, height);
            CollectWindow(windowTag, newWindow);

            if (_activeWindow != null)
            {
                UnscribeActiveWindowToEvents();
            }

            _activeWindow = newWindow;
            SubscribeActiveWindowToEvents();

            return _activeWindow;
        }

        public void CollectWindow(string windowTag, Window window)
        {
            if(window != null)
                _windows.Add(windowTag, window);
        }

        public Window GetWindow(string windowTag)
        {
            if (_windows.ContainsKey(windowTag))
                return _windows[windowTag];
            else
                return null;
        }

        public void CloseWindow(string windowTag)
        {
            //TODO Тут надо добавить обработчик события закрытия окна !!!

            if (_windows.ContainsKey(windowTag))
                _windows.Remove(windowTag);

            RenewWindows();
        }

        public void CloseWindow(Window window)
        {
            //TODO Тут надо добавить обработчик события закрытия окна !!!

            var windowKey = _windows.FirstOrDefault(x => x.Value == window).Key;

            if (windowKey != null)
                _windows.Remove(windowKey);

            RenewWindows();
        }

        public void ShowLog(string s)
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
            _lastLog = s;

            Console.ForegroundColor = currentForeground;
            Console.BackgroundColor = currentBackground;
        }

        public void CloseActiveWindow()
        {
            UnscribeActiveWindowToEvents();
            CloseWindow(_activeWindow);

            if (_windows.Count > 0)
            {
                _activeWindow = _windows.Values.Last(); 
                _activeWindow.SetActive(true);
                SubscribeActiveWindowToEvents();
            }

            RenewWindows();
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
                //TODO по хорошему нужен отдельный метод, гне надо не все окна перерисовывать, 
                // а только последнее активное делать серым
            ClearBackground();

            foreach (KeyValuePair<string, Window> window in _windows)
            {
                // do something with window.Value or window.Key
                window.Value.Show();

            }

            ShowLog(_lastLog);
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
        //TODO можно перенести в базовый, и рисовать бордюры по bool параметру у любых элементов
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

        //TODO title перенести в базовый
        public string Title { get; protected set; }

        public ConsoleColor ShadowColor { get; protected set; } = ConsoleColor.Black;

        public Window() : this("", new List<string>(), DefaultX, DefaultY, DefaultLength, DefaultHeight) { }

        public Window(int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight) : this("", new List<string>(), x, y, length, height) { }

        public Window(string title, List<string> text, int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight) : base(text, x, y, length, height)
        {
            Title = title;
            RawText = text;

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

            if (IsActive)
                Console.BackgroundColor = BackgroundColor;
            else
                Console.BackgroundColor = NonActiveColor;

            Console.ForegroundColor = ForegroundColor;
            Console.SetCursorPosition(PositionX, PositionY);

            foreach (string line in Lines)
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
            Lines = new List<string>();

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
            Lines.Add(title);

            for (int i = 0; i < Height; i++)
            {
                string s;

                if (i < RawText.Count)
                    s = RawText[i] + space;
                else
                    s = space;

                if (s.Length > Length)
                    s = s.Remove(Length);

                Lines.Add(VerticalSymbol + s + VerticalSymbol);
            }

            Lines.Add(LowLeftSymbol + graphicLine + LowRightSymbol);

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
            if (ChildElements.Count == 0)
                return;

            foreach (var element in ChildElements)
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

            Console.Write(Lines[0][CursorPosition]);

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
            if (CursorPosition < RawText[0].Length && CursorPosition < Length - 1)
            {
                CursorPosition++;
                Show();
            }
        }

        public override void OnNumberPress(int i)
        {
            if (IsLettersOnly == false)
                AddSymbol(i.ToString());
        }

        public override void OnDeletePress()
        {
            if (RawText[0].Length > 0)
            {
                RawText[0] = RawText[0].Remove(CursorPosition, 1);

                if (RawText[0].Length > 0 && CursorPosition > RawText[0].Length - 1)
                {
                    CursorPosition = RawText[0].Length - 1;
                }
                else if (RawText[0].Length == 0)
                {
                    CursorPosition = 0;
                }

                Initialize();
                Show();
            }
        }

        public override void OnBackspacePress()
        {
            if (CursorPosition > 0 && RawText[0].Length >= 1)
            {
                RawText[0] = RawText[0].Remove(CursorPosition - 1, 1);
                CursorPosition--;

                Initialize();
                Show();
            }
        }

        public override void OnLetterPress(EventArguments message)
        {
            if (IsNumberOnly)
                return;

            System.Text.RegularExpressions.Regex.IsMatch(message.Message, @"^[a-zA-Z]+$");

            if (message.Message.Length == 1)
                AddSymbol(message.Message);
        }

        public override void OnEnterPress()
        {
            if (Handlers == null)
                return;

            if (Handlers.Count > 0)
            {
                var message = new EventArguments();
                message.Message = RawText[0];

                if(IsNumberOnly)
                {
                    bool result = Int32.TryParse(RawText[0], out var number);

                    if (result)
                        message.DigitalData = number;
                    else
                        message.DigitalData = 0;
                }

                Handlers[0]?.Invoke(message);
            }
        }

        protected virtual void AddSymbol(string symbol)
        {
            if (RawText[0].Length < Length)
            {
                RawText[0] = RawText[0].Substring(0, CursorPosition) + symbol + RawText[0].Substring(CursorPosition);
                
                if(CursorPosition<Length-1) 
                    CursorPosition++;

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

        public VerticalMenu() : this(new List<string>(), DefaultX, DefaultY, DefaultLength, DefaultHeight) { }
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
            if (MenuPosition < RawText.Count - 1)
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

            Console.Write(Lines[MenuPosition]);

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
        }

        public override void OnEnterPress()
        {
            if (Handlers == null)
                return;

            if (Handlers.Count > 0 && MenuPosition < Handlers.Count)
            {
                var message = new EventArguments();
                message.Message = RawText[MenuPosition];
                message.DigitalData = MenuPosition;
                Handlers[MenuPosition]?.Invoke(message);
            }
        }
    }

    class UIelement
    {
        protected const int DefaultX = 1;
        protected const int DefaultY = 1;
        protected const int DefaultLength = 5;
        protected const int DefaultHeight = 5;

        protected List<string> Lines;
        protected List<string> RawText;
        protected List<UIelement> ChildElements = new List<UIelement>();
        protected UIelement RootElement = null;
        protected List<Action<EventArguments>> Handlers;

        protected int RootPositionX = 0;
        protected int RootPositionY = 0;


        public int PositionX { get; protected set; } = 1;
        public int PositionY { get; protected set; } = 1;
        public int Length { get; protected set; } = 5;
        public int Height { get; protected set; } = 5;
        public bool IsActive { get; protected set; } = true;

        public ConsoleColor BackgroundColor { get; protected set; } = ConsoleColor.Gray;
        public ConsoleColor ForegroundColor { get; protected set; } = ConsoleColor.Black;
        public ConsoleColor NonActiveColor { get; protected set; } = ConsoleColor.DarkGray;

        //public UIelement() : this(new List<string>()) { }

        public UIelement(List<string> text, int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight)
        {
            RawText = text;

            PositionX = x;
            PositionY = y;
            Length = length;
            Height = height;

            Initialize();
        }

        virtual public void Show()
        {
            ConsoleColor currentForeground = Console.ForegroundColor;
            ConsoleColor currentBackground = Console.BackgroundColor; ;

            Console.ForegroundColor = ForegroundColor;

            if (IsActive)
                Console.BackgroundColor = BackgroundColor;
            else
                Console.BackgroundColor = NonActiveColor;

            Console.SetCursorPosition(PositionX + RootPositionX, PositionY + RootPositionY);

            foreach (string line in Lines)
            {
                Console.WriteLine(line);
                Console.SetCursorPosition(PositionX + RootPositionX, Console.CursorTop);
            }

            Console.ForegroundColor = currentForeground;
            Console.BackgroundColor = currentBackground;
        }

        virtual public void ChangeContent(List<string> text)
        {
            RawText = text;

            Initialize();
        }

        virtual public void AddChild(UIelement element)
        {
            ChildElements.Add(element);
            element.SetRoot(this);
            Show();
        }

        virtual public void SetRoot(UIelement element)
        {
            RootElement = element;

            if (RootElement != null)
            {
                RootPositionX = RootElement.PositionX;
                RootPositionY = RootElement.PositionY;
            }
        }

        virtual public void SetColor(ConsoleColor foreground, ConsoleColor background)
        {
            ForegroundColor = foreground;
            BackgroundColor = background;
        }

        virtual public void SetHandlers(List<Action<EventArguments>> handlers)
        {
            Handlers = handlers;
        }

        virtual public void SetActive(bool isActive)
        {
            IsActive = isActive;

            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.SetActive(isActive);
        }

        virtual public void OnLeftArrowPress()
        {
            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.OnLeftArrowPress();
        }

        virtual public void OnRightArrowPress()
        {
            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.OnRightArrowPress();
        }

        virtual public void OnUpArrowPress()
        {
            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.OnUpArrowPress();
        }

        virtual public void OnDownArrowPress()
        {
            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.OnDownArrowPress();
        }

        virtual public void OnDeletePress()
        {
            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.OnDeletePress();
        }

        virtual public void OnBackspacePress()
        {
            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.OnBackspacePress();
        }

        virtual public void OnEnterPress()
        {
            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.OnEnterPress();
        }

        virtual public void OnNumberPress(int i)
        {
            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.OnNumberPress(i);
        }

        virtual public void OnLetterPress(EventArguments message)
        {
            if (ChildElements != null)
                foreach (var child in ChildElements)
                    child.OnLetterPress(message);
        }

        virtual protected void Initialize()
        {
            Lines = new List<string>();

            string space = "";

            for (int i = 0; i < Length; i++)
            {
                space += " ";
            }

            for (int i = 0; i < Height; i++)
            {
                string s;

                if (i < RawText.Count)
                    s = RawText[i] + space;
                else
                    s = space;

                if (s.Length > Length)
                    s = s.Remove(Length);

                Lines.Add(s);
            }
        }
    }

}
