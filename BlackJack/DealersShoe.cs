namespace BlackJack
{
    public class DealersShoe
    {
        private Stack<Card> cards;

        public DealersShoe()
        {
            cards = CreateDeck();
            Shuffle();
        }

        // Create full deck of cards (preshuffled)
        private Stack<Card> CreateDeck()
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

        // Shuffel cards
        private void Shuffle()
        {
            Card[] cardsArray = cards.ToArray();
            System.Random rnd = new System.Random();
            Card[] shuffledArray = cardsArray.OrderBy(x => rnd.Next()).ToArray();
            cards = new Stack<Card>(shuffledArray);
        }

        // Take card from top of stack
        public Card TakeCard()
        {
            return cards.Pop();
        }

        public Card[] GetCardsArrayForTesting() { return cards.ToArray(); }

    }
}
