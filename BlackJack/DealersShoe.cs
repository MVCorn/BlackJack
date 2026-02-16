namespace BlackJack
{
    public class DealersShoe : AbstractShoe
    {
        private Stack<Card> cards;

        public DealersShoe()
        {
            cards = CreateDeck();
            Shuffle();
        }

        // Shuffel cards
        private void Shuffle()
        {
            Card[] cardsArray = cards.ToArray();
            System.Random rnd = new System.Random();
            Card[] shuffledArray = cardsArray.OrderBy(x => rnd.Next()).ToArray();
            cards = new Stack<Card>(shuffledArray);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
