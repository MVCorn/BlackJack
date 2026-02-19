using NUnit.Framework;
namespace BlackJack.nUnitTest
{
    public class CardTests
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

        [SetUp]
        public void Setup()
        {
            //Setup cards
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
            Assert.That(_twoOfHearts.GetPoints() == 2);
            Assert.That(_threeOfClubs.GetPoints() == 3);
            Assert.That(_fourOfSpades.GetPoints() == 4);
            Assert.That(_fiveOfDiamonds.GetPoints() == 5);
            Assert.That(_sixOfClubs.GetPoints() == 6);
            Assert.That(_sevenOfHearts.GetPoints() == 7);
            Assert.That(_eightOfClubs.GetPoints() == 8);
            Assert.That(_nineOfHearts.GetPoints() == 9);
            Assert.That(_tenOfSpades.GetPoints() == 10);

            Assert.That(_jackOfSpades.GetPoints() == 10);
            Assert.That(_queenOfDiamonds.GetPoints() == 10);
            Assert.That(_kingOfHearts.GetPoints() == 10);

            Assert.That(_aceOfSpades.GetPoints() == 11);
        }

        [Test]
        public void getDisplayString()
        {
            Assert.That(_twoOfHearts.GetDisplayString() == "Two of Hearts");
            Assert.That(_threeOfClubs.GetDisplayString() == "Three of Clubs");
            Assert.That(_fourOfSpades.GetDisplayString() == "Four of Spades");
            Assert.That(_fiveOfDiamonds.GetDisplayString() == "Five of Diamonds");
            Assert.That(_sixOfClubs.GetDisplayString() == "Six of Clubs");
            Assert.That(_sevenOfHearts.GetDisplayString() == "Seven of Hearts");
            Assert.That(_eightOfClubs.GetDisplayString() == "Eight of Clubs");
            Assert.That(_nineOfHearts.GetDisplayString() == "Nine of Hearts");
            Assert.That(_tenOfSpades.GetDisplayString() == "Ten of Spades");

            Assert.That(_jackOfSpades.GetDisplayString() == "Jack of Spades");
            Assert.That(_queenOfDiamonds.GetDisplayString() == "Queen of Diamonds");
            Assert.That(_kingOfHearts.GetDisplayString() == "King of Hearts");

            Assert.That(_aceOfSpades.GetDisplayString() == "Ace of Spades");
        }

        [Test]
        public void cardVisibility()
        {
            _twoOfHearts.Hide();
            Assert.That(_twoOfHearts.GetDisplayString() == "Hidden card");
            _twoOfHearts.Show();
            Assert.That(_twoOfHearts.GetDisplayString() == "Two of Hearts");
        }


    }
}
