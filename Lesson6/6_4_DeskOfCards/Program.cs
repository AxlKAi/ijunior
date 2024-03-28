using System;
using System.Collections.Generic;

namespace _6_4_DeckOfCards
{
    public enum СardSuit
    {
        Hearts, Spades, Diamonds, Clubs
    }

    public enum CardValue
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
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
        private Table table = new Table();

        public void Run()
        {
            bool isMainLoopActive = true;

            ShowMenu();

            while (isMainLoopActive)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        table.GiveCardToPlayer(1);
                        break;

                    case ConsoleKey.DownArrow:
                        table.GiveCardToPlayer(2);
                        break;

                    case ConsoleKey.LeftArrow:
                        table.GiveCardToPlayer(3);
                        break;

                    case ConsoleKey.RightArrow:
                        table.GiveCardToPlayer(4);
                        break;

                    case ConsoleKey.Spacebar:
                        ShowAllPlayerCards();
                        break;

                    case ConsoleKey.Backspace:
                        NewGame();
                        break;

                    case ConsoleKey.Escape:
                        isMainLoopActive = false;
                        break;
                }
            }

            Console.WriteLine("До свиданья...");
            Console.ReadKey();
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Стрелка ^ < > вверх, вниз, лево, право -  взять карту из колоды соответствующему игроку.");
            Console.WriteLine("Пробел - показать карты игроков;   Backspace - Начать игру заново; Esc - выход из программы.");
        }

        public void ShowAllPlayerCards()
        {
            ShowMenu();
            table.ShowAllPlayersCards();
        }

        public void NewGame()
        {
            table.NewRound();
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

        public void ShowCard()
        {
            Console.WriteLine($"card: {Suit} {Value}");
        }
    }

    public class CardDeck
    {
        private List<Card> _cards = new List<Card>();

        public CardDeck()
        {
            FillTheDeck();
        }

        public bool TryTakeCard(out Card card)
        {
            if (_cards.Count <= 0)
            {
                Console.WriteLine("Не осталось карт в колоде.");
                card = null;
                return false;
            }

            Random random = new Random();
            int cardNumber = random.Next(0, _cards.Count);
            Card randomCard = _cards[cardNumber];

            _cards.RemoveAt(cardNumber);
            card = randomCard;
            return true;
        }

        public void Renew()
        {
            _cards = new List<Card>();
            FillTheDeck();
        }

        private void FillTheDeck()
        {
            var suits = Enum.GetValues(typeof(СardSuit));
            var values = Enum.GetValues(typeof(CardValue));

            foreach (var suit in suits)
                foreach (var value in values)
                    _cards.Add(new Card((СardSuit)suit, (CardValue)value));
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
            card.ShowCard();
        }

        public void ShowCards()
        {
            Console.WriteLine($"у игрока {Name} на руках {_cards.Count} карт.");

            foreach (var card in _cards)
                card.ShowCard();

            Console.WriteLine();
        }

        public void EmptyCards()
        {
            _cards = new List<Card>();
        }
    }

    public class Table
    {
        private CardDeck _cardDeck;
        private List<Player> _players;

        public Table()
        {
            CardDeck cardDeck = new CardDeck();
            _cardDeck = cardDeck;

            _players = new List<Player>() 
            {
                new Player("Дима"),
                new Player("Костя"),
                new Player("Петр"),
                new Player("Ян") 
            };
        }

        public void GiveCardToPlayer(int playerNumber)
        {
            if (playerNumber <= _players.Count)
            {
                Card card;

                if (_cardDeck.TryTakeCard(out card))
                {
                    _players[playerNumber-1].AddCard(card);
                }
                else
                {
                    Console.WriteLine("В колоде кончились карты.");
                }
            }
        }

        public void NewRound()
        {
            Console.WriteLine("Новый раунд! Крупье забирает все карты у игроков.");

            foreach (Player player in _players)
                player.EmptyCards();

            _cardDeck.Renew();

            Console.WriteLine("Нажмите клавишу для продолжения ....");
            Console.ReadKey();
        }

        public void ShowAllPlayersCards()
        {
            foreach (var player in _players)
                player.ShowCards();
        }
    }
}
