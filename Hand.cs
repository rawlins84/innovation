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

        public Card meld(string inTitle)
        {
            var matches = cards.Where(p => p.getTitle() == inTitle);
            if (matches.Count() != 0)
            {
                
            }
            Card temp = new Card();
            return temp;
        }

        public void addCards(List<Card> in_cards)
        {
            foreach (Card c in in_cards)
            {
                cards.Add(c);
            }
        }
    }
}