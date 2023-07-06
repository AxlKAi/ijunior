using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub
{
    class Program
    {
        static void Main(string[] args)
        {
            int minScoolBoyDesiredMinutes = 10;
            int maxScoolBoyDesiredMinutes = 25;
            int minScoolBoyMoney = 300;
            int maxScoolBoyMoney = 1000;
            int scoolBoysQueueLength = 25;

            Random random = new Random();

            int computersCount = 10;
            ComputerClub computerClub = new ComputerClub(computersCount);

            for (int i = 0; i < scoolBoysQueueLength; i++)
            {
                computerClub.AddScoolBoyToQueue(
                    new ScoolBoy(
                        random.Next(minScoolBoyMoney, maxScoolBoyMoney),
                        random.Next(minScoolBoyDesiredMinutes, maxScoolBoyDesiredMinutes)));
            }

            Console.WriteLine("Очередь учеников:");
            computerClub.ShowScoolBoysQueue();
            computerClub.Work();
        }

        class ComputerClub
        {
            private List<Computer> _computers = new List<Computer>();
            private Queue<ScoolBoy> _scoolboys = new Queue<ScoolBoy>();
            private int _money = 0;

            public ComputerClub(int computersCount)
            {
                Random random = new Random();
                int minPriceForMinute = 3;
                int maxPriceForMinute = 15;

                for (int i = 0; i < computersCount; i++)
                {
                    _computers.Add(new Computer(random.Next(minPriceForMinute, maxPriceForMinute)));
                }
            }

            public void Work()
            {
                while (_scoolboys.Count > 0)
                {
                    Console.WriteLine($"В кассе клуба {_money} денег.");
                    ShowComputers();
                    ScoolBoy scoolBoy = _scoolboys.Dequeue();
                    Console.WriteLine($"Ученик хочет поиграть {scoolBoy.DesireMinutes} минут.");
                    Console.WriteLine("Введите номер компьютера:");

                    int computerNumber = Convert.ToInt32(Console.ReadLine());
                    Computer computer = _computers[computerNumber];

                    if (computer.IsBusy)
                    {
                        Console.WriteLine($"Компьютер занят еще {computer.MinutesForFree} минут. Ученик ушел из клуба.");
                    }
                    else
                    {
                        if (scoolBoy.IsEnoughtMoney(computer))
                        {
                            int moneyToAdd = scoolBoy.PayComputer(computer);
                            Console.WriteLine($"Ученик оплатил {moneyToAdd} денег.");
                            _money += moneyToAdd;
                        }
                        else
                        {
                            Console.WriteLine("У ученика не достаточно денег. Он ушел из клуба.");
                        }
                    }

                    foreach (Computer comp in _computers)
                    {
                        comp.MinusMinute();
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine("Очередь учеников пуста, компьютерный клуб закончил работу.");
            }

            public void ShowComputers()
            {
                for (int i = 0; i < _computers.Count; i++)
                {
                    Console.Write($"{i} компьютер, цена за минуту {_computers[i].PriceForMinute}. ");
                    if (_computers[i].IsBusy)
                    {
                        Console.WriteLine($"Занят еще {_computers[i].MinutesForFree}");
                    }
                    else
                    {
                        Console.WriteLine($"Свободен.");
                    }
                }
            }

            public void ShowScoolBoysQueue()
            {
                foreach (ScoolBoy scoolBoy in _scoolboys)
                    Console.WriteLine($"Ученик хочет {scoolBoy.DesireMinutes} минут.");
            }

            public void AddScoolBoyToQueue(ScoolBoy scoolBoy)
            {
                _scoolboys.Enqueue(scoolBoy);
            }
        }

        class Computer
        {
            public ScoolBoy ScoolBoy { get; private set; } = null;

            public int PriceForMinute { get; private set; }

            public int MinutesForFree { get; private set; } = 0;

            public bool IsBusy { get { return MinutesForFree > 0; } }

            public Computer(int priceForMinute)
            {
                PriceForMinute = priceForMinute;
            }

            public void TakePlace(ScoolBoy scoolBoy)
            {
                MinutesForFree = scoolBoy.DesireMinutes;
                ScoolBoy = scoolBoy;
            }

            public void MinusMinute()
            {
                MinutesForFree--;

                if (MinutesForFree <= 0)
                {
                    FreeComputer();
                }
            }

            public void FreeComputer()
            {
                ScoolBoy = null;
                MinutesForFree = 0;
            }
        }

        class ScoolBoy
        {
            private int _money;
            public int DesireMinutes { get; private set; }

            public ScoolBoy(int money, int desireMinute)
            {
                _money = money;
                DesireMinutes = desireMinute;
            }

            public bool IsEnoughtMoney(Computer computer)
            {
                return _money >= computer.PriceForMinute * DesireMinutes;
            }

            public int PayComputer(Computer computer)
            {
                int moneyToPay = computer.PriceForMinute * DesireMinutes;
                if (_money >= moneyToPay)
                {
                    _money -= moneyToPay;
                    computer.TakePlace(this);
                    return moneyToPay;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
