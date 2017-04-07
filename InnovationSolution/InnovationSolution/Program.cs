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
        private static Eras EraDecks;
        private static Player[] Players;
        public static bool gameOver;
        static void Main(string[] args)
        {
            gameOver = false;

            Helper.log("Welcome to Innovation");
            Helper.log("  - Start Game:> start #(2-4 Players)");
            Helper.log("  - Exit:> exit");
            bool running = true;
            string input = "";
            while(running)
            {
                input = Console.ReadLine();
                String[] commands = input.Split(null);
                switch (commands[0])
                {
                    case "start":
                        startGame(Int32.Parse(commands[1]));
                        break;
                    case "exit":
                        running = false;
                        break;
                    default:
                        Helper.log("Invalid Input!!!");
                        break;
                }
            }
        }

        private static void setupDecks()
        {
            EraDecks = new Eras();
        }
        private static void gameEnd()
        {

        }

        private static void startGame(int numPlayers)
        {
            Random r = new Random();
            Helper.log("Loading Game");
            setupDecks();

            for (int i=0; i<numPlayers; i++)
            {
                Players[i] = new Player();
                Players[i].getHand().addCards(EraDecks.draw(2, 1));
            }
            Helper.log("Game Loaded");

            bool running = true;
            while(running && !Helper.getWin())
            {
                for (int action = 2; action > 0; action--)
                {
                    if (Helper.getWin())
                    {
                        break;
                    }
                    Console.WriteLine(action + " Actions remaining");
                    Console.WriteLine("You may do the following:");
                    Console.WriteLine("  -[Draw] a card from an era in yout tableau.");
                    Console.WriteLine("  -[Meld] a card from your hand to your tableau.");
                    Console.WriteLine("  -[Dogma] a top card on your tableau.");
                    Console.WriteLine("  -[Achieve] taking a card from the available achievements.");
                    Console.Write(":> ");
                }
                Console.Write("Please take your");
                Console.Write(":> ");
            }

            /*playerHand.addCard(Eras[0].draw());
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
                        Helper.log("You Drew "+ newCard.getTitle());
                        break;
                    case "hand":
                        playerHand.printCards();
                        break;
                    case "meld":
                        playerTab.meld(playerHand.)
                    case "exit":
                        running = false;
                        break;
                    default:
                        Helper.log("Invalid Input!!!");
                        break;
                }
            }*/
        }
    }
}
