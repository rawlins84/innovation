using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardImporter;

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
    }
}
