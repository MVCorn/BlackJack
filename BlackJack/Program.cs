// See https://aka.ms/new-console-template for more information

using BlackJack;


Card twoOfHearts = new Card(Rank.Two, Suit.Hearts);
Card threeOfClubs = new Card(Rank.Three, Suit.Clubs);
Card fourOfSpades = new Card(Rank.Four, Suit.Spades);

Card kingOfHearts = new Card(Rank.King, Suit.Hearts);

Card aceOfSpades = new Card(Rank.Ace, Suit.Spades);

Hand hand = new Hand();
hand.addCard(twoOfHearts);
hand.addCard(threeOfClubs);
hand.addCard(fourOfSpades);

Console.WriteLine(hand.getDisplayString());


