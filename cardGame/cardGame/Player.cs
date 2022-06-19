using System;
using System.Collections.Generic;


namespace cardGame
{
    public class Player
    {
        private Deck Deck;
        private int Health = 10;
        private List<LandEnergie> LandEnergies = new List<LandEnergie>() {
            new LandEnergie(LandEnergieTypes.red, "🔴"),
            new LandEnergie(LandEnergieTypes.blue, "🔵"),
            new LandEnergie(LandEnergieTypes.white, "⚪"),
            new LandEnergie(LandEnergieTypes.green, "🟢"),
            new LandEnergie(LandEnergieTypes.brown, "🟤"),
        };
        private List<Card> CardsInHand = new List<Card>();
        public string Name;

        public Player(string name, Deck deck)
        {
            this.Deck = deck;
            this.Name = name;

            for (int i = 0; i < 7; i++)
            {
                CardsInHand.Add(this.Deck.GiveCard());
            }
        }


        public Card PlaceCard(Board board)
        {
            var menuisRunning = true;
            while (menuisRunning)
            {
                Console.Clear();
                Console.WriteLine("[1]: Use Landcard");
                Console.WriteLine("[2]: Use SpellCard");
                Console.WriteLine("[3]: Cancel placement");

                var userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    var LandCards = "";
                    var count = 0;
                    var listcount = 0;
                    var location = new List<Tuple<int, int>>();

                    Console.Clear();
                    for (int i = 0; i < this.CardsInHand.Count; i++)
                    {
                        if (this.CardsInHand[i].GetCardType() is LandCard)
                        {
                            LandCards += $"[{count}] {this.CardsInHand[i].GetInfo()}\n";

                            location.Add(Tuple.Create(count, listcount));
                            count += 1;
                        }

                        listcount += 1;
                    }

                    if (count != 0)
                    {
                    
                        Console.WriteLine("Which landcard do you wand to place\n");

                        Console.WriteLine(LandCards);

                        try
                        {
                            var userinput = Convert.ToInt32(Console.ReadLine());
                            if (userinput < count)
                            {
                                var postions = board.GetOpenPlace(this.Name);


                                for (int i = 0; i < postions.Count; i++)
                                {
                                    Console.WriteLine($"[{i}] Postion {postions[i].Item1 + 1}.{postions[i].Item2 + 1}");
                                }

                                try
                                {
                                    var postioninput = Convert.ToInt32(Console.ReadLine());

                                    if (postioninput < postions.Count)
                                    {
                                        board.PlaceCard(postions[postioninput].Item1, postions[postioninput].Item2, this.CardsInHand[location[userinput].Item2]);
                                        this.CardsInHand.RemoveAt(location[userinput].Item2);

                                        menuisRunning = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not a option");
                                        Console.WriteLine("Press any key to go next");
                                        Console.ReadLine();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Incorrect input");
                                    Console.WriteLine("Press any key to go next");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Not a option");
                                Console.WriteLine("Press any key to go next");
                                Console.ReadLine();
                            }
                            
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Incorrect input");
                            Console.WriteLine("Press any key to go next");
                            Console.ReadLine();
                        }


                    }
                    else
                    {
                        Console.WriteLine("You don't have any landcards");
                        Console.WriteLine("Press any key to go next");
                        Console.ReadLine();
                    }



                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    Console.WriteLine("This cards can you place");
                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    menuisRunning = false;
                }

            }

            return null;
        }


        public void ShowCard()
        {
            Console.WriteLine("Your cards\n");
            for (int i = 0; i < this.CardsInHand.Count; i++)
            {
                Console.WriteLine(CardsInHand[i].GetInfo());

            }
            Console.WriteLine("Press any key to go next");
            Console.ReadLine();
            Console.Clear();
        }

        public void TakeCardFromDeck()
        {
            this.Deck.GiveCard();
        }

        public int GetHealt() => this.Health;

        public string GetHearts()
        {
            var hearts = "";

            for (int i = 0; i < GetHealt(); i++)
            {
                hearts += "❤️";
            }

            return hearts;
        }

        public void GetTotalEnergie()
        {
            var energie = "";

            for (int i = 0; i < this.LandEnergies.Count; i++)
            {
                energie += this.LandEnergies[i].symbol + ": " + this.LandEnergies[i].Total + "\n";

            }

            Console.WriteLine(energie);
        }
    }
}
