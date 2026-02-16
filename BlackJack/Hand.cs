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
        public void AddCard(Card card)
        {
            if (card.GetRank() == Rank.Ace)
            {
                nrAces++;
            }
            cards.Add(card);

            totalPoints = CalculatePoints();
        }

        public void ShowAllCards()
        {
            foreach (Card card in cards)
            {
                card.Show();
            }
        }

        // Calculates points
        // Handles aces
        private int CalculatePoints()
        {
            int points = 0;
            foreach (Card card in cards)
            {
                points = points + card.GetPoints();
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

        public int GetPoints()
        {
            return totalPoints;
        }

        public int GetNrCards()
        {
            return cards.Count;
        }

        // Gets pretty string for output
        public string GetDisplayString()
        {
            string displayString = "";
            foreach (Card card in cards)
            {
                displayString += " " + card.GetDisplayString() + "\n";
            }
            return displayString;
        }

        

        public List<Card> GetCardsForTesting() { return cards; }
        public int GetNrAcesForTesting() { return nrAces; }
    }
}
