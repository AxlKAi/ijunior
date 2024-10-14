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
        public void Run()
        {
            Console.Write("test");
            var mainMenu = new MainInterface();
            mainMenu.DrawBackground();
        }
    }

    class MainInterface
    {
        const ConsoleColor MainWindowBackgroundColor = ConsoleColor.DarkBlue;
        const ConsoleColor MainWindowForegroundColor = ConsoleColor.Yellow;
        const ConsoleColor TopMenuBackgroundColor = ConsoleColor.Cyan;
        const ConsoleColor TopMenuForegroundColor = ConsoleColor.Black;

        private string _TopLine;

        public void DrawBackground()
        {
            Console.BackgroundColor = MainWindowBackgroundColor;
            Console.ForegroundColor = MainWindowForegroundColor;
            Console.Clear();

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                _TopLine += " ";
            }

            Console.ForegroundColor = TopMenuForegroundColor;
            Console.BackgroundColor = TopMenuBackgroundColor;

            Console.SetCursorPosition(0, 0);
            Console.Write(_TopLine);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(" Space - create train     F1 - About");

            Console.BackgroundColor = MainWindowBackgroundColor;
            Console.ForegroundColor = MainWindowForegroundColor;

            //TODO delete
            var w = Console.WindowWidth;
            var h = Console.WindowHeight;
            Console.WriteLine($"Width:{w}");
            Console.WriteLine($"Height:{h}");
        }

        public void CreateWindow()
        {

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

        const int DefaultX = 10;
        const int DefaultY = 4;
        const int DefaultLength = 80;
        const int DefaultHeight = 15;

        private List<string> _lines;

        public Window() : this(DefaultX, DefaultY, DefaultLength, DefaultHeight) { }

        public Window(int x = DefaultX, int y = DefaultY, int length = DefaultLength, int height = DefaultHeight)
        {
            _lines = new List<string>();

            string line = "";
            string space = "";
            string graphicLine = "";

            for (int i = 0; i < x; i++)
            {
                graphicLine += HorizontalSymbol;
                space += " ";
            }

            _lines.Add(UpLeftSymbol + graphicLine + UpRightSymbol);

            for (int i = 0; i < y; i++)
                _lines.Add( VerticalSymbol + space + VerticalSymbol);

            line += LowLeftSymbol + graphicLine + LowRightSymbol;



        }
    }
}
