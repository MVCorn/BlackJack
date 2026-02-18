using System.Globalization;

namespace BlackJack
{
    public class Game
    {
        private Position position;
        private AbstractShoe shoe;
        private int roundNr = 0;
        private string bust = "Your have bust, you lost";
        private string dBust = "The dealer has bust, you won!";
        private string blackJack = "You got BlackJack, BIG WIN!";
        private string dBlackJack = "Dealer got BlackJack, you lost";
        private string bBlackJack = "The dealer got BlackJack... But so did you! BIG WIN!";
        private string standoff = "You have reached a standoff, the game is undecided";
        private string lose = "The dealer had more points than you, you lost.";
        private string win = "You had more points than the dealer, you won!";

        public Game(AbstractShoe shoe)
        {
            position = new Position();
            this.shoe = shoe;
        }

        public void StartGame()
        {
            string displayString = "You are now playing BlackJack!!! \n";
            InitialDeal();
            displayString = displayString + "Initial Round \n \n"
                            + position.getDisplayString();
            Console.WriteLine(displayString);
            position.showDealerCards();
            CheckBlackJack("start");
        }

        private void EndGame()
        {
            string displayString = "The game has ended, would you like to play again? \n Y/N";
            Console.WriteLine(displayString);

            string input = Console.ReadLine();
        }


        private void InitialDeal()
        {
            position.addDealerCard(shoe.TakeCard());
            position.addPlayerCard(shoe.TakeCard());
            Card hiddenCard = shoe.TakeCard();
            hiddenCard.Hide();
            position.addDealerCard(hiddenCard);
            position.addPlayerCard(shoe.TakeCard());
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
            position.addPlayerCard(shoe.TakeCard());
            position.addDealerCard(shoe.TakeCard());

            string displayString = "ROUND " + roundNr + "\n \n"
                                   + position.getDisplayString();

            Console.WriteLine(displayString);


            CheckBlackJack("hit");
        }

        private void Stand()
        {
            CheckBlackJack("stand");
            EndGame();
        }


        private void CheckBlackJack(string move)
        {
            PositionState state = position.getPositionState();
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
            PositionState state = position.getPositionState();
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
                    if(move == "hit" || move == "start")
                    {
                        GetMove();
                    } else if (move == "stand")
                    {
                        CheckStand();
                    }
                    ;
                    break;
            }
        }

        private void CheckStand()
        {
            PositionState state = position.getPositionState();
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
