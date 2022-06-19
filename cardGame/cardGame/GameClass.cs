using System;
using System.Collections.Generic;

namespace cardGame
{




    public interface GameObserverInterface
    {

    }

    public class Board
    {
        private Card[,] Placement = new Card[4, 6];

        public void GenerateBoard()
        {
            for (int i = 0; i < Placement.GetLength(0); i++)
            {

                for (int j = 0; j < Placement.GetLength(1); j++)
                {
                    Placement[i, j] = new Card("Empty", LandEnergieTypes.colorLess, "X", new LandCard());

                }
            }
        }

        public void ShowBoard()
        {
            string board = "Player 1 field \n";

            for( int i = 0; i < Placement.GetLength(0); i++)
            {
                board += "[ | ";


                // Name
                for (int j = 0; j < Placement.GetLength(1); j++)
                {
                    if (Placement[i, j].Name == "Empty")
                    {
                        board += " " + Placement[i, j].Name + "  | ";
                    }
                    else
                    {
                        board += Placement[i, j].Name.Substring(0, 8) + " | ";
                    }

                }

                board += "] \n";
                board += "[ | ";


                //State
                for (int j = 0; j < Placement.GetLength(1); j++)
                {

                    if (Placement[i, j].Name == "Empty")
                    {
                        board += " " + Placement[i, j].Name + "  | ";
                    }
                    else
                    {
                        board += Placement[i, j].GetState() + " | ";
                    }


                }

                board += "] \n";
                board += "[ | ";


                //Monster
                for (int j = 0; j < Placement.GetLength(1); j++)
                {
                    board += " " +  Placement[i, j].Name + "  | ";

                }

                board += "] \n";
                board += "[ | ";


                //Power
                for (int j = 0; j < Placement.GetLength(1); j++)
                {

                    board += " " + Placement[i, j].Name + "  | ";

                }

                board += "] \n";
                board += "[ | ";


                //End
                for (int j = 0; j < Placement.GetLength(1); j++)
                {

                    board += "------- | ";

                }

                board += "] \n";
            }

            board += "Player 2 field\n";
            Console.WriteLine(board);
        }

        public void PlaceCard(int x, int b, Card card)
        {
            this.Placement[x, b] = card;
        }

        public List<Tuple<int, int>> GetOpenPlace(string player)
        {
            var location = new List<Tuple<int, int>>();

            if (player == "Player 1")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (this.Placement[i,j].Name == "Empty")
                        {
                            location.Add(Tuple.Create(i, j));
                        }
                    }

                }

            }
            else
            {
                for (int i = 2; i < 4; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (this.Placement[i, j].Name == "Empty")
                        {
                            location.Add(Tuple.Create(i, j));
                        }
                    }

                }
            }

            return location;
        }
    }

    public interface LandObserver
    {

    }
}
