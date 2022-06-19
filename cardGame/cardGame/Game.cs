using System;
using System.Collections.Generic;


namespace cardGame
{
    public class Game : GameObserverInterface
    {
        private Player Player1;
        private Player Player2;
        private List<Card> DiscardPile = new List<Card>();
        private Board board;
        private int Round = 1;


        public Game()
        {
            var global = new Globals();
            Console.WriteLine("Player 1 cards");
            this.Player1 = new Player("Player 1", new Deck(global.Deck1));
            Console.WriteLine("Press any key to go next");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Player 2 cards");
            this.Player2 = new Player("Player 2", new Deck(global.Deck2));

            this.board = new Board();
            this.board.GenerateBoard();

            Console.WriteLine("Press any key to go next");
            Console.ReadLine();
            Console.Clear();

            this.StartGame();
        }

        public void StartGame()
        {
            Player[] currentPlayer = new Player[] { this.Player1, this.Player2 };

            while (this.Player1.GetHealt() > 0 && this.Player2.GetHealt() > 0 && this.Round <= 10)
            {
                Console.WriteLine("Round: {0}", this.Round);

                for (int i = 0; i < currentPlayer.Length; i++)
                {
                    this.DrawingFhase(currentPlayer[i]);
                    this.MainPhase(currentPlayer[i]);
                    this.EndingPhase(currentPlayer[i]);
                }

                this.PreparationFhase();
                this.Round += 1;
            }

        }


        public void PreparationFhase()
        {
            Console.WriteLine("PreparationFhase");

            //Removing the cards that are in effect
            Console.WriteLine("Removing the temporary effecs...");

            //Setting the card on the right place
            Console.WriteLine("Land Cards back to standby...");


            Console.WriteLine("Press any key to go next");
            Console.ReadLine();
            Console.Clear();

        }

        public void DrawingFhase(Player player)
        {
            Console.WriteLine("Current: {0}" , player.Name);
            Console.WriteLine("Press any key to go next");
            Console.ReadLine();


            //Getting a card form the deck
            if (this.Round != 1)
            {
                Console.WriteLine("DrawingFhase {0}");
                player.TakeCardFromDeck();
            }
        }

        public void MainPhase(Player player)
        {
            var menuIsRunning = true;


            while (menuIsRunning)
            {
                Console.WriteLine("MainPhase {0}", player.Name);
                Console.WriteLine();
                Console.WriteLine("Player LandEnergies");
                player.GetTotalEnergie();

                //GameBoard render
                this.board.ShowBoard();
                Console.WriteLine("Player 1 hearts: {0}", this.Player1.GetHearts());
                Console.WriteLine("Player 2 hearts: {0}", this.Player2.GetHearts());

                Console.WriteLine();
                Console.WriteLine("[0] End turn");
                Console.WriteLine("[1] Use Card");
                Console.WriteLine("[2] Show cards");
                Console.WriteLine();
                var input = Console.ReadLine();

                if (input == "1")
                {
                    var cardTest = player.PlaceCard(this.board);
                    Console.Clear();
                }
                else if (input == "0")
                {
                    menuIsRunning = false;
                    Console.Clear();
                }

                else if (input == "2")
                {
                    player.ShowCard();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("That is not a option!");
                    Console.Clear();
                }

            }




        }

        public void EndingPhase(Player player)
        {
            Console.WriteLine("EndingPhase {0}", player.Name);
        }

        public void EndGame()
        {
            Console.WriteLine("EndGame");
        }
    }
}
