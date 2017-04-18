using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Deck
    {
        private List<Card> _deck;

        public Deck(Card[] cards)
        {
            _deck = cards.ToList<Card>();
        }

        public void TransferAt(int index, Deck targetDeck)
        {
            Card c = _deck[index];
            _deck.RemoveAt(index);
            targetDeck.Add(c);
        }

        public int Score()
        {
            return _deck.Sum(c => c.Value);
        }

        public bool Contains(Card c)
        {
            return _deck.Contains(c);
        }

        public void Add(Card c)
        {
            _deck.Add(c);
        }

        public bool IsEmpty()
        {
            return !_deck.Any();
        }
    }
}
