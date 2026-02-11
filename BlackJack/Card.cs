using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum Suit
    {
        Clubs,
        Dimonds,
        Hearts,
        Spades
    }
    public class Card
    {
        private Rank rank;
        private Suit suit;
        private bool visability;
        private int points;

        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
            visability = true;
            switch(rank)
            {
                case Rank.Two: case Rank.Three: case Rank.Four: case Rank.Five: case Rank.Six: case Rank.Seven: case Rank.Eight: case Rank.Nine:
                    points = (int)rank + 2;
                    break;
                case Rank.Jack: case Rank.Queen: case Rank.King:
                    points = 10;
                    break;
                case Rank.Ace:
                    points = 11;
                    break;
                default:
                    points = 0;
                    Console.WriteLine("Attempted to find points of nonexistent rank: " + rank);
                    break;
            }
        }

        public int getPoints()
        {
            return points;
        }
    }
}
