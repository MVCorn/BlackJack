namespace BlackJack
{
    public class Hand
    {
        private List<Card> cards;
        private int nrAces = 0;
        private int totalPoints = 0;
        public Hand()
        {
            cards = new List<Card>();
        }

        // Adds new card to hand
        // Adds to Ace counter where relevant
        // Calculates you point total
        public void addCard(Card card)
        {
            if (card.getRank() == Rank.Ace)
            {
                nrAces++;
            }
            cards.Add(card);

            totalPoints = calculatePoints();
        }

        public void showAllCards()
        {
            foreach (Card card in cards)
            {
                card.show();
            }
        }

        // Calculates points
        // Handles aces
        private int calculatePoints()
        {
            int points = 0;
            foreach (Card card in cards)
            {
                points = points + card.getPoints();
            }

            if (points > 21)
            {
                for (int i = 0; i < nrAces; i++)
                {
                    if (points > 21)
                    {
                        points = points - 10;
                    }
                }
            }
            return points;
        }

        public int getPoints()
        {
            return totalPoints;
        }

        public int getNrCards()
        {
            return cards.Count;
        }

        // Gets pretty string for output
        public string getDisplayString()
        {
            string displayString = "";
            foreach (Card card in cards)
            {
                displayString += " " + card.getDisplayString() + "\n";
            }
            return displayString;
        }

        

        public List<Card> getCardsForTesting() { return cards; }
        public int getNrAcesForTesting() { return nrAces; }
    }
}
