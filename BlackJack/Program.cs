// See https://aka.ms/new-console-template for more information

using BlackJack;
var card = new Card(Rank.Ace, Suit.Spades);

var points = card.getPoints();

Console.WriteLine("Ace of spades points: " + points);
