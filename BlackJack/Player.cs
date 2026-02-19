using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Player
    {
        string name { get; }
        List<Hand> hands;
        int funds;

        public Player(string name, int funds)
        {
            this.name = name;
            this.hands = new List<Hand>();
            this.funds = funds;
        }

        public void AddHand(Hand hand)
        {
            hands.Add(hand);
        }

        public void AddFunds(int income)
        {
            funds += income;
        }

        public void removeFunds(int loss)
        {
            funds -= loss;
        }
    }
}

