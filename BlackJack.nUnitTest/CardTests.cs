using NUnit.Framework;
namespace BlackJack.nUnitTest
{
    public class CardTests
    {
        private Card _twoOfHearts;
        private Card _threeOfClubs;
        private Card _fourOfSpades;
        private Card _fiveOfDimonds;
        private Card _sixOfClubs;
        private Card _sevenOfHearts;
        private Card _eightOfClubs;
        private Card _nineOfHearts;
        private Card _jackOfSpades;
        private Card _queenOfDimonds;
        private Card _kingOfHearts;
        private Card _aceOfSpades;

        [SetUp]
        public void Setup()
        {
            _twoOfHearts = new Card(Rank.Two, Suit.Hearts);
            _threeOfClubs = new Card(Rank.Three, Suit.Clubs);
            _fourOfSpades = new Card(Rank.Four, Suit.Spades);
            _fiveOfDimonds = new Card(Rank.Five, Suit.Dimonds);
            _sixOfClubs = new Card(Rank.Six, Suit.Clubs);
            _sevenOfHearts = new Card(Rank.Seven, Suit.Hearts);
            _eightOfClubs = new Card(Rank.Eight, Suit.Clubs);
            _nineOfHearts = new Card(Rank.Nine, Suit.Hearts);
            _jackOfSpades = new Card(Rank.Jack, Suit.Spades);
            _queenOfDimonds = new Card(Rank.Queen, Suit.Dimonds);
            _kingOfHearts = new Card(Rank.King, Suit.Hearts);
            _aceOfSpades = new Card(Rank.Ace, Suit.Spades);
        }

        [Test]
        public void cardInitPoints()
        {
            Assert.That(_twoOfHearts.getPoints() == 2);
            Assert.That(_threeOfClubs.getPoints() == 3);
            Assert.That(_fourOfSpades.getPoints() == 4);
            Assert.That(_fiveOfDimonds.getPoints() == 5);
            Assert.That(_sixOfClubs.getPoints() == 6);
            Assert.That(_sevenOfHearts.getPoints() == 7);
            Assert.That(_eightOfClubs.getPoints() == 8);
            Assert.That(_nineOfHearts.getPoints() == 9);
            Assert.That(_jackOfSpades.getPoints() == 10);
            Assert.That(_queenOfDimonds.getPoints() == 10);
            Assert.That(_kingOfHearts.getPoints() == 10);
            Assert.That(_aceOfSpades.getPoints() == 11);
        }


    }
}
