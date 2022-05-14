using System;
using System.Collections.Generic;

namespace CardDeckProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardDeck cardDeck = new CardDeck();
            Player player = new Player();
            cardDeck.PlayingGame(player);
        }
    }

    enum CardSuit
    {
        Spades,
        Heart,
        Diamonds,
        Clubs
    }

    enum CardRank
    {
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

    class CardDeck
    {
        private int _cardDeckMaxCount = 36;
        private List<Card> _cardDeck = new List<Card>();
        private List<CardSuit> _cardSuit = new List<CardSuit>
        {
            CardSuit.Spades,
            CardSuit.Heart,
            CardSuit.Diamonds,
            CardSuit.Clubs 
        };
        private List<CardRank> _cardRank = new List<CardRank>
        {
            CardRank.Six,
            CardRank.Seven,
            CardRank.Eight,
            CardRank.Nine,
            CardRank.Ten,
            CardRank.Jack,
            CardRank.Queen,
            CardRank.King,
            CardRank.Ace
        };

        public void Create()
        {
            if(_cardDeck.Count < _cardDeckMaxCount)
            {
                foreach (var suit in _cardSuit)
                {
                    foreach (var rank in _cardRank)
                    {
                        _cardDeck.Add(CreateCard(suit, rank));
                    }
                }
            }
            else
            {
                Console.WriteLine("Колода уже существует.");
            }
        }

        private Card CreateCard(CardSuit suit, CardRank rank)
        {
            Card card = new Card(suit, rank);
            return card;
        }

        public void Show()
        {
            int i = 0;
            foreach(var card in _cardDeck)
                Console.WriteLine($"{i++} { card.Suit } - { card.Rank}");
        }

        public void StopGame(Player player)
        {
            Console.WriteLine("Игра закончена.");
            player.ShowCards();
            Console.WriteLine("Нажмите любую клавишу для Новой игры.");
            Console.ReadKey();
            TakeAllCardsFrom(player);
        }

        public void Shuffle()
        {
            Console.Clear();
            Console.WriteLine("Колода перемешана.\n");

            Random randomIndex = new Random();

            for (int i = 0; i < _cardDeck.Count; i++)
            {
                int replacementIndex = randomIndex.Next(i + 1);
                Card card = _cardDeck[replacementIndex];
                _cardDeck.RemoveAt(replacementIndex);
                _cardDeck.Add(card);
            }
        }

        public void MoveCardTo(Player player)
        {
            if(_cardDeck.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Игрок взял одну карту.\n");

                Card card = GiveCard();
                player.TakeCard(card);
                DeleteCard();
            }
            else
            {
                Console.WriteLine("Вы забрали себе все карты из колоды. И зачем? >:/ ");
            }
        }

        public void TakeAllCardsFrom(Player player)
        {
            Console.Clear();
            Console.WriteLine("Все карты возвращены в колоду.\n");

            List<Card> playerCards = player.ReturnAllCards();

            foreach(var card in playerCards)
            {
                TakeCard(card);
            }
        }

        private Card GiveCard()
        {
            return _cardDeck[0];
        }

        private void DeleteCard()
        {
            _cardDeck.RemoveAt(0);
        }

        private void TakeCard(Card card)
        {
            _cardDeck.Add(card);
        }

        public void PlayingGame(Player player)
        {
            bool isGaming = true;
            string userAnyInput;
            int userInput = 0;
            Create();
            Shuffle();

            while (isGaming)
            {
                Console.WriteLine(
                    "Меню:\n" +
                    "1 - Взять карту из колоды\n" +
                    "2 - Достаточно карт!\n" +
                    "3 - Вернуть карты в колоду(сброс)\n" +
                    "4 - Перемешать колоду\n" +
                    "5 - Выход");

                userAnyInput = Console.ReadLine();

                if (CheckNumberInput(userAnyInput))
                    userInput = Convert.ToInt32(userAnyInput);

                switch (userInput)
                {
                    case 1:
                        MoveCardTo(player);
                        break;
                    case 2:
                        StopGame(player);
                        break;
                    case 3:
                        TakeAllCardsFrom(player);
                        break;
                    case 4:
                        Shuffle();
                        break;
                    case 5:
                        isGaming = false;
                        break;
                    default:
                        ShowDefaultMessage();
                        break;
                }
            }
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды не существует. Попробуйте снова.\n");
        }

        private bool CheckNumberInput(string userInput)
        {
            if (int.TryParse(userInput, out int number))
                return true;
            else
                return false;
        }
    }

    class Card
    {
        public CardSuit Suit { get; private set; }
        public CardRank Rank { get; private set; }

        public Card(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }

    class Player
    {
        private List<Card> _playerCards = new List<Card>();

        public void TakeCard(Card card)
        {
            _playerCards.Add(card);
        }

        public void ShowCards()
        {
            Console.Clear();
            if(_playerCards.Count > 0)
            {
                Console.WriteLine("У игрока на руках следующие карты:\n");

                foreach (var card in _playerCards)
                    Console.WriteLine($"{card.Suit} - {card.Rank}");
            }
            else
            {
                Console.WriteLine("Вы не взяли ни одной карты.");
            }
            Console.WriteLine();
        }

        public List<Card> ReturnAllCards()
        {
            List<Card> cardsToReturn = new List<Card>();
            cardsToReturn = _playerCards;
            _playerCards.Clear();
            return cardsToReturn;
        }
    }
}
