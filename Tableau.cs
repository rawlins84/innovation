using System;
using System.Linq;
using System.Collections.Generic;

namespace Innovation
{
    public class Tableau
    {
        List<Card>[] stacks;
        public Tableau()
        {
            stacks = new List<Card>[5];
            for (int i = 0; i < stacks.Count(); i++)
            {
                stacks[i] = new List<Card>();
            }
        }

        public void meld(Card inCard)
        {
            stacks[inCard.getColor()].Insert(0,inCard);
        }

        public void tuck(Card inCard)
        {

        }

        public void splay(int stack, int dir)
        {}

        public void dogma(int stack)
        {}

        public Card rtnCard(int stack)
        {
            Card rtn = new Card();
            return rtn;
        }

        public void list(int stack)
        {
            foreach (Card c in stacks[stack])
            {
                Helper.log(c.getTitle());
            }
                
        }
    }
}