using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BlackJack.nUnitTest
{
    public class PositionTests
    {
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

        private Card[] _testCards;

        private Position _testPositionBig;

        [SetUp]
        public void Setup()
        {
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

            _testCards = new Card[] {_twoOfHearts, _threeOfClubs, _fourOfSpades, _fiveOfDiamonds,
                                     _sixOfClubs, _sevenOfHearts, _eightOfClubs, _nineOfHearts, _tenOfSpades,
                                     _jackOfSpades, _queenOfDiamonds, _kingOfHearts, _aceOfSpades};

            _testPositionBig = new Position();

            foreach (Card card in _testCards)
            {
                _testPositionBig.AddPlayerCard(card);
            }
            _testPositionBig.AddDealerCard(_jackOfSpades);


        }

        [Test]
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
        }

        [Test]
        public void getDisplayString()
        {
            string correctString = "Dealer's hand:\n"+
                                   " Jack of Spades\n" +
                                   "Your hand:\n" +
                                   " Two of Hearts\n Three of Clubs\n Four of Spades\n Five of Diamonds\n" +
                                   " Six of Clubs\n Seven of Hearts\n Eight of Clubs\n Nine of Hearts\n Ten of Spades\n" +
                                   " Jack of Spades\n Queen of Diamonds\n King of Hearts\n Ace of Spades\n";

            Assert.That(_testPositionBig.GetDisplayString() == correctString);
        }
    }
}
