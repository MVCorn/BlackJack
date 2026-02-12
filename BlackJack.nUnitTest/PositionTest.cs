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

        private Hand _handFull;
        private Hand _handOneCard;

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

            _handFull = new Hand();

            foreach (Card card in _testCards)
            {
                _handFull.addCard(card);
            }

            _handOneCard = new Hand();
            _handOneCard.addCard(_jackOfSpades);


        }

        [Test]
        public void addCardDealer()
        {
        }

        [Test]
        public void addCardPlayer()
        {
        }

        [Test]
        public void getPositionState()
        {
        }

        [Test]
        public void getDisplayString()
        {
            
            string correctString = "Your hand:\nTwo of Hearts\nThree of Clubs\nFour of Spades\nFive of Diamonds" +
                                   "\nSix of Clubs\nSeven of Hearts\nEight of Clubs\nNine of Hearts\nTen of Spades" +
                                   "\nJack of Spades\nQueen of Diamonds\nKing of Hearts\nAce of Spades\n";
        }
    }
}
