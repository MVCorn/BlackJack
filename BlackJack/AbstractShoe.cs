using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public abstract class AbstractShoe
    {
        private Stack<Card> cards;


        // Create full deck of cards (preshuffled)
        protected static Stack<Card> CreateDeck()
        {
            Stack<Card> cards = new Stack<Card>();
            // Loop though ranks
            for (int rankInt = 0; rankInt < 13; rankInt++)
            {
                Rank rank = (Rank)rankInt;

                // Loop through suits
                for (int suitInt = 0; suitInt < 4; suitInt++)
                {
                    Suit suit = (Suit)suitInt;
                    cards.Push(new Card(rank, suit));
                }
            }

            return cards;
        }

        // Take card from top of stack
        protected Card TakeCard()
        {
            return cards.Pop();
        }

        public Card[] GetCardsArrayForTesting() { return cards.ToArray(); }
    }
}
