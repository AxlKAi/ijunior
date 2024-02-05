using System;
using System.Collections.Generic;

namespace consoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.WorkMainMenu();
        }
    }

    class Customizer
    {
        private int _windowSizeX;
        private int _windowSizeY;

        public Customizer(int windowSizeX, int windowSizeY)
        {
            _windowSizeX = windowSizeX;
            _windowSizeY = windowSizeY;
        }

        public void CustomizeConsole(ConsoleColor colorText = ConsoleColor.Black, ConsoleColor consoleColor = ConsoleColor.Gray)
        {
            Console.ForegroundColor = colorText;
            Console.BackgroundColor = consoleColor;
            Console.SetWindowSize(_windowSizeX + _windowSizeY, _windowSizeY);
            Console.Clear();
        }

        public void AverageTextPosition(string text, int interfacePositionY = 0)
        {
            int delimiter = 2;
            int interfacePositionX = _windowSizeX - text.Length / delimiter;

            Console.SetCursorPosition(interfacePositionX, interfacePositionY);
        }

        public void AverageBigTextPosition(int interfacePositionY = 0)
        {
            int interfacePositionX = 1;

            Console.SetCursorPosition(interfacePositionX, interfacePositionY);
        }
    }

    class UserUntils
    {
        static private Random _random = new Random();

        static public int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }

    class Game
    {
        private List<Ship> _shipsKit;

        private Customizer _customizer = new Customizer(55, 55);
        private MenuMein _menuMein = new MenuMein();
        private MenuInfo _menuShipInfo = new MenuInfo();
        private MenuShipSelection _menuShipSelection = new MenuShipSelection();

        private Ship _ship1;
        private Ship _ship2;

        public Game()
        {
            _shipsKit = new List<Ship> { new RoyalShip(), new PiratesShip(), new PrivateerShip(), new VikingShip(), new DeadShip() };
        }

        public void WorkMainMenu()
        {
            const int ActionExit = 0;
            const int ActionStartGame = 1;
            const int ActionShipInfo = 2;

            int actionNumber;

            bool isGameRun = true;

            _customizer.CustomizeConsole();
            _menuMein.AddButtons();
            _menuShipSelection.AddButtons();
            _menuShipInfo.AddButtons();

            while (isGameRun)
            {
                actionNumber = _menuMein.InputPlayerCommands();

                switch (actionNumber)
                {
                    case ActionExit:
                        isGameRun = false;
                        break;

                    case ActionStartGame:
                        WorkShipSelectionMenu();
                        break;

                    case ActionShipInfo:
                        WorkAboutShipMenu();
                        break;
                }
            }
        }

        private Ship ChooseShip(string selectedInfo)
        {
            int number = _menuShipSelection.InputPlayerCommands(0, selectedInfo);

            if (number > 0 & number <= _shipsKit.Count)
            {
                return _shipsKit[number - 1].Clone();
            }

            return _shipsKit[0].Clone();
        }

        private void WorkShipSelectionMenu()
        {
            string selectedInfo = "Выберите первый корабль";

            _customizer.CustomizeConsole();

            _ship1 = ChooseShip(selectedInfo);

            selectedInfo = "Выберете второй корабль";

            _ship2 = ChooseShip(selectedInfo);

            Battle battle = new Battle(_ship1, _ship2);

            battle.FightShips();
        }

        private void WorkAboutShipMenu()
        {
            const int ActionBack = 0;

            int actionNumber;

            bool isProgramRun = true;

            _customizer.CustomizeConsole();

            while (isProgramRun)
            {
                actionNumber = _menuShipInfo.InputPlayerCommands(0, "Информация о кораблях", "", "", _shipsKit);

                if (actionNumber == ActionBack)
                {
                    isProgramRun = false;
                }
            }
        }
    }

    class Interface
    {
        protected Customizer Customizer = new Customizer(55, 55);

        protected List<Button> Buttons = new List<Button>();

        public int InputPlayerCommands(int activeButtonIndex = 1, string mainText = "Naval battles", string text1 = "", string text2 = "", List<Ship> ships = null)
        {
            const ConsoleKey KeyActiveButtonUp = ConsoleKey.UpArrow;
            const ConsoleKey KeyActiveButtonDown = ConsoleKey.DownArrow;
            const ConsoleKey KeyChoiceButton = ConsoleKey.Enter;

            int buttonPositionY = 0;

            bool isMenuRun = true;

            ConsoleKeyInfo key;

            Console.Clear();

            Buttons[activeButtonIndex].Enable();

            Render(buttonPositionY);

            buttonPositionY = 0;

            while (isMenuRun)
            {
                Customizer.AverageTextPosition(mainText);
                Console.WriteLine(mainText);

                Console.WriteLine(text1);

                Console.WriteLine(text2);

                Render(buttonPositionY);

                ShowShipInfo(ships);

                buttonPositionY = 0;

                Buttons[activeButtonIndex].Disable();

                key = Console.ReadKey();

                switch (key.Key)
                {
                    case KeyActiveButtonUp:
                        activeButtonIndex--;
                        break;

                    case KeyActiveButtonDown:
                        activeButtonIndex++;
                        break;

                    case KeyChoiceButton:
                        isMenuRun = false;
                        break;
                }

                if (activeButtonIndex > Buttons.Count - 1)
                {
                    activeButtonIndex = 0;
                }

                if (activeButtonIndex < 0)
                {
                    activeButtonIndex = Buttons.Count - 1;
                }

                Buttons[activeButtonIndex].Enable();
            }

            Buttons[activeButtonIndex].Disable();

            return activeButtonIndex;
        }

        private void Render(int buttonPositionY)
        {
            foreach (Button button in Buttons)
            {
                buttonPositionY += 5;

                Customizer.AverageTextPosition(button.Text, buttonPositionY);
                button.Render();
            }
        }

        private void ShowShipInfo(List<Ship> ships)
        {
            int buttonPositionY = 10;

            Console.ForegroundColor = ConsoleColor.Black;

            if (ships == null)
            {
                return;
            }

            foreach (Ship ship in ships)
            {
                buttonPositionY += 5;

                Customizer.AverageBigTextPosition(buttonPositionY);

                Console.WriteLine(ship.Info);
            }
        }
    }

    class MenuInterface : Interface
    {
        protected string[] ButtonsInfo;

        public void AddButtons()
        {
            if (Buttons.Count > 0)
            {
                return;
            }

            foreach (string info in ButtonsInfo)
            {
                Buttons.Add(new Button(info, ConsoleColor.Black, ConsoleColor.Blue));
            }
        }
    }

    class MenuMein : MenuInterface
    {
        public MenuMein()
        {
            ButtonsInfo = new string[] { "Выход", "Играть", "О кораблях" };
        }
    }

    class MenuShipSelection : MenuInterface
    {
        public MenuShipSelection()
        {
            ButtonsInfo = new string[] { "Назад", "Корабль королевского флота", "Корабль пиратов", "Корабль каперов", "Корабль викингов", "Корабль мертвецов" };
        }
    }

    class MenuInfo : MenuInterface
    {
        public MenuInfo()
        {
            ButtonsInfo = new string[] { "Назад" };
        }
    }

    class MenuShipControl : MenuInterface
    {
        public MenuShipControl(string[] buttonsInfo)
        {
            ButtonsInfo = buttonsInfo;
        }
    }

    class Button
    {
        private ConsoleColor _defaultColor;
        private ConsoleColor _activeColor;
        private ConsoleColor _buttonColor;

        private bool _isActive;

        public Button(string text, ConsoleColor defaultColor, ConsoleColor activeColor)
        {
            Text = text;
            _defaultColor = defaultColor;
            _activeColor = activeColor;
            _buttonColor = activeColor;
        }

        public string Text { get; private set; }

        public void Render()
        {
            if (_isActive == true)
            {
                _buttonColor = _activeColor;
            }
            else
            {
                _buttonColor = _defaultColor;
            }

            Console.ForegroundColor = _buttonColor;
            Console.WriteLine(Text);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void Disable()
        {
            _isActive = false;
        }

        public void Enable()
        {
            _isActive = true;
        }
    }

    class Ship
    {
        protected UserUntils UserUntils = new UserUntils();
        protected MenuShipControl MenuShipControl;

        protected int NumberCrewMax;
        protected int HullStrengthMax;
        protected int NumberGuns;
        protected int DamageGuns;
        protected int DamageBoarding;

        public bool IsAlive => HullStrength > 0 & NumberCrew > 0;

        public Ship(int numberCrew, int maxNumberCrew, int numberGuns, int damageGuns, int damageBoarding, int hullStrength, int hullStrengthMax)
        {
            NumberCrew = numberCrew;
            NumberGuns = numberGuns;
            DamageGuns = damageGuns;
            DamageBoarding = damageBoarding;
            HullStrength = hullStrength;
            HullStrengthMax = hullStrengthMax;
            NumberCrewMax = maxNumberCrew;
        }

        public int HullStrength { get; protected set; }

        public string Info { get; protected set; }

        public string VictoryPhrase { get; protected set; }

        public int NumberCrew { get; protected set; }

        public virtual Ship Clone()
        {
            return new Ship(NumberCrew, NumberCrewMax, NumberGuns, DamageGuns, DamageBoarding, HullStrength, HullStrengthMax);
        }

        public void Attack(Ship enemy)
        {
            const int CommandShot = 0;
            const int CommandSpecialShot = 1;

            int hullDamage;
            int damageByCrew;

            MenuShipControl.AddButtons();

            if (IsAlive == false)
            {
                return;
            }

            int attackNumber = MenuShipControl.InputPlayerCommands(0, "Корабль ждёт приказов", GetIndicators(), enemy.GetIndicators());

            switch (attackNumber)
            {
                case CommandShot:
                    enemy.AcceptDamage(Shoot(enemy.HullStrength, out enemy.DamageBoarding));
                    break;

                case CommandSpecialShot:
                    damageByCrew = ShotSpecial(NumberCrew, HullStrength, out hullDamage);
                    enemy.AcceptDamage(hullDamage, damageByCrew);
                    break;
            }
        }

        public int Shoot(int hullStrength, out int damageByCrew)
        {
            int multiplier = 2;
            int death = 4;

            int damageByHull = DamageGuns - hullStrength / multiplier;

            if (damageByHull < 0)
            {
                damageByHull = 0;
            }

            damageByCrew = UserUntils.GenerateRandomNumber(0, death);

            return damageByHull;
        }

        public void AcceptDamage(int damageByHull, int damageByCrew = 0)
        {
            HullStrength -= damageByHull;
            NumberCrew -= damageByCrew;
        }

        public virtual List<Button> AddAttackButtons(List<Button> buttons)
        {
            return null;
        }

        public virtual int ShotSpecial(int numberCrew, int hullStrength, out int hullDamage)
        {
            hullDamage = 0;
            return 0;
        }

        public void RestoreDefaultValues()
        {
            NumberCrew = NumberCrewMax;
            HullStrength = HullStrengthMax;
        }

        public string GetIndicators()
        {
            return $"Прочность корпуса: {HullStrength}/{HullStrengthMax}, Экипаж: {NumberCrew}/{NumberCrewMax}";
        }
    }

    class RoyalShip : Ship
    {
        private int _discipline;

        public RoyalShip(int numberCrew = 450, int maxNumberCrew = 450, int numberGuns = 52, int damageGuns = 1000, int damageBoarding = 2, int hullStrength = 1500, int hullStrengthMax = 1500, int discipline = 10) :
            base(numberCrew, maxNumberCrew, numberGuns, damageGuns, damageBoarding, hullStrength, hullStrengthMax)
        {
            _discipline = discipline;
            Info = $"Корабль королевского флота - фрегат \"Паладин\" имеет на борту {numberGuns} орудия и {maxNumberCrew} человек экипажа.\nМатросы военных кораблей славятся своей дисциплиной.";
            VictoryPhrase = "Слава королевскому флоту!";

            MenuShipControl = new MenuShipControl(new string[] { "Огонь", "На абордаж!" });
        }

        public override Ship Clone()
        {
            return new RoyalShip();
        }

        public override int ShotSpecial(int numberCrew, int hullStrength, out int hullDamage)
        {
            int damageCrew = UserUntils.GenerateRandomNumber(0, NumberCrew);
            int damageCrewOpponent = UserUntils.GenerateRandomNumber(0, numberCrew - damageCrew);

            NumberCrew -= damageCrewOpponent - _discipline;

            hullDamage = 0;

            return damageCrew;
        }
    }

    class PiratesShip : Ship
    {
        private int _rum;

        public PiratesShip(int numberCrew = 250, int maxNumberCrew = 250, int numberGuns = 46, int damageGuns = 1000, int damageBoarding = 3, int hullStrength = 1155, int hullStrengthMax = 1155, int rum = 5) :
            base(numberCrew, maxNumberCrew, numberGuns, damageGuns, damageBoarding, hullStrength, hullStrengthMax)
        {
            _rum = rum;
            Info = $"Корабль пиратов - галеон \"Гадюка\" имеет на борту {numberGuns} орудий и {maxNumberCrew} человек экипажа.\nОснащён скорострельными пушками";
            VictoryPhrase = "Аррр!";

            MenuShipControl = new MenuShipControl(new string[] { "Огонь", "Огонь из скорострельных орудий!" });
        }

        public override Ship Clone()
        {
            return new PiratesShip();
        }

        public override int ShotSpecial(int numberCrew, int hullStrength, out int hullDamage)
        {
            int damageHull = 0;
            int multiplier = 2;
            int delimiter = 2;
            int numberShots = 3;

            for (int i = 0; i < numberShots; i++)
            {
                damageHull += Shoot(hullStrength, out numberCrew) + _rum * multiplier / delimiter;
            }

            hullDamage = damageHull;

            return numberCrew;
        }
    }

    class DeadShip : Ship
    {
        private int _decomposition;

        public DeadShip(int numberCrew = 144, int maxNumberCrew = 144, int numberGuns = 52, int damageGuns = 2000, int damageBoarding = 1, int hullStrength = 1656, int hullStrengthMax = 1656, int rum = 5) :
            base(numberCrew, maxNumberCrew, numberGuns, damageGuns, damageBoarding, hullStrength, hullStrengthMax)
        {
            _decomposition = rum;
            Info = $"Корабль мертвецов - галеон \"Силуэт\" имеет на борту {numberGuns} орудий и {maxNumberCrew} членов экипажа.\nЕдинственное что вы увидите, это вспышку от зажигания пороха";
            VictoryPhrase = "Мертвые не зреют, не гниют Не умеют, не живут...";

            MenuShipControl = new MenuShipControl(new string[] { "Огонь", "Огонь картечью!" });
        }

        public override Ship Clone()
        {
            return new DeadShip();
        }

        public override int ShotSpecial(int numberCrew, int hullStrength, out int hullDamage)
        {
            hullDamage = 0;

            int numberExplosion = 2;
            int explosion = UserUntils.GenerateRandomNumber(0, numberExplosion);

            if (explosion == 1)
            {
                NumberCrew -= UserUntils.GenerateRandomNumber(0, NumberCrewMax) + _decomposition;
            }
            else
            {
                numberCrew = UserUntils.GenerateRandomNumber(0, numberCrew) - _decomposition;
            }

            return numberCrew;
        }
    }

    class VikingShip : Ship
    {
        private int _spirit;

        public VikingShip(int numberCrew = 100, int maxNumberCrew = 100, int numberGuns = 5, int damageGuns = 5, int damageBoarding = 10, int hullStrength = 705, int hullStrengthMax = 705, int rum = 10) :
            base(numberCrew, maxNumberCrew, numberGuns, damageGuns, damageBoarding, hullStrength, hullStrengthMax)
        {
            _spirit = rum;
            Info = $"Драккар викингов имеет на борту слабое вооружение и {numberCrew} человек экипажа.\nВ битве против современных кораблей служит лёгкой мишенью";
            VictoryPhrase = "Удача на стороне викингов! Что удивительно...";

            MenuShipControl = new MenuShipControl(new string[] { "Огонь", "Произвести ритуал" });
        }

        public override Ship Clone()
        {
            return new VikingShip();
        }

        public override int ShotSpecial(int numberCrew, int hullStrength, out int hullDamage)
        {
            int delimiter = 2;
            int spiritEnergy = 15;

            hullDamage = 0;

            _spirit += spiritEnergy;

            NumberCrew += _spirit;

            if (NumberCrew > NumberCrewMax)
            {
                NumberCrew = NumberCrewMax;
            }

            HullStrength += _spirit / delimiter;

            if (HullStrength > HullStrengthMax)
            {
                HullStrength = HullStrengthMax;
            }

            return 0;
        }
    }

    class PrivateerShip : Ship
    {
        public PrivateerShip(int numberCrew = 200, int minNumberCrew = 200, int numberGuns = 58, int damageGuns = 1150, int damageBoarding = 4, int hullStrength = 1200, int hullStrengthMax = 1200) :
            base(numberCrew, minNumberCrew, numberGuns, damageGuns, damageBoarding, hullStrength, hullStrengthMax)
        {
            Info = "Корабль каперов - мановар \"Морской дьявол\" имеет на борту 58 орудий и 200 человек экипажа.\nВ трюме имеется запас бомб.";
            VictoryPhrase = "Сегодня у каперов богатая добыча!";

            MenuShipControl = new MenuShipControl(new string[] { "Огонь", "Огонь бомбами!" });
        }

        public override Ship Clone()
        {
            return new PrivateerShip();
        }

        public override int ShotSpecial(int numberCrew, int hullStrength, out int hullDamage)
        {
            int death = 50;
            int delimiter = 2;

            hullDamage = DamageGuns / delimiter;

            if (hullDamage < 0)
            {
                hullDamage = 0;
            }

            numberCrew = UserUntils.GenerateRandomNumber(0, death);

            return numberCrew;
        }

    }

    class Battle
    {
        private MenuInfo _menuOverBattle = new MenuInfo();
        private Ship _ship1;
        private Ship _ship2;

        public Battle(Ship ship1, Ship ship2)
        {
            _ship1 = ship1;
            _ship2 = ship2;
        }

        public void FightShips()
        {
            while (_ship1.IsAlive && _ship2.IsAlive)
            {
                _ship1.Attack(_ship2);
                _ship2.Attack(_ship1);
            }

            OverGame();
        }

        private void OverGame()
        {
            string victoryPhrase;

            _menuOverBattle.AddButtons();

            if (_ship1.IsAlive == true)
            {
                victoryPhrase = _ship1.VictoryPhrase;
            }
            else
            {
                victoryPhrase = _ship2.VictoryPhrase;
            }

            _menuOverBattle.InputPlayerCommands(0, victoryPhrase, "", "", new List<Ship>() { _ship1, _ship2 });
            RestoreDefaultValues();
        }

        private void RestoreDefaultValues()
        {
            _ship1.RestoreDefaultValues();
            _ship2.RestoreDefaultValues();
        }
    }
}