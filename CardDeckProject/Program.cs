using System;
using System.Collections.Generic;

namespace CardDeckProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardDeck cardDeck = new CardDeck();
            cardDeck.Create();
            cardDeck.Shuffle();
            cardDeck.Show();
            
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

        public void Shuffle()
        {
            Random randomIndex = new Random();

            for (int i = 0; i < _cardDeck.Count; i++)
            {
                int replacementIndex = randomIndex.Next(i + 1);
                Card card = _cardDeck[replacementIndex];
                _cardDeck.RemoveAt(replacementIndex);
                _cardDeck.Add(card);
            }
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

    }
}
