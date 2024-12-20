﻿using System;
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
    public enum State { Initialize, ViewTrains, TrainNumber, SelectDestination, SelectVanType, SellTickets, ViewNewTrain }

    class Program
    {

        static void Main(string[] args)
        {
            Dispatcher application = new Dispatcher();

            application.Run();
        }
    }

    class Dispatcher
    {
        private const string TrainsWindowTag = "main";
        private const string DirectionsWindowTag = "directions";
        private const string NewDirectionsWindowTag = "newDirection";
        private const string HomeTownWindow = "homeTown";
        private const string DestinationTownWindow = "destinationTown";
        private const string VanTypeWindow = "vanType";
        private const string SellTicketWindow = "sellTickets";
        private const string NewTrainWindow = "winScreen";

        private List<Train> _trains = new List<Train>();
        private List<Direction> _directions = new List<Direction>();
        private bool _isWorking = true;
        private InputSystem _input = new InputSystem();
        private WindowsManager _windowsManager;
        private Train _newTrain = new Train();
        private List<string> _vanTypesListing = new List<string>();
        private State _currentState = State.Initialize;

        public void Run()
        {
            SetDefaults();

            while (_isWorking)
            {
                _input.Update();
            }
        }

        private void ProductionEvent(EventArguments eventArguments)
        //сюда приходить eventArguments
        {
            // окна можно добавить в отдельные поля, и управлять ими из switch
            // то есть я не открываю из одного окра другое, а просто вызываю этот метод
            // а он уже что надо открывает

            switch (_currentState)
            {
                case State.Initialize:
                    SetViewTrainsState();
                    break;

                case State.ViewTrains:
                    SetTrainNumberState(eventArguments);
                    break;

                case State.TrainNumber:
                    SetDestinationState(eventArguments);
                    break;

                case State.SelectDestination:
                    SetVanTypeState(eventArguments);
                    break;

                case State.SelectVanType:
                    SetSellTicketsState(eventArguments);
                    break;

                case State.SellTickets:
                    SetNewTrainState(eventArguments);
                    break;

                case State.ViewNewTrain:
                    ReturnViewTrainsState();
                    break;
            }

        }

        private void ReturnEvent()
        {
            //TODO это событие вызывается только в важных окнах
            //влияющих на статус машины состояний
            switch (_currentState)
            {
                /*
                case State.Initialize:
                    SetViewTrainsState();
                    break;
                */
                case State.ViewTrains:
                    ExitEventCalled();
                    break;

                case State.TrainNumber:
                    ReturnViewTrainsState();
                    break;

                case State.SelectDestination:
                    ReturnTrainNumberState();
                    break;

                case State.SelectVanType:
                    ReturnSelectDestinationState();
                    break;

                case State.SellTickets:
                    ReturnSelectVanTypeState();
                    break;

                case State.ViewNewTrain:
                    ReturnViewTrainsState();
                    break;
            }            
        }

        private void CloseWindow()
        {
            _windowsManager.CloseActiveWindow();
        }

        private void HelpEvent()
        {
            switch (_currentState)
            {
                /*
                case State.Initialize:
                    SetViewTrainsState();
                    break;
                */
                case State.ViewTrains:
                    ShowHelpWindow(new List<string>() { nameof(State.ViewTrains) });
                    break;

                case State.TrainNumber:
                    ShowHelpWindow(new List<string>() { nameof(State.TrainNumber) });
                    break;

                case State.SelectDestination:
                    ShowHelpWindow(new List<string>() { nameof(State.SelectDestination) });
                    break;

                case State.SelectVanType:
                    ShowHelpWindow(new List<string>() { nameof(State.SelectVanType) });
                    break;

                case State.SellTickets:
                    ShowHelpWindow(new List<string>() { nameof(State.SellTickets) });
                    break;

                case State.ViewNewTrain:
                    ShowHelpWindow(new List<string>() { nameof(State.ViewNewTrain) });
                    break;
            }
        }

        private void SetViewTrainsState()
        {
            _currentState = State.ViewTrains;
            ShowTrainsListWindow();
        }

        private void SetTrainNumberState(EventArguments eventArguments)
        {
            _currentState = State.TrainNumber;
            ShowTrainNumberWindow(eventArguments);
        }

        private void SetDestinationState(EventArguments eventArguments)
        {
            _newTrain = new Train(eventArguments.DigitalData);
            _currentState = State.SelectDestination;
            ShowSelectDirectionWindow(eventArguments);
        }

        private void SetVanTypeState(EventArguments eventArguments)
        {
            _newTrain.SetDirections(_directions[eventArguments.DigitalData]);
            _currentState = State.SelectVanType;
            ShowVanTypeWindow(eventArguments);
        }

        private void SetSellTicketsState(EventArguments eventArguments)
        {
            _currentState = State.SellTickets;
            _newTrain.SetVanType((VanType)eventArguments.DigitalData);
            ShowSellTicketsWindow(eventArguments);
        }

        private void SetNewTrainState(EventArguments eventArguments)
        {
            _currentState = State.ViewNewTrain;
            _newTrain.SellSeats(eventArguments.DigitalData);
            ShowNewTrainWindow(eventArguments);
            _trains.Add(_newTrain);
            _windowsManager.ShowLog($"Сохранен новый поезд : {_newTrain.ToString()}");
            _newTrain = new Train();
        }

        private void SubscribeEvents()
        {
            _input.OnExit += ExitEventCalled;
            _input.OnF1Press += HelpEvent;
            _input.OnEscPress += CloseWindow;
            _input.OnF2Press += ShowDemoWindow;
        }

        private void SetDefaults()
        {
            _windowsManager = new WindowsManager(_input);
            SubscribeEvents();

            _directions.Add(new Direction("Москва", "Варкута"));
            _directions.Add(new Direction("Пермь", "Казань"));
            _directions.Add(new Direction("Питер", "Уфа"));
            _directions.Add(new Direction("Брянск", "Минск"));
            _directions.Add(new Direction("Тамбов", "Челябинск"));
            _directions.Add(new Direction("Пермь", "Екатеринбурк"));
            _directions.Add(new Direction("Москва", "Подольск"));

            foreach (VanType van in Enum.GetValues(typeof(VanType)))
            {
                _vanTypesListing.Add(new Van(van).Name);
            }

            var train1 = new Train(111);
            train1.SetDirections(_directions[0]);
            train1.SetVanType(VanType.Сompartment);
            train1.SellSeats(254);
            _trains.Add(train1);

            var train2 = new Train(222);
            train2.SetDirections(_directions[1]);
            train2.SetVanType(VanType.Siting);
            train2.SellSeats(350);
            _trains.Add(train2);

            var train3 = new Train(333);
            train3.SetDirections(_directions[2]);
            train3.SetVanType(VanType.SecondClass);
            train3.SellSeats(400);
            _trains.Add(train3);

            var train4 = new Train(444);
            train4.SetDirections(_directions[3]);
            train4.SetVanType(VanType.Siting);
            train4.SellSeats(357);
            _trains.Add(train4);

            var train5 = new Train(555);
            train5.SetDirections(_directions[4]);
            train5.SetVanType(VanType.SecondClass);
            train5.SellSeats(410);
            _trains.Add(train5);

            _currentState = State.Initialize;

            var initEvent = new EventArguments();
            ProductionEvent(initEvent);
        }

        private void ReturnViewTrainsState() 
        {
            _currentState = State.ViewTrains;
            _windowsManager.CloseAllWindows();
        }

        private void ReturnTrainNumberState() 
        {
            _currentState = State.TrainNumber;
        }

        private void ReturnSelectDestinationState()
        {
            _currentState = State.SelectDestination;
        }

        private void ReturnSelectVanTypeState()
        {
            _currentState = State.SelectVanType;
        }

        private void ShowTrainsListWindow()
        {
            //TODO тут красиво будет если передавать объект класса настроек
            //я таким образом стандартизирую имена параметров, и лучше 
            //будет выглядеть сам код запуска
            int windowLength = 89;
            int windowTop = 3;
            int windowLeft = 14;
            int windowHeightPadding = 3;
            int listPaddingTop = 3;
            int listPaddingLeft = 2;
            int listLenght = windowLength - 4;

            var trainWindowText = new List<string>
            {
                "",
                "   №       Направление                                Всего     Продано   Тип",
            };

            var trainListText = new List<string>();
            trainListText.Add("     ...... Создать новый поезд ......");

            foreach (var train in _trains)
            {
                trainListText.Add(train.ToString());
            }

            var window = _windowsManager.CreateWindow("Поезда", trainWindowText, windowLeft, windowTop, windowLength, trainListText.Count + windowHeightPadding, TrainsWindowTag);
            var trainsList = new VerticalMenu(trainListText, listPaddingLeft, listPaddingTop, listLenght, trainListText.Count);
            window.AddChild(trainsList);
            var handlers = new List<Action<EventArguments>>();
            handlers.Add(ProductionEvent);

            if (trainListText.Count > 1)
                for (int i = 1; i < trainListText.Count; i++)
                    handlers.Add(ShowExistTrainWindow);

            trainsList.SetOnEnterHandlers(handlers);

            window.SetOnCloseHandlers(new List<Action>() { ReturnEvent });
        }

        private void ShowExistTrainWindow(EventArguments arguments)
        {
            //TODO сделать дизайн окна
            var window = _windowsManager.CreateWindow("Существующий поезд.", new List<string>(), 3, 10, 110, 5);
            var text = new UIelement(new List<string>() { arguments.Message }, 2, 2, 107, 1);
            window.AddChild(text);
        }

        private void ShowTrainNumberWindow(EventArguments arguments)
        {
            int windowLength = 19;
            int windowTop = 18;
            int windowLeft = 5;
            int windowHeight = 3;

            int textPaddingTop = 2;
            int textPaddingLeft = 2;
            int textLength = 15;

            int inputPaddingTop = 2;
            int inputPaddingLeft = 16;
            int inputLength = 3;

            var window = _windowsManager.CreateWindow("Номер поезда", new List<string>(), windowLeft, windowTop, windowLength, windowHeight);

            var text = new UIelement(new List<string>() { "Номер поезда: " }, textPaddingTop, textPaddingLeft, textLength, 1);

            var button = new Input("", inputPaddingLeft, inputPaddingTop, inputLength);
            button.SetNumbersOnly();
            button.SetColor(ConsoleColor.White, ConsoleColor.DarkBlue);

            var handlers = new List<Action<EventArguments>>();
            handlers.Add(ProductionEvent);
            button.SetOnEnterHandlers(handlers);

            window.AddChild(text);
            window.AddChild(button);

            window.SetOnCloseHandlers(new List<Action>() { ReturnEvent });
        }

        private void ShowSelectDirectionWindow(EventArguments arguments)
        {
            int windowLength = 46;
            int windowTop = 5;
            int windowLeft = 25;
            int windowHeightPadding = 3;
            int listPaddingTop = 2;
            int listPaddingLeft = 2;
            int listLenght = windowLength - 4;

            _windowsManager.ShowLog($"Номер будующего поезда {arguments.DigitalData}");

            var window = _windowsManager.CreateWindow("Выбор направления.", new List<string>(), windowLeft, windowTop, windowLength, _directions.Count + windowHeightPadding);
            var directionListText = new List<string>();
            directionListText.Add("..Новое направление..");

            foreach (var direction in _directions)
            {
                directionListText.Add(direction.ToString());
            }

            //TODO доработать логику добавления destination
            var list = new VerticalMenu(directionListText, listPaddingLeft, listPaddingTop, listLenght, directionListText.Count);
            var handlers = new List<Action<EventArguments>>();
            handlers.Add(ShowSelectHomeTownWindow);

            if (directionListText.Count > 1)
                for (int i = 1; i < directionListText.Count; i++)
                    handlers.Add(ProductionEvent);

            list.SetOnEnterHandlers(handlers);
            window.AddChild(list);

            window.SetOnCloseHandlers(new List<Action>() { ReturnEvent });
        }

        private void ShowVanTypeWindow(EventArguments arguments)
        {
            int windowLength = 20;
            int windowTop = 15;
            int windowLeft = 55;
            int windowHeightPadding = 3;
            int listPaddingTop = 2;
            int listPaddingLeft = 2;
            int listLenght = windowLength - 4;

            _windowsManager.ShowLog($"Направление поезда {arguments.Message}");

            var window = _windowsManager.CreateWindow("Тип вагона.", new List<string>(), windowLeft, windowTop, windowLength, _vanTypesListing.Count + windowHeightPadding);
            var list = new VerticalMenu(_vanTypesListing, listPaddingLeft, listPaddingTop, listLenght, _vanTypesListing.Count);
            var handlers = new List<Action<EventArguments>>();

            foreach (var unit in _vanTypesListing)
                handlers.Add(ProductionEvent);

            list.SetOnEnterHandlers(handlers);
            window.AddChild(list);
            window.SetOnCloseHandlers(new List<Action>() { ReturnEvent });
        }

        private void ShowSellTicketsWindow(EventArguments arguments)
        {
            int windowLength = 22;
            int windowTop = 19;
            int windowLeft = 35;
            int windowHeight = 3;

            int textPaddingTop = 2;
            int textPaddingLeft = 2;
            int textLength = 17;

            int inputPaddingTop = 2;
            int inputPaddingLeft = 19;
            int inputLength = 3;

            //TODO delete
            //_newTrain.SetVanType((VanType)arguments.DigitalData);

            //TODO убрать вообще из всех методов SHOW ту часть что отвечает 
            // за создание нового поезда

            _windowsManager.ShowLog($"Тип вагона №{arguments.DigitalData} {arguments.Message} ");

            var window = _windowsManager.CreateWindow("Билетов продано", new List<string>(), windowLeft, windowTop, windowLength, windowHeight);

            var text = new UIelement(new List<string>() { "Билетов продано: " }, textPaddingTop, textPaddingLeft, textLength, 1);

            var input = new Input("", inputPaddingLeft, inputPaddingTop, inputLength);
            input.SetNumbersOnly();
            input.SetColor(ConsoleColor.White, ConsoleColor.DarkBlue);

            var handlers = new List<Action<EventArguments>>();
            handlers.Add(ProductionEvent);
            input.SetOnEnterHandlers(handlers);

            window.AddChild(text);
            window.AddChild(input);
            window.SetOnCloseHandlers(new List<Action>() { ReturnEvent });
        }

        private void ShowNewTrainWindow(EventArguments arguments)
        {
            int leftColumn = 15;
            int rightColumn = 40;

            List<string> outputText = new List<string>()
            {
                " Cоздан поезд :",
                "",
                _newTrain.ToString()
            };

            outputText.AddRange(_newTrain.ToList(leftColumn, rightColumn));

            int windowLength = leftColumn + rightColumn + 2;
            int windowTop = 8;
            int windowLeft = 35;

            int textPaddingTop = 2;
            int textPaddingLeft = 2;
            int textLength = outputText[1].Length;

            int buttonPaddingTop = 2;
            int buttonPaddingLeft = 16;
            List<string> buttonText = new List<string>() { "[   ОК   ]" };
            int buttonLength = buttonText[0].Length;

            int windowHeight = outputText.Count + buttonPaddingTop + 3;

            var window = _windowsManager.CreateWindow("Сохранен поезд", new List<string>(), windowLeft, windowTop, windowLength, windowHeight);
            window.SetColor(ConsoleColor.Red, ConsoleColor.DarkGreen);

            var text = new UIelement(outputText, textPaddingTop, textPaddingLeft, textLength, outputText.Count);

            var button = new VerticalMenu(buttonText, buttonPaddingLeft, buttonPaddingTop, buttonLength);
            button.SetColor(ConsoleColor.White, ConsoleColor.Blue);

            var handlers = new List<Action<EventArguments>>();
            handlers.Add(ShowSelectDirectionWindow);
            button.SetOnEnterHandlers(handlers);

            window.AddChild(text);
            window.AddChild(button);
            window.SetOnCloseHandlers(new List<Action>() { ReturnEvent });
        }





        private void ShowSelectHomeTownWindow(EventArguments arguments)
        {
            var window = _windowsManager.CreateWindow("Город отправления.", new List<string>(), 35, 12, 35, 6);
            var text = new UIelement(new List<string>() { "Введите город ИЗ которого отправляется поезд." }, 2, 2, 31, 1);
            var input = new Input("", 2, 4, 31);
            input.SetColor(ConsoleColor.White, ConsoleColor.DarkBlue);
            window.AddChild(text);
            window.AddChild(input);
        }

        private void ExitEventCalled()
        {
            _isWorking = false;
        }

        private void ShowHelpWindow(List<string> text)
        {
            var window = _windowsManager.CreateWindow("Help", text, 20, 10, 40, 15);
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
            input.SetOnEnterHandlers(new List<Action<EventArguments>>() { ShowResultScreen });
            window.AddChild(input);
        }

        private void ShowResultScreen(EventArguments message)
        {
            var window = _windowsManager.CreateWindow("result", new List<string>() { $" Congratulations!", $" {message.Message} is entered" }, 50, 15, 35, 5);
            window.SetColor(ConsoleColor.Green, ConsoleColor.Red);
            window.Show();
        }
    }

    class Train
    {
        public static int LastTrainNumber = 0;
        public Direction Direction { get; private set; }
        public int Number { get; private set; }

        public VanType VanType { get; private set; }

        private List<Van> _vans;

        public Train() : this(++LastTrainNumber) { }
        public Train(int number)
        {
            Number = number;
        }

        public void SetNumber(int num)
        {
            Number = num;
        }

        public int GetTotalSeats()
        {
            int totalSeats = 0;

            if (_vans != null)
            {
                foreach (var van in _vans)
                {
                    totalSeats += van.TotalSeats;
                }
            }

            return totalSeats;
        }

        public int GetSeatsSold()
        {
            int seatsSold = 0;

            if (_vans != null)
            {
                foreach (var van in _vans)
                {
                    seatsSold += van.SeatsSold;
                }
            }

            return seatsSold;
        }

        public void SetDirections(Direction direction)
        {
            Direction = direction;
        }

        public void SetVanType(VanType type)
        {
            VanType = type;
        }

        public void SellSeats(int seatsSold)
        {
            int seats = seatsSold;
            _vans = new List<Van>();

            while (seats > 0)
            {
                var van = new Van(VanType);
                _vans.Add(van);

                if (van.TotalSeats <= seats)
                {
                    van.TrySellSeats(van.TotalSeats);
                    seats -= van.TotalSeats;
                }
                else
                {
                    van.TrySellSeats(seats);
                    seats = 0;
                }
            }
        }

        public override string ToString()
        {
            int numberLength = 5;
            int directionLength = 40;
            int totalSeatsLength = 7;
            int soldSeatsLength = 7;
            int vanTypeLength = 12;
            string separator = " | ";

            string trainOut = separator + StrafeLeft(Number.ToString(), numberLength) + separator;
            trainOut += StrafeLeft(Direction.ToString(), directionLength) + separator;
            trainOut += StrafeLeft(GetTotalSeats().ToString(), totalSeatsLength) + separator;
            trainOut += StrafeLeft(GetSeatsSold().ToString(), soldSeatsLength) + separator;
            trainOut += StrafeLeft(_vans[0].Name, vanTypeLength) + separator;

            return trainOut;
        }

        public List<string> ToList(int leftLength, int rightLength)
        {
            var result = new List<string>();
            string separator = " | ";

            result.Add(StrafeLeft("Поезд №", leftLength) + separator + StrafeRight(Number.ToString(), rightLength));
            result.Add(StrafeLeft("Направление", leftLength) + separator + StrafeRight(Direction.ToString(), rightLength));
            result.Add(StrafeLeft("Тип вагона", leftLength) + separator + StrafeRight(_vans[0]?.Name, rightLength));
            result.Add(StrafeLeft("Всего мест", leftLength) + separator + StrafeRight(GetTotalSeats().ToString(), rightLength));
            result.Add(StrafeLeft("Мест продано", leftLength) + separator + StrafeRight(GetSeatsSold().ToString(), rightLength));

            return result;
        }

        private string StrafeLeft(string str, int length)
        {
            if (str.Length <= length)
                return str.PadRight(length);
            else
                return str.Remove(length);
        }

        private string StrafeRight(string str, int length)
        {
            if (str.Length <= length)
                return str.PadLeft(length);
            else
                return str.Remove(length);
        }
    }
    public enum VanType
    {
        Сompartment,
        SecondClass,
        Siting,
    }

    class Van
    {
        public const VanType DefaultType = VanType.Сompartment;

        public const int СompartmentSeatsAmmount = 36;
        public const int SecondClassSeatsAmmount = 50;
        public const int SitingSeatsAmmount = 70;

        public VanType Type { get; private set; }
        public int SeatsSold { get; private set; } = 0;
        public int TotalSeats { get; private set; } = 0;
        public string Name { get; private set; }

        public Van() : this(DefaultType) { }

        public Van(VanType Type)
        {
            switch (Type)
            {
                case VanType.Сompartment:
                    TotalSeats = СompartmentSeatsAmmount;
                    Name = "Купе";
                    break;

                case VanType.SecondClass:
                    TotalSeats = SecondClassSeatsAmmount;
                    Name = "Плацкарт";
                    break;

                case VanType.Siting:
                    TotalSeats = SitingSeatsAmmount;
                    Name = "Сидячий";
                    break;
            }
        }

        public bool TrySellSeats(int ammount)
        {
            if (ammount <= TotalSeats - SeatsSold)
            {
                SeatsSold += ammount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Direction
    {
        public string Hometown { get; private set; }
        public string DestinationTown { get; private set; }

        public Direction(string homeTown, string destination)
        {
            Hometown = homeTown;
            DestinationTown = destination;
        }

        override public string ToString()
        {
            return Hometown + "-" + DestinationTown;
        }
    }
}
