namespace BlackJack
{
    public class TestShoe : DealersShoe
    {
        private Stack<Card> cards;
        public TestShoe(Card[] cardArray)
        {
            cards = new Stack<Card>(cardArray);
        }

        // Take card from top of stack
        public Card TakeCard()
        {
            return cards.Pop();
        }

        public Card[] GetCardsArrayForTesting() { return cards.ToArray(); }
    }
}
