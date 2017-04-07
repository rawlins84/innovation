using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Innovation
{
    public class Eras
    {
        private Deck[] eraDecks;

        public Eras()
        {
            // Initialize eraDecks Array
            eraDecks = Enumerable.Repeat(new Deck(), 10).ToArray();

            // Read in All cards, sort and shuffle
            string path = "cards.properties";
            string pattern = @"^\/\/";
            string line = "";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);


            FileStream fs = File.Open(path, FileMode.Open);
            System.IO.StreamReader file = new System.IO.StreamReader(fs);

            while ((line = file.ReadLine()) != null)
            {
                MatchCollection matches;
                matches = rgx.Matches(line);
                if (matches.Count == 0)
                {
                    Card newCard = new Card(line);

                    eraDecks[newCard.getEra()-1].rtnCard(newCard);
                }
            }
            foreach (Deck currEra in eraDecks)
            {
                currEra.shuffle();
            }
        }

        public List<Card> draw(int drawNum, int eraNum)
        {
            List<Card> rtn = new List<Card>();
            while (drawNum > 0 && eraNum < 10)
            {
                if (eraDecks[eraNum - 1].getLength() > 0)
                {
                    rtn.Add(eraDecks[eraNum - 1].draw());
                    drawNum --;
                }
                else
                {
                    eraNum ++;
                }
            }
            if (eraNum > 10)
            {
                //Helper.triggerWin();
            }
            return rtn;
        }
    }
}