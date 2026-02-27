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

Диспетчер - это модель, а класс Application это view-ха которая отвечает за ввод и вывод
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
        Dispatcher dispatcher = new Dispatcher();
        private ApplicationState _currentState = ApplicationState.Initialize;

        public void Run()
        {
            while (_isWorking)
            {
                switch (_currentState)
                {
                    case ApplicationState.Initialize:
                        break;
                    case ApplicationState.ViewTrains:
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

        }

        private void ViewTrains()
        {

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
        private List<Train> _trains = new List<Train>();
        private Train _newTrain;
        private List<string> _vanTypesListing = new List<string>();
        private int _lastTrainNumber = 0;

        public Dispatcher()
        {
            _lastTrainNumber++;
            _newTrain = new Train(_lastTrainNumber);
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
