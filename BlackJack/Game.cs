using System.Globalization;

namespace BlackJack
{
    public class Game
    {
        private Position position;
        private DealersShoe shoe;
        private int roundNr = 0;
        private string bust = "Your have bust, you lost";
        private string dBust = "The dealer has bust, you won!";
        private string blackJack = "You got BlackJack, BIG WIN!";
        private string dBlackJack = "Dealer got BlackJack, you lost";
        private string bBlackJack = "The dealer got BlackJack... But so did you! BIG WIN!";
        private string standoff = "You have reached a standoff, the game is undecided";
        private string lose = "The dealer had more points than you, you lost.";
        private string win = "You had more points than the dealer, you won!";

        public Game()
        {
            position = new Position();
            shoe = new DealersShoe();
        }

        public void StartGame()
        {
            string displayString = "You are now playing BlackJack!!!";
            InitialDeal();
            Console.WriteLine(displayString);
            CheckBlackJack();
        }

        private void CheckBlackJack()
        {
            PositionState state = position.getPositionState();
            switch (state)
            {
                case (PositionState.BothBlackJack):
                    Console.WriteLine(position.getDisplayString());
                    Console.WriteLine(bBlackJack);
                    break;
                case (PositionState.DealerBlackJack):
                    Console.WriteLine(position.getDisplayString());
                    Console.WriteLine(dBlackJack);
                    break;
                case (PositionState.BlackJack):
                    Console.WriteLine(position.getDisplayString());
                    Console.WriteLine(blackJack);
                    break;
                default:
                    CheckBust();
                    break;
            }
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



        private void Round()
        {
            string displayString = "ROUND " + roundNr + "\n \n"
                                   + position.getDisplayString();
            position.showDealerCards();
            Console.WriteLine(displayString);
            GetMove();

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

            CheckBust();
        }

        private void Stand()
        {
            CheckStand();
        }

        private void CheckBust()
        {
            PositionState state = position.getPositionState();
            switch (state)
            {
                case PositionState.DealerBust:
                    Console.WriteLine(position.getDisplayString());
                    Console.WriteLine(dBust);
                    break;
                case PositionState.Bust:
                    Console.WriteLine(position.getDisplayString());
                    Console.WriteLine(bust);
                    break;
                default:
                    round();
                    break;
            }
        }

        private void CheckStand()
        {
            PositionState state = position.getPositionState();
            switch (state)
            {
                case (PositionState.BothBlackJack):
                    Console.WriteLine(bBlackJack);
                    break;
                case (PositionState.DealerBlackJack):
                    Console.WriteLine(dBlackJack);
                    break;
                case (PositionState.BlackJack):
                    Console.WriteLine(blackJack);
                    break;
                case PositionState.DealerBust:
                    Console.WriteLine(dBust);
                    break;
                case PositionState.Bust:
                    Console.WriteLine(bust);
                    break;
                case PositionState.Win:
                    Console.WriteLine(win);
                    break;
                case PositionState.Lose:
                    Console.WriteLine(lose);
                    break;
                case PositionState.Standoff:
                    Console.WriteLine(standoff);
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }
    }
}
