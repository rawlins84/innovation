using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;

namespace Innovation
{
    public class Card
    {
        private int[] symbols = new int[6];
        private int era;
        private int color;
        private string title;
        private Dogma dogma;

        public Card(string in_title, int in_color, int in_era, int[] in_symbols)
        {
            title = in_title;
            color = in_color;
            era = in_era;

            symbols[0] = 5;
            symbols[1] = 4;
            symbols[2] = 3;
            symbols[3] = 2;
            symbols[4] = 1;
            symbols[5] = 0;
            dogma = new Dogma();
        }

        public Card(string propLine)
        {
            List<string> props = propLine.Split(',').ToList<string>();
            title = props[0].Replace('_',' ');
            color = Int32.Parse(props[1]);
            era = Int32.Parse(props[2]);
            symbols[0] = Int32.Parse(props[3]);
            symbols[1] = Int32.Parse(props[4]);
            symbols[2] = Int32.Parse(props[5]);
            symbols[3] = Int32.Parse(props[6]);
            dogma = new Dogma();
        }

        public string getTitle()
        {
            return title;
        }
        public int getColor()
        {
            return color;
        }
        public int getEra()
        {
            return era;
        }
        public int[] getSymbols()
        {
            return symbols;
        }

        public int getSymbolCount(int type)
        {
            int count = 0;
            foreach (int symbol in symbols)
            {
                if (symbol == type)
                {
                    count++;
                }
            }
            return count;
        }

        public void Dogma()
        {
            dogma.run(title);
            return;
        }
    }
}