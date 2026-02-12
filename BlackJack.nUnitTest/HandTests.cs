using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BlackJack.nUnitTest
{
    public class HandTests
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
        }

        [Test]
        public void addCard()
        {
            Hand hand1 = new Hand();

            hand1.addCard(_jackOfSpades);

            Assert.That(hand1.getCardsForTesting().Contains(_jackOfSpades));

            Hand hand2 = new Hand();

            hand2.addCard(_twoOfHearts);
            hand2.addCard(_threeOfClubs);

            Assert.That(hand2.getCardsForTesting().Contains(_twoOfHearts));
            Assert.That(hand2.getCardsForTesting().Contains(_threeOfClubs));
            Assert.That(!hand2.getCardsForTesting().Contains(_jackOfSpades));
        }

        [Test]
        public void aceCounter()
        {
            Hand handNoAce = new Hand();

            handNoAce.addCard(_twoOfHearts);
            handNoAce.addCard(_threeOfClubs);

            Hand handAce = new Hand();

            handAce.addCard(_aceOfSpades);

            Assert.That(handNoAce.getNrAcesForTesting() == 0);
            Assert.That(handAce.getNrAcesForTesting() == 1);
        }

        [Test]
        public void getDisplayString()
        {
            Hand hand = new Hand();

            foreach (Card card in _testCards)
            {
                hand.addCard(card);
            }

            string correctString = "Two of Hearts\n Three of Clubs\n Four of Spades\n Five of Diamonds" +
                                   "\n Six of Clubs\n Seven of Hearts\n Eight of Clubs\n Nine of Hearts\n Ten of Spades" +
                                   "\n Jack of Spades\n Queen of Diamonds\n King of Hearts\n Ace of Spades\n";

            Assert.That(hand.getDisplayString().Equals(correctString));
        }

        [Test]
        public void getTotal()
        {
            Hand handSimple = new Hand();
            handSimple.addCard(_fiveOfDiamonds);
            handSimple.addCard(_threeOfClubs);

            Assert.That(handSimple.getPoints() == 8);

            Hand handBigAce = new Hand();
            handBigAce.addCard(_aceOfSpades);
            handBigAce.addCard(_sevenOfHearts);

            Assert.That(handBigAce.getPoints() == 18);

            Hand handSmallAce = new Hand();
            handSmallAce.addCard(_queenOfDiamonds);
            handSmallAce.addCard(_kingOfHearts);
            handSmallAce.addCard(_aceOfSpades);

            Assert.That(handSmallAce.getPoints() == 21);

            Hand handMuliAce = new Hand();
            handMuliAce.addCard(_aceOfSpades);
            handMuliAce.addCard(new Card(Rank.Ace, Suit.Clubs));

            Assert.That(handMuliAce.getPoints() == 12);

            Hand handOver21 = new Hand();
            handOver21.addCard(_aceOfSpades);
            handOver21.addCard(new Card(Rank.Ace, Suit.Clubs));
            handOver21.addCard(_queenOfDiamonds);
            handOver21.addCard(_kingOfHearts);

            Assert.That(handOver21.getPoints() == 22);

        }
    }
}
