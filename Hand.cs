using System;
using System.Linq;
using System.Collections.Generic;

namespace Innovation
{
    public class Hand
    {
        private List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        public void printCards()
        {
            foreach (Card card in cards)
            {
                Helper.log(card.getTitle());   
            }
        }

        public void addCard(Card in_card)
        {
            cards.Add(in_card);
        }
    }
}