using NUnit.Framework;
namespace BlackJack.nUnitTest
{
    public class DealersShoeTests
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

        private DealersShoe _dealersShoe;
        private Card[] _dealersShoeCards;

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

            _dealersShoe = new DealersShoe();
            _dealersShoeCards = _dealersShoe.GetCardsArrayForTesting();
        }

        [Test]
        public void dealersShoeCorrectSize()
        {
            Assert.That(_dealersShoeCards.Length == 52);
        }

        [Test]
        public void dealersShoeContainsTestCards()
        {
            foreach (Card tCard in _testCards)
            {
                bool cardExists = Array.Exists(_dealersShoeCards, dCard => dCard.Equals(tCard));
                Assert.That(cardExists);
            }
        }

        [Test]
        public void takeCardRemovesCard()
        {
            Card card = _dealersShoe.TakeCard();
            int cardsInShoe = _dealersShoe.GetCardsArrayForTesting().Length;
            Console.WriteLine(cardsInShoe);
            Assert.That(cardsInShoe == 51);
        }
    }
}
