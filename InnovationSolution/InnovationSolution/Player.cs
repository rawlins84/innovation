using System;
using System.Linq;
using System.Collections.Generic;

namespace Innovation
{
    public class Player
    {
        private Hand hand;
        private Tableau tableau;
        private Deck scorePile;
        private Deck acheivements;

        public Player()
        {
            hand = new Hand();
            tableau = new Tableau();
            scorePile = new Deck();
            acheivements = new Deck();
        }

        public Hand getHand()
        {
            return hand;
        }
        public Tableau getTableau()
        {
            return tableau;
        }
        public Deck getScorePile()
        {
            return scorePile;
        }
        public Deck getAchievements()
        {
            return acheivements;
        }
    }
}