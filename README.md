# BlackJack

A console-based Blackjack game written in C# (.NET 10).

## Getting Started

```cmd
dotnet run --project BlackJack
```

## How to Play

Once the game is running, follow the prompts:
- **h** — Hit (draw a card)
- **s** — Stand (end your turn)

The dealer hits on 16 or less and stands on 17 or more. The game detects all standard outcomes: Blackjack, bust, standoff, and win/loss by points.

## Project Structure

```mermaid

classDiagram
	direction LR
	class Rank {
	<<enumeration>>
	Two
	Three
	Four
	Five
	Six
	Seven
	Eight
	Nine
	Ten
	Jack
	Queen
	King
	Ace
	}
	
	class Suit {
	<<enumeration>>
	Clubs
	Diamonds
	Hearts
	Spades
	}
	
	class Card {
	Rank rank
	Suit suit
	bool visible
	int points
	getPoints()
	getDisplayString
	hide()
	show()
	}
	
	class DealersShoe {
	Stack~Card~ cards
	-shuffel()
	takeCard()
	getCardArrayForTesting()
	}
	
	class Hand {
	List~Card~ cards
	int nrAces
	int totalPoint
	addCard(Card)
	-calculatePoints()
	getPoints()
	getNrCards()
	getDisplayString()
	getCardsForTesting()
	}
	
	class PositionState {
	<<enumeration>>
	Win
	Lose
	Bust
	DealerBust
	BlackJack
	DealerBlackJack
	BothBlackJack
	Standoff
	ERROR
	}
	
	class Position {
	Hand dealerHand
	Hand playerHand
	positionSate state
	addDealerCard(Card)
	addPlayerCard(Card)
	-comparePositions()
	getPositionState()
	getDisplayString()
	}
	
	class Game {
	Position position
	DealersShoe shoe
	startGame()
	}
	
	Card ..> Rank
	Card ..> Suit
	DealersShoe o-- Card
	Hand o-- Card
	Position ..> PositionState
	Position *-- Hand
	Game *-- Position
	Game *-- DealersShoe
```

```
BlackJack/
├── Card.cs           # Card model (rank, suit, point value, visibility)
├── Hand.cs           # Hand of cards with Ace adjustment logic
├── DealersShoe.cs    # Shuffled deck (52 cards)
├── Position.cs       # Game engine and state machine
├── Game.cs           # UI loop and user input handling
├── Player.cs         # Player model (funds, hands) (For future expansion)
└── Program.cs        # Entry point

BlackJack.nUnitTest/
├── CardTests.cs
├── HandTests.cs
├── DealersShoeTests.cs
├── PositionTest.cs
└── PlayerTests.cs
```

## Rules Implemented

- Aces count as 11, reduced to 1 if the hand would bust
- Blackjack is 21 with exactly 2 cards
- Dealer's second card is hidden until the round ends
- Possible outcomes: Win, Lose, Bust, Dealer Bust, Blackjack, Dealer Blackjack, Both Blackjack, Standoff

## Running Tests

```cmd
dotnet test
```
