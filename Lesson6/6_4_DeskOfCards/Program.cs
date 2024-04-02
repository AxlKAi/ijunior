using System;
using System.Collections.Generic;

namespace _6_4_DeckOfCards
{
    public enum СardSuit
    {
        Hearts, 
        Spades, 
        Diamonds, 
        Clubs
    }

    public enum CardValue
    {
        Two, 
        Three, 
        Four, Five, 
        Six, 
        Seven, 
        Eight, 
        Nine, 
        Ten, 
        Jack, 
        Queen, 
        King, 
        Ace
    }

    class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();

            application.Run();
        }
    }

    public class Application
    {
        const ConsoleKey ShowAllPlayersCardKey = ConsoleKey.Spacebar;
        const ConsoleKey NewGameKey = ConsoleKey.Backspace;
        const ConsoleKey QuitKey = ConsoleKey.Escape;

        const ConsoleKey PlayerOneKey = ConsoleKey.UpArrow;
        const ConsoleKey PlayerTwoKey = ConsoleKey.DownArrow;
        const ConsoleKey PlayerThreeKey = ConsoleKey.LeftArrow;
        const ConsoleKey PlayerFourKey = ConsoleKey.RightArrow;

        private Table _table = new Table();

        public void Run()
        {
            bool isMainLoopActive = true;

            var player1 = ConsoleKey.UpArrow;

            _table.AddPlayer("Дима", PlayerOneKey);
            _table.AddPlayer("Костя", PlayerTwoKey);
            _table.AddPlayer("Рита", PlayerThreeKey);
            _table.AddPlayer("Вася", PlayerFourKey);

            ShowMenu();

            while (isMainLoopActive)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ShowAllPlayersCardKey:
                        ShowAllPlayerCards();
                        break;

                    case NewGameKey:
                        StartNewGame();
                        break;

                    case QuitKey:
                        isMainLoopActive = false;
                        break;

                    default:
                        _table.PlayerKeyEvent(key.Key);
                        break;
                }
            }

            Console.WriteLine("До свиданья...");
            Console.ReadKey();
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Стрелка ^ < > вверх, вниз, лево, право -  взять карту из колоды соответствующему игроку.");
            Console.WriteLine("Пробел - показать карты игроков;   Backspace - Начать игру заново; Esc - выход из программы.");
        }

        private void ShowAllPlayerCards()
        {
            ShowMenu();
            _table.ShowAllPlayersCards();
        }

        private void StartNewGame()
        {
            _table.StartNewRound();
            ShowMenu();
        }
    }

    public class Card
    {
        public Card(СardSuit suit, CardValue value)
        {
            Value = value;
            Suit = suit;
        }

        public CardValue Value { get; private set; }

        public СardSuit Suit { get; private set; }

        public void Show()
        {
            Console.WriteLine($"card: {Suit} {Value}");
        }
    }

    public class CardDeck
    {
        private List<Card> _cards = new List<Card>();

        public CardDeck()
        {
            Fill();
            Shuffle();
        }

        public bool TryGiveCard(out Card card)
        {
            if (_cards.Count <= 0)
            {
                Console.WriteLine("Не осталось карт в колоде.");
                card = null;
                return false;
            }

            card = _cards[0];
            _cards.RemoveAt(0);

            return true;
        }

        public void Renew()
        {
            _cards = new List<Card>();
            Fill();
            Shuffle();
        }

        private void Fill()
        {
            var suits = Enum.GetValues(typeof(СardSuit));
            var values = Enum.GetValues(typeof(CardValue));

            foreach (var suit in suits)
                foreach (var value in values)
                    _cards.Add(new Card((СardSuit)suit, (CardValue)value));
        }

        private void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i >= 1; i--)
            {
                int randomIndex = random.Next(i + 1);
                var tempCard = _cards[randomIndex];
                _cards[randomIndex] = _cards[i];
                _cards[i] = tempCard;
            }
        }
    }

    public class Player
    {
        private List<Card> _cards = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public string Name {get; private set;}

        public void AddCard(Card card)
        {
            _cards.Add(card);
            Console.WriteLine($"У игрока {Name} {_cards.Count} карт. ");
            Console.Write($"Он вытянул ");
            card.Show();
        }

        public void ShowCards()
        {
            Console.WriteLine($"у игрока {Name} на руках {_cards.Count} карт.");

            foreach (var card in _cards)
                card.Show();

            Console.WriteLine();
        }

        public void ClearCards()
        {
            _cards = new List<Card>();
        }
    }

    public class Table
    {
        private CardDeck _cardDeck;        
        private Dictionary<ConsoleKey, Player> _players = new Dictionary<ConsoleKey, Player>();

        public Table()
        {
            CardDeck cardDeck = new CardDeck();
            _cardDeck = cardDeck;
        }

        public void AddPlayer(string name, ConsoleKey playerKey)
        {
            _players.Add(playerKey, new Player(name));
        }

        public void PlayerKeyEvent(ConsoleKey pressedKey)
        {
            Player player;
            Card card;

            if (_players.TryGetValue(pressedKey, out player))
            {
                if (_cardDeck.TryGiveCard(out card))
                {
                    player.AddCard(card);
                }
                else
                {
                    Console.WriteLine("В колоде кончились карты.");
                }
            }
        }

        public void StartNewRound()
        {
            Console.WriteLine("Новый раунд! Крупье забирает все карты у игроков.");

            foreach (KeyValuePair<ConsoleKey, Player> player in _players)
                player.Value.ClearCards();

            _cardDeck.Renew();

            Console.WriteLine("Нажмите клавишу для продолжения ....");
            Console.ReadKey();
        }

        public void ShowAllPlayersCards()
        {
            foreach (KeyValuePair<ConsoleKey, Player> player in _players)
                player.Value.ShowCards();
        }
    }
}
