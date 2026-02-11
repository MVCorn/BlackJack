using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class DealersShoe
    {
        private Stack<Card> cards;

        public DealersShoe()
        {
            cards = createDeck();
            shuffle();
        }
        
        // Create full deck of cards
        private Stack<Card> createDeck()
        {
            Stack<Card> cards = new Stack<Card>();
            // Loop though ranks
            for(int rankInt = 0; rankInt < 12; rankInt ++)
            {
                Rank rank = (Rank)rankInt;

                // Loop through suits
                for(int suitInt = 0; suitInt < 4;  suitInt ++)
                {
                    Suit suit = (Suit)suitInt;
                    cards.Push(new Card(rank, suit));
                }
            }

            return cards;
        }

        private void shuffle()
        {
            Card[] cardsArray = cards.ToArray();
            System.Random rnd = new System.Random();
            Card[] shuffledArray = cardsArray.OrderBy(x => rnd.Next()).ToArray();
            cards = new Stack<Card>(shuffledArray);
        }

        public Card takeCard()
        {
            return cards.Pop();
        }

        public Card[] getCardsArrayForTesting () {  return cards.ToArray(); }

    }
}
