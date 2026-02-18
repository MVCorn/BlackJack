namespace BlackJack
{
    public enum PositionState
    {
        Win,
        Lose,
        Bust,
        DealerBust,
        BlackJack,
        DealerBlackJack,
        BothBlackJack,
        Standoff,
        ERROR
    }
    public class Position
    {
        private Hand dealerHand;
        private Hand playerHand;
        private PositionState state;

        public Position()
        {
            dealerHand = new Hand();
            playerHand = new Hand();
        }

        public void AddDealerCard(Card card)
        {
            dealerHand.AddCard(card);
            state = ComparePoints();
        }

        public void AddPlayerCard(Card card)
        {
            playerHand.AddCard(card);
            state = ComparePoints();
        }

        public void ShowDealerCards()
        {
            dealerHand.ShowAllCards();
        }

        public bool DealerStillHitting()
        {
            int points = dealerHand.GetPoints();
            if (points > 16)
            {
                return false;
            } else
            {
                return true;
            }
        }

        private PositionState ComparePoints()
        {
            int dealerPoints = dealerHand.GetPoints();
            int playerPoints = playerHand.GetPoints();
            int dealerCount = dealerHand.GetNrCards();
            int playerCount = playerHand.GetNrCards();

            switch ((dealerPoints: dealerPoints, playerPoints: playerPoints))
            {
                case (dealerPoints: 21, playerPoints: 21):
                    switch((dealerCount, playerCount))
                    {
                        case (2, 2):
                            return PositionState.BothBlackJack;
                        case (2, _):
                            return PositionState.DealerBlackJack;
                        case (_, 2):
                            return PositionState.BlackJack;
                        default:
                            return PositionState.Standoff;
                    }
                case (dealerPoints: 21, _):
                    if (dealerCount == 2)
                    { return PositionState.DealerBlackJack; }
                    else
                    { return PositionState.Lose; }
                case (_, playerPoints: 21):
                    if (playerCount == 2)
                    { return PositionState.BlackJack; }
                    else
                    { return PositionState.Win; }
                case (dealerPoints: > 21, _):
                    return PositionState.DealerBust;
                case (_, playerPoints: > 21):
                    return PositionState.Bust;
                case (dealerPoints: < 21, playerPoints: < 21):
                    if (dealerPoints < playerPoints)
                    {
                        return PositionState.Win;
                    }
                    else if (dealerPoints > playerPoints)
                    {
                        return PositionState.Lose;
                    } else
                    {
                        return PositionState.Standoff;
                    }
                default:
                    return PositionState.ERROR;

            }
        }

        public PositionState GetPositionState()
        {
            return state;
        }

        public string GetDisplayString()
        {
            string displayString = "Dealer's hand:\n" +
                                   dealerHand.GetDisplayString() +
                                   "Your hand:\n" +
                                   playerHand.GetDisplayString();

            return displayString;
        }
    }
}
