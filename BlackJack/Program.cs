// See https://aka.ms/new-console-template for more information

using BlackJack;

DealersShoe dealersShoe = new DealersShoe();

Card[] cards = { new Card(Rank.Nine, Suit.Diamonds), new Card(Rank.Nine, Suit.Diamonds), new Card(Rank.Nine, Suit.Diamonds), new Card(Rank.Nine, Suit.Diamonds) };

TestShoe testShoe = new TestShoe(cards);

Game game = new Game(dealersShoe);

game.StartGame();


