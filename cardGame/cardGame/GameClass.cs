using System;
using System.Collections.Generic;

/*Achraf Faress  1007087
 * Younes Simouh 1005343*/


namespace cardGame
{




    public interface GameObserverInterface
    {
        public void update();
    }

    public sealed class Board
    {
        private Card[,] Placement = new Card[4, 6];
        private Board() { }
        private List<Tuple<Card, int, bool,string>> SpelsActive = new List<Tuple<Card, int, bool, string>>();
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


        public List<Tuple<int, int, string>> GetMyPermants(string player)
        {
            var location = new List<Tuple<int, int,string>>();

            if (player == "Player 1")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (this.Placement[i, j].Name != "Empty")
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null && (this.Placement[i, j].GetCardType() as LandCard).getPermants().getState())
                            {
                                location.Add(Tuple.Create(i, j, (this.Placement[i, j].GetCardType() as LandCard).getPermants().getInfo()));
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
                            if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null && (this.Placement[i, j].GetCardType() as LandCard).getPermants().getState())
                            {
                                location.Add(Tuple.Create(i, j, (this.Placement[i, j].GetCardType() as LandCard).getPermants().getInfo()));
                            }
                        }
                    }

                }
            }

            return location;
        }

        public List<Tuple<int, int, string>> GetEnimyPremants(string player)
        {
            var location = new List<Tuple<int, int, string>>();

            if (player == "Player 2")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (this.Placement[i, j].Name != "Empty")
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null )
                            {
                                location.Add(Tuple.Create(i, j, (this.Placement[i, j].GetCardType() as LandCard).getPermants().getInfo()));
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
                            if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                            {
                                location.Add(Tuple.Create(i, j, (this.Placement[i, j].GetCardType() as LandCard).getPermants().getInfo()));
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

        public bool CheckEnemy(string player)
        {
            if (player == "Player 1")
            {
                for (int i = 2; i < 4; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (this.Placement[i, j].Name != "Empty")
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                            {
                                return true;
                            }
                        }
                    }

                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (this.Placement[i, j].Name != "Empty")
                        {
                            if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                            {
                                return true;
                            }
                        }
                    }

                }
            }

            return false;
        }


        public void attackPermant(Tuple<int,int,string> permant, Tuple<int, int, string> yourMonster)
        {
            (this.Placement[permant.Item1, permant.Item2].GetCardType() as LandCard).getPermants().getDamage((this.Placement[permant.Item1, permant.Item2].GetCardType() as LandCard).getPermants().attack());

            if ((this.Placement[permant.Item1, permant.Item2].GetCardType() as LandCard).getPermants().getHealth() <= 0)
            {
                (this.Placement[permant.Item1, permant.Item2].GetCardType() as LandCard).setPermants(null);

                Console.WriteLine("Permants dead");
                Console.WriteLine("Press any key to go next");
                Console.ReadLine();
            }
        }

        public int GetPower(Tuple<int, int, string> permant)
        {
            return (this.Placement[permant.Item1,permant.Item2].GetCardType() as LandCard).getPermants().attack();
        }

        public void AddSpell(Card card, string player)
        {
            this.SpelsActive.Add(Tuple.Create(card, (card.GetCardType() as SpellCard).CardState, true, player));
        }

        public void CheckSpells()
        {
            var delter = new List<int>();

            for (int i = 0; i < this.SpelsActive.Count; i++)
            {
                if (SpelsActive[i].Item2 == 0)
                {
                    delter.Add(i);

                    if ((SpelsActive[i].Item1.GetCardType() as SpellCard).CardState == 1)
                    {
                        Restore(-1, -1, SpelsActive[i].Item4);
                    }
                    if ((SpelsActive[i].Item1.GetCardType() as SpellCard).CardState == 2)
                    {
                        Restore(0, 3, SpelsActive[i].Item4);
                    }
                    if ((SpelsActive[i].Item1.GetCardType() as SpellCard).CardState == 3)
                    {
                        Restore(3, 0, SpelsActive[i].Item4);
                    }
                }

                else if (SpelsActive[i].Item3) 
                {
                    SpelsActive[i] = Tuple.Create(SpelsActive[i].Item1, SpelsActive[i].Item2 - 1, false, SpelsActive[i].Item4);

                    if ((SpelsActive[i].Item1.GetCardType() as SpellCard).CardState == 1) { 

                        if ((SpelsActive[i].Item1.GetCardType() as SpellCard).TypeSpellCard is Instantaneous)
                        {
                            ChangePermats(-1, -1, SpelsActive[i].Item4);
                        }
                        else
                        {
                            ChangePermats(2, 2, SpelsActive[i].Item4);
                        }
                    }
                    if((SpelsActive[i].Item1.GetCardType() as SpellCard).CardState == 2)
                    {
                        if ((SpelsActive[i].Item1.GetCardType() as SpellCard).TypeSpellCard is Instantaneous)
                        {
                            ChangePermats(0, 3, SpelsActive[i].Item4);
                        }

                        else
                        {
                            ChangePermats(1, 1, SpelsActive[i].Item4);
                        }
                    }
                    if((SpelsActive[i].Item1.GetCardType() as SpellCard).CardState == 3)
                    {
                        if ((SpelsActive[i].Item1.GetCardType() as SpellCard).TypeSpellCard is Instantaneous)
                        {
                            ChangePermats(3, 0, SpelsActive[i].Item4);
                        }
                        else
                        {
                            ChangePermats(-2, -2, SpelsActive[i].Item4);
                        }
                    }
                }
                else
                {
                    SpelsActive[i] = Tuple.Create(SpelsActive[i].Item1, SpelsActive[i].Item2 - 1, false, SpelsActive[i].Item4);
                }
            }

            for (int i = delter.Count - 1; i >= 0; i--)
            {
                SpelsActive.RemoveAt(delter[i]);
            }
        }

        public void ChangePermats(int d, int p, String player)
        {
            if (d == 0)
            {
                if (player == "Player 1")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null )
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(p);
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(p);
                                }
                            }
                        }

                    }
                }
            }
            if (p == 0)
            {
                if (player == "Player 1")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(d);
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(d);
                                }
                            }
                        }

                    }
                }
            }
            if (d == -1)
            {
                if (player == "Player 2")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(1);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(1);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(1);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(1);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
                                }
                            }
                        }
                    }
                }
            }




            ///////////dwsdad
            if (d == 2)
            {
                if (player == "Player 2")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(2);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(2);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(2);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(2);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (d == 1)
            {
                if (player == "Player 2")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(1);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(1);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(1);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(1);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (d == -2)
            {
                if (player == "Player 2")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(2);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(2);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(2);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(2);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Restore(int d, int p, String player)
        {
            if (d == 0)
            {
                if (player == "Player 1")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(p);
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(p);
                                }
                            }
                        }

                    }
                }
            }
            if (p == 0)
            {
                if (player == "Player 1")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(d);
                                }
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                    Console.WriteLine("Permate Dead");
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(d);
                                }
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                    Console.WriteLine("Permate Dead");
                                }
                            }
                        }

                    }
                }
            }
            if (d == -1)
            {
                if (player == "Player 2")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(1);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(1);

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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(1);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(1);
                                }
                            }
                        }
                    }
                }
            }

            if (d == 2)
            {
                if (player == "Player 2")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(2);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(2);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(2);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(2);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (d == 1)
            {
                if (player == "Player 2")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(1);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(1);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().getDamage(1);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().delPower(1);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (d == -2)
            {
                if (player == "Player 2")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (this.Placement[i, j].Name != "Empty")
                            {
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(2);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(2);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
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
                                if ((this.Placement[i, j].GetCardType() as LandCard).getPermants() != null)
                                {
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addPower(2);
                                    (this.Placement[i, j].GetCardType() as LandCard).getPermants().addHealt(2);

                                    if ((this.Placement[i, j].GetCardType() as LandCard).getPermants().getHealth() <= 0)
                                    {
                                        (this.Placement[i, j].GetCardType() as LandCard).setPermants(null);
                                        Console.WriteLine("Permate Dead");
                                    }
                                }
                            }
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
