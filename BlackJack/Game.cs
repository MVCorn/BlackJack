namespace BlackJack
{
    public class Game
    {
        private Position position;

        private int roundNr = 0;

        public Game()
        {
            position = new Position();
        }

        public void StartGame()
        {
            string displayString = position.StartSetup();
            Console.WriteLine(displayString);
            string stateString = position.StartGame();

            CheckOngoing(stateString);
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
                    position.EndGame();
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

        private void CheckOngoing(string stateString)
        {
            if (stateString == StateString.ongoing)
            {
                roundNr += 1;
                GetMove();
            }
            else
            {
                Console.WriteLine(stateString);
                EndGame();
            }
        }

        private void Hit()
        {
            string stateString = position.Hit();

            string displayString = "ROUND " + roundNr + "\n \n"
                                   + position.GetDisplayString();

            Console.WriteLine(displayString);

            CheckOngoing(stateString);
        }

        private void Stand()
        {
            string stateString = position.Stand();

            Console.WriteLine(position.GetDisplayString());

            Console.WriteLine(stateString);
            EndGame();
        }
    }
}
