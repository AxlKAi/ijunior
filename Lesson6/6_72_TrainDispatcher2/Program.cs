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

    public enum ApplicationState { Initialize, ViewTrains, ShowStartMenu, InitializeNewTrain, EnterArrivalTown, EnterDestinationTown, SelectVanType, SellTickets, CreateNewTrain, ExitProgram }

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
                        ShowStartMenu();
                        break;

                    case ApplicationState.InitializeNewTrain:
                        InitializeNewTrain();
                        break;

                    case ApplicationState.EnterDestinationTown:
                        EnterDestinationsTowns();
                        break;

                    case ApplicationState.EnterArrivalTown:
                        EnterDestinationsTowns();
                        break;

                    case ApplicationState.SelectVanType:
                        SelectVanType();
                        break;

                    case ApplicationState.SellTickets:
                        SellTickets();
                        break;

                    case ApplicationState.CreateNewTrain:
                        CreateNewTrain();
                        break;

                    case ApplicationState.ExitProgram:
                        ExitProgram();
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-- выберите один из пунктов --------------");
            Console.WriteLine("  1 - Добавить поезд");
            Console.WriteLine("  0 - Выход из программы");
            Console.WriteLine();

            string input = Console.ReadLine();

            if (input == "1")
            {
                _currentState = ApplicationState.InitializeNewTrain;
            }
            else if (input == "0")
            {
                _currentState = ApplicationState.ExitProgram;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Программа завершена.");
            }
        }

        private void InitializeNewTrain() 
        {
            Console.WriteLine();
            Console.WriteLine("Меню создания нового поезда:");
            Console.WriteLine();
            Console.WriteLine($"Будет создан поезд с номером {_dispatcher.NewTrainNumber}");
        }

        private void EnterDestinationTown()
        {

        }

        private void EnterArrivalTown()
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

        private void ExitProgram()
        {
            _isWorking = false;
            Console.WriteLine("До скорых встреч!..");
        }
    }


    class Dispatcher
    {
        private readonly List<Train> _trains = new List<Train>();
        public IReadOnlyList<Train> Trains => _trains;


        public int NewTrainNumber { get; private set; } = 1;
        private Train _creatingTrain = null;

        public Dispatcher()
        {
            _trains.Add(new Train(NewTrainNumber++, "Москва", "Барнаул", 250, VanType.SecondClass));
            _trains.Add(new Train(NewTrainNumber++, "Ленинград", "Сталинград", 250, VanType.Сompartment));
            _trains.Add(new Train(NewTrainNumber++, "Каспийск", "Шерегеш", 250, VanType.Siting));
        }

        public void InitializeNewTrain()
        {
            _creatingTrain = new Train(NewTrainNumber++);
        }

        public void SetNewTrainArrivalTown()
        {

        }

        public void SetNewTrainDestinationTown()
        {

        }

        private bool CheckTownNameValidity()
        {

        }

        public bool TryCreateNewTrain(out string message)
        {
            return true;
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

        // TODO !!! валидацию из поезда убрать !!!!
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

    public abstract class Van
    {
        //public const int СompartmentSeatsAmmount = 36;
        //public const int SecondClassSeatsAmmount = 50;
        //public const int SitingSeatsAmmount = 70;

        public string VanTypeTitle { get; private set; }
        public int TotalSeats { get; private set; }

        protected Van(int seatCount, string wagonType)
        {
            TotalSeats = seatCount;
            VanTypeTitle = wagonType;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Тип вагона: {VanTypeTitle}, Количество мест: {TotalSeats}");
        
            /*
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
            */

        }
    }
}
