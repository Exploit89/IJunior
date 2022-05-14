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
            Croupier croupier = new Croupier();
            croupier.PlayGame(player, cardDeck);
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
        private List<Card> _cardDeck = new List<Card>();
        private List<CardSuit> _cardSuits = new List<CardSuit>();
        private List<CardRank> _cardRanks = new List<CardRank>();

        public CardDeck()
        {
            _cardSuits.Add(CardSuit.Spades);
            _cardSuits.Add(CardSuit.Heart);
            _cardSuits.Add(CardSuit.Diamonds);
            _cardSuits.Add(CardSuit.Clubs);

            _cardRanks.Add(CardRank.Six);
            _cardRanks.Add(CardRank.Seven);
            _cardRanks.Add(CardRank.Eight);
            _cardRanks.Add(CardRank.Nine);
            _cardRanks.Add(CardRank.Ten);
            _cardRanks.Add(CardRank.Jack);
            _cardRanks.Add(CardRank.Queen);
            _cardRanks.Add(CardRank.King);
            _cardRanks.Add(CardRank.Ace);

            foreach (var suit in _cardSuits)
            {
                foreach (var rank in _cardRanks)
                {
                    _cardDeck.Add(CreateCard(suit, rank));
                }
            }
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
            if (_cardDeck.Count != 0)
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

            foreach (var card in playerCards)
            {
                TakeCard(card);
            }
        }

        private Card CreateCard(CardSuit suit, CardRank rank)
        {
            Card card = new Card(suit, rank);
            return card;
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
        private List<Card> _cards = new List<Card>();

        public void TakeCard(Card card)
        {
            _cards.Add(card);
        }

        public void ShowCards()
        {
            Console.Clear();
            if (_cards.Count > 0)
            {
                Console.WriteLine("У игрока на руках следующие карты:\n");

                foreach (var card in _cards)
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
            cardsToReturn = _cards;
            _cards.Clear();
            return cardsToReturn;
        }
    }

    class Croupier
    {
        public void PlayGame(Player player, CardDeck cardDeck)
        {
            bool isGaming = true;
            string userInput;
            cardDeck.Shuffle();

            while (isGaming)
            {
                Console.WriteLine(
                    "Меню:\n" +
                    "1 - Взять карту из колоды\n" +
                    "2 - Достаточно карт!\n" +
                    "3 - Вернуть карты в колоду(сброс)\n" +
                    "4 - Перемешать колоду\n" +
                    "5 - Выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        cardDeck.MoveCardTo(player);
                        break;
                    case "2":
                        StopGame(player, cardDeck);
                        break;
                    case "3":
                        cardDeck.TakeAllCardsFrom(player);
                        break;
                    case "4":
                        cardDeck.Shuffle();
                        break;
                    case "5":
                        isGaming = false;
                        break;
                    default:
                        ShowDefaultMessage();
                        break;
                }
            }
        }

        private void StopGame(Player player, CardDeck cardDeck)
        {
            Console.WriteLine("Игра закончена.");
            player.ShowCards();
            Console.WriteLine("Нажмите любую клавишу для Новой игры.");
            Console.ReadKey();
            cardDeck.TakeAllCardsFrom(player);
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды не существует. Попробуйте снова.\n");
        }
    }
}
