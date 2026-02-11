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
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    public class Card
    {
        private Rank rank;
        private Suit suit;
        // visible initiated as true
        private bool visable = true;
        private int points;

        // Construct card from rank and suit
        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;

            //Determin points based on rank
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

        // Getter fror points
        public int getPoints()
        {
            return points;
        }

        // Create tring to represent card. Changes with visibility
        public String getDisplayString()
        {
            if (visable)
            {
                return rank + " of " + suit;
            }
            else
            {
                return "Hidden card";
            }
        }

        public void hide() { visable = false; }

        public void show() { visable = true; }

        public override bool Equals(object? obj)
        {
            try
            {
                Card otherCard = (Card)obj;
                var rankEqual = this.rank == otherCard.rank;
                var suitEqual = this.suit == otherCard.suit;
                var pointsEqual = this.points == otherCard.points;
                var visibleEqual = this.visable == otherCard.visable;

                return (rankEqual && suitEqual && pointsEqual && visibleEqual);
            }
            catch
            {
                return base.Equals(obj);
            }
            
        }
    }
}
