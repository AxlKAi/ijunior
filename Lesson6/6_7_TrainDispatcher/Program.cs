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
            _input.OnExit += ExitEventCalled;
            _input.OnF1Press += ShowHelpWindow;
            _input.OnReturn += ReturnEventCalled;
            _input.OnF2Press += ShowDemoWindow;

            CreateMainTrainViewWindow();
        }

        private void CreateMainTrainViewWindow()
        {
            var trainWindowText = new List<string>
            {
                "",
                " №      Направление                                    Всего мест           Продано билетов      Тип вагона",
            };

            var trainListText = new List<string>
            {
                "777    Москва-Варкута                                     777                  775                  купе ",
                "888    Пермь-Казань                                       777                  775                  сидячий",
                "999    Питер-Уфа                                          777                  775                  плацкарт",
            };

            var window = _windowsManager.CreateWindow("Поезда", trainWindowText, 3, 3, 110, 15);
            var trainsList = new VerticalMenu(trainListText, 2,3,106,12);
            window.AddChild(trainsList);
        }

        private void ExitEventCalled()
        {
            _isWorking = false;
        }

        public void ReturnEventCalled()
        {
            _windowsManager.CloseActiveWindow();
            _windowsManager.ShowBottomBorder("Close window");
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

    class Dispatcher
    {
        private List<Train> _trains = new List<Train>();
    }

    class Train
    {
        public Destination Destination { get; private set; }
    }

    class Van
    {
        public int TotalSeats { get; private set; }
        public int SeatsSold { get; private set; }
    }

    class Destination
    {
        public string Hometown { get; private set; }
        public int DestinationTown { get; private set; }
    }
}
