using System;

namespace _6_7_TrainDispatcher
{

    class EventArguments
    {
        public string Message;
        public int DigitalData;
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
        public event Action<EventArguments> OnLetterPress;

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
                    OnNumberPress?.Invoke((int)key.Key - 48);
                    break;

                default:
                    //TODO make one line
                    var mes = new EventArguments();
                    mes.Message = key.KeyChar.ToString();
                    OnLetterPress?.Invoke(mes);
                    break;
            }
        }
    }
}