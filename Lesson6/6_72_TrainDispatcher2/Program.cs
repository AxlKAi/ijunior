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

Вагон
	id
	тип (Сидячий вагон / Плацкартный вагон / Общий вагон / Купейный вагон)
	мест кол-во максимум
	мест заполнено

Поезд 
	id
	Город 1
	Город 2
	Количество Вагонов 
    Тип вагонов
	Пассажиров кол-во {Property}

Диспетчер - это модель, а класс Application это view-ха + controller, которая отвечает за ввод и вывод
	Поезда List
	TryAddTownArriwed
    TryAddTown
    SetNewTrainVanType
    TryTakeNumberOfPlaces
    TryCreateNewTrain
    ShowAllTrains
	*/

    public enum ApplicationState { Initialize, ViewTrains, ShowStartMenu, InitializeNewTrain, SelectDestination, SelectVanType, SellTickets, CreateNewTrain }

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
        private ApplicationState _currentState = ApplicationState.Initialize;
        Dispatcher _dispatcher = new Dispatcher();

        public void Run()
        {
            while (_isWorking)
            {
                switch (_currentState)
                {
                    case ApplicationState.Initialize:
                        Initialize();
                        break;

                    case ApplicationState.ViewTrains:
                        ViewTrains();
                        break;

                    case ApplicationState.ShowStartMenu:
                        break;

                    case ApplicationState.SelectDestination:
                        break;

                    case ApplicationState.InitializeNewTrain:
                        break;

                    case ApplicationState.SelectVanType:
                        break;

                    case ApplicationState.SellTickets:
                        break;

                    case ApplicationState.CreateNewTrain:
                        break;
                }
            }
        }

        private void Initialize()
        {
            Console.Clear();
            Console.WriteLine("--------- Диспетчер поездов ---------");
            Console.WriteLine();

            _currentState = ApplicationState.ViewTrains;
        }

        private void ViewTrains()
        {
            Console.WriteLine("Расписание поездов:");

            foreach (Train train in _dispatcher.Trains)
            {
                Console.WriteLine($"N={train.Number}, {train.DepartureCity}-{train.ArrivalCity} мест куплено:{train.SeatsOccupiedCount}");
            }

            _currentState = ApplicationState.ShowStartMenu;
        }

        private void ShowStartMenu()
        {

        }

        private void InitializeNewTrain() 
        { 
        
        }

        private void EnterDestinationsTowns()
        {

        }

        private void SelectVanType()
        {

        }

        private void SellTickets()
        {

        }

        private void CreateNewTrain()
        {

        }
    }


    class Dispatcher
    {
        private readonly List<Train> _trains = new List<Train>();
        public IReadOnlyList<Train> Trains => _trains;

        private Train _creatingTrain;
        private int _newTrainNumber = 1;

        public Dispatcher()
        {
            _trains.Add(new Train(_newTrainNumber++, "Москва", "Барнаул", 250, VanType.SecondClass));
            _trains.Add(new Train(_newTrainNumber++, "Ленинград", "Сталинград", 250, VanType.Сompartment));
            _trains.Add(new Train(_newTrainNumber++, "Каспийск", "Шерегеш", 250, VanType.Siting));
        }


    }

    class Train
    {
        public string DepartureCity { get; private set; }
        public string ArrivalCity { get; private set; }
        public int Number { get; private set; }
        public int SeatsOccupiedCount { get; private set; }

        public VanType VanType { get; private set; }

        public Train(int number)
        {
            Number = number;
        }

        public Train(int number, string departureCity, string arrivalCity, int seatsOccupies, VanType vanType)
        {
            //TODO добавить проверки через ментоды Set
            Number = number;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            SeatsOccupiedCount = seatsOccupies;
            VanType = vanType;
        }

        public int GetTotalSeats()
        {
            //TODO logic
            int totalSeats = 0;

            return totalSeats;
        }

        public void SetSeatsOccupiedCount(int seats)
        {
            //TODO logic
            SeatsOccupiedCount = seats;
        }

        public bool CheckTownNameValidity(string name)
        {
            bool isTownNameValid = false;

            return isTownNameValid;
        }

        public bool TrySetArrivalCity(string name, out string logMessage)
        {
            if (CheckTownNameValidity(name))
            {
                logMessage = "ok";
                return true;
            }
            else
            {
                logMessage = "false";
                return false;
            }
        }

        public bool TrySetDepartureCity(string name, out string logMessage)
        {
            if (CheckTownNameValidity(name))
            {
                logMessage = "ok";
                return true;
            }
            else
            {
                logMessage = "false";
                return false;
            }
        }


        public void SetVanType(VanType type)
        {
            VanType = type;
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
    }
}
