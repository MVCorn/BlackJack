using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BlackJack.nUnitTest
{
    public class PositionTests
    {   //Positions
        private Position _standoffPosition;
        private Position _winPosition;
        private Position _losePosition;

        private Position _bBlackJackPosition;
        private Position _dBlackJackPosition;
        private Position _blackJackPosition;

        private Position _dBustPosition;
        private Position _bustPosition;

        [SetUp]
        public void Setup()
        {
            //Setup cards:
            Card _twoOfHearts = new Card(Rank.Two, Suit.Hearts);
            Card _threeOfClubs = new Card(Rank.Three, Suit.Clubs);
            Card _fourOfSpades = new Card(Rank.Four, Suit.Spades);
            Card _fiveOfDiamonds = new Card(Rank.Five, Suit.Diamonds);
            Card _sixOfClubs = new Card(Rank.Six, Suit.Clubs);
            Card _sevenOfHearts = new Card(Rank.Seven, Suit.Hearts);
            Card _eightOfClubs = new Card(Rank.Eight, Suit.Clubs);
            Card _nineOfHearts = new Card(Rank.Nine, Suit.Hearts);
            Card _tenOfSpades = new Card(Rank.Ten, Suit.Spades);

            Card _jackOfSpades = new Card(Rank.Jack, Suit.Spades);
            Card _queenOfDiamonds = new Card(Rank.Queen, Suit.Diamonds);
            Card _kingOfHearts = new Card(Rank.King, Suit.Hearts);

            Card _aceOfSpades = new Card(Rank.Ace, Suit.Spades);
            Card _aceOfHearts = new Card(Rank.Ace, Suit.Hearts);

            //Setup arrays
            // Stand states
            Card[] standoffCards = [_sixOfClubs, _fiveOfDiamonds, _fourOfSpades,
                                    _threeOfClubs, _queenOfDiamonds, _twoOfHearts, 
                                    _jackOfSpades];

            Card[] winCards = [_fourOfSpades, _threeOfClubs, _kingOfHearts, _twoOfHearts];

            Card[] loseCards = [_fourOfSpades, _twoOfHearts, _fiveOfDiamonds, 
                                _sevenOfHearts, _threeOfClubs, _tenOfSpades];

            // Black jack states
            Card[] bBlackJackCards = [_aceOfHearts, _aceOfSpades, _tenOfSpades, _kingOfHearts];

            Card[] dBlackJackCards = [_eightOfClubs, _eightOfClubs, _sevenOfHearts, _queenOfDiamonds];

            Card[] blackJackCards = [_jackOfSpades, _fourOfSpades, _aceOfSpades, _sixOfClubs];

            // Bust states

            Card[] dBustCards = [_twoOfHearts, _kingOfHearts, _threeOfClubs, _sixOfClubs, _fourOfSpades, _tenOfSpades];

            Card[] bustCards = [_kingOfHearts, _fiveOfDiamonds, _jackOfSpades, _fourOfSpades, _queenOfDiamonds, _threeOfClubs]; 

            //Setup dealersShoes
            // Stand states
            DealersShoe standoffShoe = new DealersShoe(standoffCards);
            DealersShoe winShoe = new DealersShoe(winCards);
            DealersShoe loseShoe = new DealersShoe(loseCards);

            // BlackJack states
            DealersShoe bBlackJackShoe = new DealersShoe(bBlackJackCards);
            DealersShoe dBlackJackShoe = new DealersShoe(dBlackJackCards);
            DealersShoe blackJackShoe = new DealersShoe(blackJackCards);

            // Bust states
            DealersShoe dBustShoe = new DealersShoe(dBustCards);
            DealersShoe bustShoe = new DealersShoe(bustCards);

            //Setup positions
            // Stand states
            _standoffPosition = new Position();
            _standoffPosition.setShoe(standoffShoe);
            _winPosition = new Position();
            _winPosition.setShoe(winShoe);
            _losePosition = new Position();
            _losePosition.setShoe(loseShoe);

            // BlackJack states
            _bBlackJackPosition = new Position();
            _bBlackJackPosition.setShoe(bBlackJackShoe);
            _dBlackJackPosition = new Position();
            _dBlackJackPosition.setShoe(dBlackJackShoe);
            _blackJackPosition = new Position();
            _blackJackPosition.setShoe(blackJackShoe);

            // Bust stats
            _dBustPosition = new Position();
            _dBustPosition.setShoe(dBustShoe);
            _bustPosition = new Position();
            _bustPosition.setShoe(bustShoe);
        }

        public void TestHelper(string testName, string expected, string actual)
        {
            Console.WriteLine(testName + ": \n");
            Console.WriteLine("Expected: \n" + expected + "\n");
            Console.WriteLine("Actual: \n" + actual + "\n");

            Assert.That(actual == expected);
        }

        [Test]
        public void getDisplayStringStandoff()
        {
            //Standoff display
            _standoffPosition.StartSetup();
            _standoffPosition.Hit();
            _standoffPosition.Hit();
            _standoffPosition.Hit();

            string standoffExpected = "Dealer's hand:\n" +
                                   " Jack of Spades\n Queen of Diamonds\n" +
                                   "Your hand:\n" +
                                   " Two of Hearts\n Three of Clubs\n Four of Spades\n Five of Diamonds\n" +
                                   " Six of Clubs\n";
            string standoffActual = _standoffPosition.GetDisplayString();

            TestHelper("Standoff display test", standoffExpected, standoffActual);
        }

        [Test]
        public void StartSetup()
        {
            string expectedSetupDisplay = "You are now playing BlackJack!!!\n" +
                                          "Initial Round\n\n" +
                                          "Dealer's hand:\n Ten of Spades\n Hidden card\n" +
                                          "Your hand:\n Three of Clubs\n Five of Diamonds\n";
            string actialSetupDisplay = _losePosition.StartSetup();

            TestHelper("Setup Test", expectedSetupDisplay, actialSetupDisplay);
        }

        [Test]
        public void StartGameOngoing()
        {
            _losePosition.StartSetup();
            string actualStartGameOngoing = _losePosition.StartGame();
            TestHelper("Ongoing StartGame Test", StateString.ongoing, actualStartGameOngoing);
        }

        [Test]
        public void StartGameBlackJack()
        {
            _blackJackPosition.StartSetup();
            string actualSGBlackJack = _blackJackPosition.StartGame();
            TestHelper("BlackJack StartGame Test", StateString.blackJack, actualSGBlackJack);
        }

        [Test]
        public void StandWinTest()
        {
            _winPosition.StartSetup();
            string ongoing = _winPosition.StartGame();
            string stand = _winPosition.Stand();

            TestHelper("Win Stand Test", StateString.ongoing + "\n" + StateString.win, ongoing + "\n" + stand);
        }

        [Test]
        public void HitBustTest()
        {
            _bustPosition.StartSetup();
            string hit = _bustPosition.Hit();

            TestHelper("Bust Hit Test", StateString.bust, hit);
        }

    }
}
