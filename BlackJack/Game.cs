namespace BlackJack
{
    public class Game
    {
        private Position position;
        private DealersShoe shoe;

        private int roundNr = 1;

        private string bust = "Your have bust, you lost";
        private string dBust = "The dealer has bust, you won!";
        private string blackJack = "You got BlackJack, BIG WIN!";
        private string dBlackJack = "Dealer got BlackJack, you lost";
        private string bBlackJack = "The dealer got BlackJack... But so did you! BIG WIN!";
        private string standoff = "You have reached a standoff, the game is undecided";
        private string lose = "The dealer had more points than you, you lost.";
        private string win = "You had more points than the dealer, you won!";

        public Game(DealersShoe shoe)
        {
            position = new Position();
            this.shoe = shoe;
        }

        public void StartGame()
        {
            string displayString = "You are now playing BlackJack!!! \n";
            InitialDeal();
            displayString = displayString + "Initial Round \n \n"
                            + position.GetDisplayString();
            Console.WriteLine(displayString);
            position.ShowDealerCards();
            CheckBlackJack("start");
        }

        private void EndGame()
        {
            string displayString = "\n The game has ended, would you like to play again? \n Y/N";
            Console.WriteLine(displayString);

            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "y":
                    Console.WriteLine("\n");
                    position = new Position();
                    shoe = new DealersShoe();
                    StartGame();
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("That is not a valid inpit, please try again");
                    EndGame();
                    break;
            }
        }

        private void InitialDeal()
        {
            position.AddDealerCard(shoe.TakeCard());
            position.AddPlayerCard(shoe.TakeCard());
            Card hiddenCard = shoe.TakeCard();
            hiddenCard.Hide();
            position.AddDealerCard(hiddenCard);
            position.AddPlayerCard(shoe.TakeCard());
        }

        private void GetMove()
        {
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "h":
                    Hit();
                    break;
                case "s":
                    Stand();
                    break;
                default:
                    Console.WriteLine("That is not a valid inpit, please try again");
                    GetMove();
                    break;
            }
        }

        private void Hit()
        {
            position.AddPlayerCard(shoe.TakeCard());
            if (position.DealerStillHitting())
            {
                position.AddDealerCard(shoe.TakeCard());
            }

            string displayString = "ROUND " + roundNr + "\n \n"
                                   + position.GetDisplayString();

            Console.WriteLine(displayString);

            CheckBlackJack("hit");
        }

        private void Stand()
        {
            Console.WriteLine(position.GetDisplayString());
            CheckBlackJack("stand");
        }

        private void CheckBlackJack(string move)
        {
            PositionState state = position.GetPositionState();

            switch (state)
            {
                case (PositionState.BothBlackJack):
                    Console.WriteLine(bBlackJack);
                    EndGame();
                    break;
                case (PositionState.DealerBlackJack):
                    Console.WriteLine(dBlackJack);
                    EndGame();
                    break;
                case (PositionState.BlackJack):
                    Console.WriteLine(blackJack);
                    EndGame();
                    break;
                default:
                    CheckBust(move);
                    break;
            }
        }

        private void CheckBust(string move)
        {
            PositionState state = position.GetPositionState();
            switch (state)
            {
                case PositionState.DealerBust:
                    Console.WriteLine(dBust);
                    EndGame();
                    break;
                case PositionState.Bust:
                    Console.WriteLine(bust);
                    EndGame();
                    break;
                default:
                    if (move == "hit" || move == "start")
                    {
                        GetMove();
                    }
                    else if (move == "stand")
                    {
                        CheckStand();
                    }
                    ;
                    break;
            }
        }

        private void CheckStand()
        {
            PositionState state = position.GetPositionState();
            switch (state)
            {
                case PositionState.Win:
                    Console.WriteLine(win);
                    EndGame();
                    break;
                case PositionState.Lose:
                    Console.WriteLine(lose);
                    EndGame();
                    break;
                case PositionState.Standoff:
                    Console.WriteLine(standoff);
                    EndGame();
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }
    }
}
