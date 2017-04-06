using System;
using System.Linq;
using System.Collections.Generic;

namespace Innovation
{
    public class Deck
    {
        //private Card[] cards;
        private List<Card> cards;
        private int era;

        public Deck()
        {
            cards = new List<Card>();
        }

        public int getLength()
        {
            return cards.Count();
        }

        public Card draw()
        {
            if (cards[0] != null)
            {
                Card rtn = cards[0];
                cards.RemoveAt(0);
                return rtn;
            }

            return null;
        }

        public void rtnCard(Card in_card)
        {
            cards.Add(in_card);
        }

        public void shuffle()
        {
            Random rng = new Random();

            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n+1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}