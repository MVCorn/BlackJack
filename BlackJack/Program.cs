// See https://aka.ms/new-console-template for more information

using BlackJack;
var card = new Card(Rank.Ace, Suit.Spades);

var points = card.getPoints();
var cardString = card.cardString();

Console.WriteLine(cardString + " points: " + points);
