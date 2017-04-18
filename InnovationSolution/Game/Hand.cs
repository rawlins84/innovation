using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Hand
    {
        private List<Card> _hand;

        public Hand(Card[] cards)
        {
            _hand = cards.ToList<Card>();
        }

        public void TransferAt(int index, Hand targetHand)
        {
            Card c = _hand[index];
            _hand.RemoveAt(index);
            targetHand.Add(c);
        }

        public bool Contains(Card c)
        {
            return _hand.Contains(c);
        }

        public void Add(Card c)
        {
            _hand.Add(c);
        }

        public bool IsEmpty()
        {
            return !_hand.Any();
        }
    }
}
