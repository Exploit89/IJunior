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

        public List<Card> GetCardDeck()
        {
            return _cardDeck;
        }

        private Card CreateCard(CardSuit suit, CardRank rank)
        {
            Card card = new Card(suit, rank);
            return card;
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
        private List<Card> _cardDeck = new List<Card>();

        public void PlayGame(Player player, CardDeck cardDeck)
        {
            _cardDeck = cardDeck.GetCardDeck();
            bool isGaming = true;
            string userAnyInput;
            int userInput = 0;
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

        private void Shuffle()
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

        private bool CheckNumberInput(string userInput)
        {
            if (int.TryParse(userInput, out int number))
                return true;
            else
                return false;
        }

        private void MoveCardTo(Player player)
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

        private Card GiveCard()
        {
            return _cardDeck[0];
        }

        private void DeleteCard()
        {
            _cardDeck.RemoveAt(0);
        }

        private void StopGame(Player player)
        {
            Console.WriteLine("Игра закончена.");
            player.ShowCards();
            Console.WriteLine("Нажмите любую клавишу для Новой игры.");
            Console.ReadKey();
            TakeAllCardsFrom(player);
        }

        private void TakeAllCardsFrom(Player player)
        {
            Console.Clear();
            Console.WriteLine("Все карты возвращены в колоду.\n");

            List<Card> playerCards = player.ReturnAllCards();

            foreach (var card in playerCards)
            {
                TakeCard(card);
            }
        }

        private void TakeCard(Card card)
        {
            _cardDeck.Add(card);
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды не существует. Попробуйте снова.\n");
        }
    }
}
