namespace BlackJack
{
    public abstract class AbstractShoe
    {
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

        public abstract Card TakeCard();
    }
}
