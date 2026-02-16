using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public abstract class AbstractShoe
    {
        private Stack<Card> cards;

        public AbstractShoe()
        {
            cards = new Stack<Card>();
        }


        // Create full deck of cards (preshuffled)
        public static Stack<Card> CreateDeck()
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
        public Card TakeCard()
        {
            return cards.Pop();
        }

        public Card[] GetCardsArrayForTesting() { return cards.ToArray(); }
    }
}
