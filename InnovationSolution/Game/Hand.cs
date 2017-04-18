using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Hand : Deck
    {
        private string _name;
        public Hand(string name, Card[] cards) : base(cards)
        {
            _name = name;
        }
    }
}
