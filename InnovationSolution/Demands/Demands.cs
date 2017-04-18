using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardImporter;
using Game;

namespace Actions
{
    public class Demands
    {
        public static Card[] Draw(ref Card[] cards, int n)
        {
            Card[] drawn = new Card[n];
            Card[] remaining = new Card[cards.Length - n];
            int j = 0;
            for(int i = 0; i < cards.Length; i++)
            {
                if (i < n)
                {
                    drawn[i] = cards[i];
                }
                else
                {
                    remaining[j] = cards[i];
                    j++;
                }                
            }
            cards = remaining; //removes cards that were drawn from referenced deck
            return drawn;
        }

        public static Card DrawHighestValue(ref Card[] cards)
        {
            Card highestValueCard = cards[0];
            Card[] remaining = new Card[cards.Length - 1];
            for (int i = 0; i < cards.Length - 1; i++)
            {
                Card c = cards[i + 1];
                if (c.Value > highestValueCard.Value)
                {
                    remaining[i] = highestValueCard;
                    highestValueCard = c; 
                }
                else
                {
                    remaining[i] = c;
                }
            }

            cards = remaining;

            return highestValueCard;
        }
    }
}
