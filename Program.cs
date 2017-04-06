using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Innovation
{
    class Program
    {
        private static Deck[] Eras;
        private static Hand playerHand;
        static void Main(string[] args)
        {
            Eras = new Deck[10];
            playerHand = new Hand();

            for (int i=0; i<Eras.Count(); i++)
            {
                Eras[i] = new Deck();
            }
            log("Loading Innovation");
            setupGame();
            log("");
            log("Game Loaded");

            playerHand.addCard(Eras[0].draw());
            playerHand.addCard(Eras[0].draw());
            
            string input = "";
            bool running = true;
            while(running)
            {
                Console.Write(":> ");
                input = Console.ReadLine();
                String[] commands = input.Split(null);
                switch (commands[0])
                {
                    case "draw":
                        Card newCard = Eras[(int.Parse(commands[1])) - 1].draw();
                        playerHand.addCard(newCard);
                        log("You Drew "+ newCard.getTitle());
                        break;
                    case "hand":
                        playerHand.printCards();
                        break;
                    case "exit":
                        running = false;
                        break;
                    default:
                        log("Invalid Input!!!");
                        break;
                }
            }
        }

        private static void setupGame()
        {
            string path = "cards.properties";
            string pattern = @"^\/\/";
            string line = "";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);


            FileStream fs = File.Open(path, FileMode.Open);
            System.IO.StreamReader file = new System.IO.StreamReader(fs);

            while ((line = file.ReadLine()) != null)
            {
                MatchCollection matches = rgx.Matches(line);
                if (matches.Count == 0)
                {
                    Card newCard = new Card(line);

                    Eras[newCard.getEra()-1].rtnCard(newCard);
                }
            }
            foreach (Deck currEra in Eras)
            {
                currEra.shuffle();
            }
        }
    }
}
