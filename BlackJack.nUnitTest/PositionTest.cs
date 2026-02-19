using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BlackJack.nUnitTest
{
    public class PositionTests
    {
        //Cards
        private Card _twoOfHearts;
        private Card _threeOfClubs;
        private Card _fourOfSpades;
        private Card _fiveOfDiamonds;
        private Card _sixOfClubs;
        private Card _sevenOfHearts;
        private Card _eightOfClubs;
        private Card _nineOfHearts;
        private Card _tenOfSpades;

        private Card _jackOfSpades;
        private Card _queenOfDiamonds;
        private Card _kingOfHearts;

        private Card _aceOfSpades;

        //Positions
        private Position _standoffPosition;

        [SetUp]
        public void Setup()
        {
            //Setup cards:
            _twoOfHearts = new Card(Rank.Two, Suit.Hearts);
            _threeOfClubs = new Card(Rank.Three, Suit.Clubs);
            _fourOfSpades = new Card(Rank.Four, Suit.Spades);
            _fiveOfDiamonds = new Card(Rank.Five, Suit.Diamonds);
            _sixOfClubs = new Card(Rank.Six, Suit.Clubs);
            _sevenOfHearts = new Card(Rank.Seven, Suit.Hearts);
            _eightOfClubs = new Card(Rank.Eight, Suit.Clubs);
            _nineOfHearts = new Card(Rank.Nine, Suit.Hearts);
            _tenOfSpades = new Card(Rank.Ten, Suit.Spades);

            _jackOfSpades = new Card(Rank.Jack, Suit.Spades);
            _queenOfDiamonds = new Card(Rank.Queen, Suit.Diamonds);
            _kingOfHearts = new Card(Rank.King, Suit.Hearts);

            _aceOfSpades = new Card(Rank.Ace, Suit.Spades);

            //Setup arrays
            Card[] standoffCards = [_sixOfClubs, _fiveOfDiamonds, _fourOfSpades,
                _threeOfClubs, _queenOfDiamonds, _twoOfHearts, _jackOfSpades];

            //Setup dealersShoes
            DealersShoe standoffShoe = new DealersShoe(standoffCards);

            //Setup positions
            _standoffPosition = new Position();
            _standoffPosition.setShoe(standoffShoe);
        }

        [Test]
        public void StartSetup()
        {

        }

        /*[Test]
        public void getPositionState()
        {
            Assert.That(_testPositionBig.GetPositionState() == PositionState.Bust);

            Position pDealerBust = new Position();
            pDealerBust.AddDealerCard(_jackOfSpades);
            pDealerBust.AddDealerCard(_kingOfHearts);
            pDealerBust.AddDealerCard(_queenOfDiamonds);

            Assert.That(pDealerBust.GetPositionState() == PositionState.DealerBust);

            Position pLoose = new Position();
            pLoose.AddDealerCard(_aceOfSpades);
            pLoose.AddPlayerCard(_jackOfSpades);

            Assert.That(pLoose.GetPositionState() == PositionState.Lose);

            Position pWin = new Position();

            pWin.AddPlayerCard(_queenOfDiamonds);
            pWin.AddDealerCard(_twoOfHearts);

            Assert.That(pWin.GetPositionState() == PositionState.Win);

            Position pBlackJack = new Position();
            pBlackJack.AddPlayerCard(_jackOfSpades);
            pBlackJack.AddPlayerCard(_aceOfSpades);

            Assert.That(pBlackJack.GetPositionState() == PositionState.BlackJack);

            Position pDealerBlackJack = new Position();
            pDealerBlackJack.AddDealerCard(_queenOfDiamonds);
            pDealerBlackJack.AddDealerCard(_aceOfSpades);

            Assert.That(pDealerBlackJack.GetPositionState() == PositionState.DealerBlackJack);

            Position pBothBlackJack = new Position();
            pBothBlackJack.AddPlayerCard(_jackOfSpades);
            pBothBlackJack.AddPlayerCard(_aceOfSpades);
            pBothBlackJack.AddDealerCard(_queenOfDiamonds);
            pBothBlackJack.AddDealerCard(_aceOfSpades);

            Assert.That(pBothBlackJack.GetPositionState() == PositionState.BothBlackJack);

            Position pDealer21NotBlackJack = new Position();
            pDealer21NotBlackJack.AddDealerCard(_queenOfDiamonds);
            pDealer21NotBlackJack.AddDealerCard(_threeOfClubs);
            pDealer21NotBlackJack.AddDealerCard(_eightOfClubs);

            Assert.That(pDealer21NotBlackJack.GetPositionState() == PositionState.Lose);
        }*/

        [Test]
        public void getDisplayStringStandoff()
        {
            //Standoff display
            _standoffPosition.StartSetup();
            _standoffPosition.Hit();
            _standoffPosition.Hit();
            _standoffPosition.Hit();

            string standoffExpected = "Dealer's hand:\n"+
                                   " Jack of Spades\n Queen of Diamonds\n" +
                                   "Your hand:\n" +
                                   " Two of Hearts\n Three of Clubs\n Four of Spades\n Five of Diamonds\n" +
                                   " Six of Clubs\n";
            string standoffActual = _standoffPosition.GetDisplayString(); 

            TestHelper("Standoff display test", standoffExpected, standoffActual);
        }

        public void TestHelper(string testName, string expected,  string actual)
        {
            Console.WriteLine(testName + ": \n");
            Console.WriteLine("Expected: \n" + expected);
            Console.WriteLine("Actual: \n" + actual + "\n");

            Assert.That(actual == expected);
        }
    }
}
