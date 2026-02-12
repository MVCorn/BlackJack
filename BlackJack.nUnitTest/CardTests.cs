using NUnit.Framework;
namespace BlackJack.nUnitTest
{
    public class CardTests
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
        }

        [Test]
        public void cardInitPoints()
        {
            Assert.That(_twoOfHearts.getPoints() == 2);
            Assert.That(_threeOfClubs.getPoints() == 3);
            Assert.That(_fourOfSpades.getPoints() == 4);
            Assert.That(_fiveOfDiamonds.getPoints() == 5);
            Assert.That(_sixOfClubs.getPoints() == 6);
            Assert.That(_sevenOfHearts.getPoints() == 7);
            Assert.That(_eightOfClubs.getPoints() == 8);
            Assert.That(_nineOfHearts.getPoints() == 9);
            Assert.That(_tenOfSpades.getPoints() == 10);

            Assert.That(_jackOfSpades.getPoints() == 10);
            Assert.That(_queenOfDiamonds.getPoints() == 10);
            Assert.That(_kingOfHearts.getPoints() == 10);

            Assert.That(_aceOfSpades.getPoints() == 11);
        }

        [Test]
        public void getDisplayString()
        {
            Assert.That(_twoOfHearts.getDisplayString() == "Two of Hearts");
            Assert.That(_threeOfClubs.getDisplayString() == "Three of Clubs");
            Assert.That(_fourOfSpades.getDisplayString() == "Four of Spades");
            Assert.That(_fiveOfDiamonds.getDisplayString() == "Five of Diamonds");
            Assert.That(_sixOfClubs.getDisplayString() == "Six of Clubs");
            Assert.That(_sevenOfHearts.getDisplayString() == "Seven of Hearts");
            Assert.That(_eightOfClubs.getDisplayString() == "Eight of Clubs");
            Assert.That(_nineOfHearts.getDisplayString() == "Nine of Hearts");
            Assert.That(_tenOfSpades.getDisplayString() == "Ten of Spades");

            Assert.That(_jackOfSpades.getDisplayString() == "Jack of Spades");
            Assert.That(_queenOfDiamonds.getDisplayString() == "Queen of Diamonds");
            Assert.That(_kingOfHearts.getDisplayString() == "King of Hearts");

            Assert.That(_aceOfSpades.getDisplayString() == "Ace of Spades");
        }

        [Test]
        public void cardVisibility()
        {
            _twoOfHearts.hide();
            Assert.That(_twoOfHearts.getDisplayString() == "Hidden card");
            _twoOfHearts.show();
            Assert.That(_twoOfHearts.getDisplayString() == "Two of Hearts");
        }


    }
}
