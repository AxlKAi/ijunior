using System;
using System.Collections.Generic;

namespace _6_4_DeskOfCards
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
        public void Run()
        {
            bool isMainLoopActive = true;

            CardDesc cardDesk = new CardDesc();
            Player player = new Player();

            ShowMenu();

            while (isMainLoopActive)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        cardDesk.MoveRandomCardToPlayer(player);
                        break;

                    case ConsoleKey.Spacebar:
                        ShowMenu();
                        player.ShowCards();
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
            Console.WriteLine("Стрелка ^ вверх -  взять карту из колоды;   Пробел - показать карты игрока;");
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

    public class CardDesc
    {
        private List<Card> _cards = new List<Card>();

        public CardDesc()
        {
            var suits = Enum.GetValues(typeof(СardSuit));
            var values = Enum.GetValues(typeof(CardValue));

            foreach (var suit in suits)
                foreach (var value in values)
                    _cards.Add(new Card((СardSuit)suit, (CardValue)value));
        }

        public void MoveRandomCardToPlayer(Player player)
        {
            if (_cards.Count <= 0)
            {
                Console.WriteLine("Не осталось карт в колоде.");
                return;
            }

            Random random = new Random();
            int cardNumber = random.Next(0, _cards.Count);
            Card randomCard = _cards[cardNumber];

            _cards.RemoveAt(cardNumber);
            player.AddCard(randomCard);
        }
    }

    public class Player
    {
        private List<Card> _cards = new List<Card>();

        public void AddCard(Card card)
        {
            _cards.Add(card);
            Console.WriteLine($"У игрока {_cards.Count} карт. ");
            Console.Write($"Он вытянул ");
            card.ShowCard();
        }

        public void ShowCards()
        {
            Console.WriteLine($"у игрока {_cards.Count} карт");

            foreach (var card in _cards)
                card.ShowCard();
        }
    }
}
