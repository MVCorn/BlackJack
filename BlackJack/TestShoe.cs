using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class TestShoe : AbstractShoe
    {
        private Stack<Card> cards;
        public TestShoe(Card[] cardArray)
        {
            cards = new Stack<Card>(cardArray);
        }
    }
}
