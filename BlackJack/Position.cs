namespace BlackJack
{

    public enum State
    {
        Win,
        Lose,
        Bust,
        DealerBust,
        BlackJack,
        DealerBlackJack,
        BothBlackJack,
        Standoff,
        Ongoing,
        ERROR
    }

    public struct StateString
    {
        public const string bBlackJack = "The dealer got BlackJack... But so did you! BIG WIN!";
        public const string dBlackJack = "Dealer got BlackJack, you lost";
        public const string blackJack = "You got BlackJack, BIG WIN!";
        public const string dBust = "The dealer has bust, you won!";
        public const string bust = "Your have bust, you lost";
        public const string win = "You had more points than the dealer, you won!";
        public const string lose = "The dealer had more points than you, you lost.";
        public const string standoff = "You have reached a standoff, the game is undecided";
        public const string ongoing = "ONGOING";
        public const string ERROR = "ERROR";
    }

    public class Position
    {
        private Hand dealerHand;
        private Hand playerHand;

        private DealersShoe shoe;


        public Position()
        {
            dealerHand = new Hand();
            playerHand = new Hand();

            shoe = new DealersShoe();
        }

        public void setShoe(DealersShoe shoe)
        {
            this.shoe = shoe;
        }

        private void AddDealerCard(Card card)
        {
            dealerHand.AddCard(card);
        }

        private void AddPlayerCard(Card card)
        {
            playerHand.AddCard(card);
        }

        private void ShowDealerCards()
        {
            dealerHand.ShowAllCards();
        }

        private bool DealerStillHitting()
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

        public string StartSetup()
        {
            string displayString = "You are now playing BlackJack!!!\n";
            InitialDeal();
            displayString = displayString + "Initial Round\n\n"
                            + GetDisplayString();
            ShowDealerCards();
            return displayString;
        }

        public string StartGame()
        {
            State state = ComparePoints(playerHand);
            return CheckBlackJack("start", state);
        }

        private void InitialDeal()
        {
            AddDealerCard(shoe.TakeCard());
            AddPlayerCard(shoe.TakeCard());
            Card hiddenCard = shoe.TakeCard();
            hiddenCard.Hide();
            AddDealerCard(hiddenCard);
            AddPlayerCard(shoe.TakeCard());
        }

        public void EndGame()
        {
            dealerHand = new Hand();
            playerHand = new Hand();
            shoe = new DealersShoe();
        }

        public string Hit()
        {
            AddPlayerCard(shoe.TakeCard());
            if (DealerStillHitting())
            {
                AddDealerCard(shoe.TakeCard());
            }
            State state = ComparePoints(playerHand);
            return CheckBlackJack("hit", state);
        }

        public string Stand()
        {
            State state = ComparePoints(playerHand);
            return CheckBlackJack("stand", state);
        }

        private string CheckBlackJack(string move, State state)
        {;

            switch (state)
            {
                case (State.BothBlackJack):
                    return StateString.bBlackJack;
                case (State.DealerBlackJack):
                    return StateString.dBlackJack;
                case (State.BlackJack):
                    return StateString.blackJack;
                default:
                    return CheckBust(move, state);
            }
        }

        private string CheckBust(string move, State state)
        {
            switch (state)
            {
                case State.DealerBust:
                    return StateString.dBust;
                case State.Bust:
                    return StateString.bust;
                default:
                    if (move == "hit" || move == "start")
                    {
                        return StateString.ongoing;
                    }
                    else if (move == "stand")
                    {
                        return CheckStand(state);
                    } else
                    {
                        return StateString.ERROR;
                    }
            }
        }

        private string CheckStand(State state)
        {;
            switch (state)
            {
                case State.Win:
                    return StateString.win;
                case State.Lose:
                    return StateString.lose;
                case State.Standoff:
                    return StateString.standoff;
                default:
                    return StateString.ERROR;
            }
        }

        private State ComparePoints(Hand playerHand)
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
                            return State.BothBlackJack;
                        case (2, _):
                            return State.DealerBlackJack;
                        case (_, 2):
                            return State.BlackJack;
                        default:
                            return State.Standoff;
                    }
                case (dealerPoints: 21, _):
                    if (dealerCount == 2)
                    { return State.DealerBlackJack; }
                    else
                    { return State.Lose; }
                case (_, playerPoints: 21):
                    if (playerCount == 2)
                    { return State.BlackJack; }
                    else
                    { return State.Win; }
                case (dealerPoints: > 21, _):
                    return State.DealerBust;
                case (_, playerPoints: > 21):
                    return State.Bust;
                case (dealerPoints: < 21, playerPoints: < 21):
                    if (dealerPoints < playerPoints)
                    {
                        return State.Win;
                    }
                    else if (dealerPoints > playerPoints)
                    {
                        return State.Lose;
                    } else
                    {
                        return State.Standoff;
                    }
                default:
                    return State.ERROR;

            }
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
