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

        public void startGame()
        {
            string displayString = "You are now playing BlackJack!!!";
            initialDeal();
            Console.WriteLine(displayString);
            checkBlackJack();
        }

        private void checkBlackJack()
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
                default:
                    round();
                    break;
            }
        }

        private void initialDeal()
        {
            position.addDealerCard(shoe.takeCard());
            position.addPlayerCard(shoe.takeCard());
            Card hiddenCard = shoe.takeCard();
            hiddenCard.hide();
            position.addDealerCard(hiddenCard);
            position.addPlayerCard(shoe.takeCard());
        }



        private void round()
        {
            string displayString = "ROUND " + roundNr + "\n \n"
                                   + position.getDisplayString();
            Console.WriteLine(displayString);
            getMove();

        }

        private void getMove()
        {
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "h":
                    hit();
                    break;
                case "s":
                    stand();
                    break;
                default:
                    Console.WriteLine("That is not a valid inpit, please try again");
                    getMove();
                    break;

            }
        }

        private void hit()
        {
            position.addPlayerCard(shoe.takeCard());
        }

        private void stand()
        {

        }

        private void checkBust()
        {
            PositionState state = position.getPositionState();
            switch (state)
            {
                case PositionState.DealerBust:
                    Console.WriteLine(dBust);
                    break;
                case PositionState.Bust:
                    Console.WriteLine(bust);
                    break;
                default:
                    break;
            }
        }
    }
}
