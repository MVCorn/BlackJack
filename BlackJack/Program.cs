// See https://aka.ms/new-console-template for more information

using BlackJack;
var card = new Card(Rank.Ace, Suit.Spades);

var points = card.getPoints();
var cardDisplayString = card.getDisplayString();

Console.WriteLine(cardDisplayString + " points: " + points);

var dealersShoe = new DealersShoe();

bool shouldBeTrue = Array.Exists(dealersShoe.getCardsArrayForTesting(), dCard => dCard.Equals(card));

Console.WriteLine(shouldBeTrue);

//foreach(Card dCard in dealersShoe.getCardsArrayForTesting())
//{
//    Console.WriteLine(dCard.getDisplayString());
//}

Console.WriteLine(dealersShoe.getCardsArrayForTesting().Length);
dealersShoe.takeCard();
Console.WriteLine(dealersShoe.getCardsArrayForTesting().Length);
