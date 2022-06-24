using System;
using System.Collections.Generic;

namespace cardGame
{




    public interface GameObserverInterface
    {

    }

    public sealed class Board
    {
        private Card[,] Placement = new Card[4, 6];
        private Board() { }
        private static Board instance = null;

        public static Board Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Board();
                }
                return instance;
            }
        }

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
                    if ((Placement[i, j].GetCardType() as LandCard).getPermants() == null)
                    {
                        board += " " + "Empty" + "  | ";
                    }
                    else
                    {
                        board += "Monster" + " | ";
                    }

                }

                board += "] \n";
                board += "[ | ";


                //Power
                for (int j = 0; j < Placement.GetLength(1); j++)
                {

                    if((Placement[i, j].GetCardType() as LandCard).getPermants() == null)
                    {
                        board += " " + "Empty" + "  | ";
                    }
                    else
                    {
                        board += (Placement[i, j].GetCardType() as LandCard).getPermants().getInfo() + " | ";
                    }

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
            if(card.GetCardType() is LandCard)
            {
                this.Placement[x, b] = card;
            }
            else
            {
                (this.Placement[x, b].GetCardType() as LandCard).setPermants(((card.GetCardType() as SpellCard).TypeSpellCard as Permants));
            }

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


        public List<Tuple<int, int>> GetOpenLandCards(string player)
        {
            var location = new List<Tuple<int, int>>();

            if (player == "Player 1")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (this.Placement[i, j].Name != "Empty")
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() == null )
                            {
                                location.Add(Tuple.Create(i, j));
                            }
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
                        if (this.Placement[i, j].Name != "Empty")
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() == null)
                            {
                                location.Add(Tuple.Create(i, j));
                            }
                        }
                    }

                }
            }

            return location;
        }

        public List<Card> getLandCards(string player)
        {

            var location = new List<Card>();

            if (player == "Player 1")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (this.Placement[i, j].Name != "Empty")
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).CurrentState is StandbyState)
                            {
                                location.Add(this.Placement[i, j]);
                            }

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
                        if (this.Placement[i, j].Name != "Empty")
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).CurrentState is StandbyState)
                            {
                                location.Add(this.Placement[i, j]);
                            }

                        }
                    }

                }
            }

            return location;
        }


        public void ActivateLandCard(Card card, string player)
        {
            bool find = false;

            if (player == "Player 1")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (this.Placement[i, j].Name == card.Name)
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).CurrentState is StandbyState && find == false)
                            {
                                find = true;
                                (this.Placement[i, j].GetCardType() as LandCard).UseCard();
                            }
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
                        if (this.Placement[i, j].Name == card.Name)
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).CurrentState is StandbyState && find == false)
                            {
                                find = true;
                                (this.Placement[i, j].GetCardType() as LandCard).UseCard();
                            }
                        }
                    }

                }
            }
        }

        //Tijdelijk
        public void CheckLandCards()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (this.Placement[i, j].Name != "Empty")
                    {
                        if ((this.Placement[i, j].GetCardType() as LandCard).CurrentState is UseState || (this.Placement[i, j].GetCardType() as LandCard).CurrentState is NewState)
                        {
                            (this.Placement[i, j].GetCardType() as LandCard).StandbyCard();
                        }
                    }
                }

            }
        }
    }

    public interface LandObserver
    {

    }
}
