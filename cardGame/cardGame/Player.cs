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
                Console.WriteLine("[1]: Place Landcard");
                Console.WriteLine("[2]: Place Permants");
                Console.WriteLine("[3]: Use Landcard");
                Console.WriteLine("[4]: Use SpellCards");
                Console.WriteLine("[5]: Cancel placement");

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

                    var LandCards = "";
                    var count = 0;
                    var listcount = 0;
                    var location = new List<Tuple<int, int>>();


                    for (int i = 0; i < this.CardsInHand.Count; i++)
                    {
                        if (this.CardsInHand[i].GetCardType() is SpellCard)
                        {
                            if ((this.CardsInHand[i].GetCardType() as SpellCard).TypeSpellCard is Permants)
                            {
                                if (this.CardsInHand[i].GetLandEnergieType().symbol == "🔴")
                                {
                                    if (this.LandEnergies[0].Total >= (this.CardsInHand[i].GetCardType() as SpellCard).GetEnergiePrice())
                                    {
                                        LandCards += $"[{count}] {this.CardsInHand[i].GetInfo()}\n";
                                        location.Add(Tuple.Create(count, listcount));
                                        count += 1;
                                    }
                                }

                                if (this.CardsInHand[i].GetLandEnergieType().symbol == "🔵")
                                {
                                    if (this.LandEnergies[1].Total >= (this.CardsInHand[i].GetCardType() as SpellCard).GetEnergiePrice())
                                    {
                                        LandCards += $"[{count}] {this.CardsInHand[i].GetInfo()}\n";
                                        location.Add(Tuple.Create(count, listcount));
                                        count += 1;
                                    }
                                }

                                if (this.CardsInHand[i].GetLandEnergieType().symbol == "⚪")
                                {
                                    if (this.LandEnergies[2].Total >= (this.CardsInHand[i].GetCardType() as SpellCard).GetEnergiePrice())
                                    {
                                        LandCards += $"[{count}] {this.CardsInHand[i].GetInfo()}\n";
                                        location.Add(Tuple.Create(count, listcount));
                                        count += 1;
                                    }
                                }

                                if (this.CardsInHand[i].GetLandEnergieType().symbol == "🟢")
                                {
                                    if (this.LandEnergies[3].Total >= (this.CardsInHand[i].GetCardType() as SpellCard).GetEnergiePrice())
                                    {
                                        LandCards += $"[{count}] {this.CardsInHand[i].GetInfo()}\n";
                                        location.Add(Tuple.Create(count, listcount));
                                        count += 1;
                                    }
                                }
                                if (this.CardsInHand[i].GetLandEnergieType().symbol == "🟤")
                                {
                                    if (this.LandEnergies[4].Total >= (this.CardsInHand[i].GetCardType() as SpellCard).GetEnergiePrice())
                                    {
                                        LandCards += $"[{count}] {this.CardsInHand[i].GetInfo()}\n";
                                        location.Add(Tuple.Create(count, listcount));
                                        count += 1;
                                    }
                                }
                            }
                        }

                        listcount += 1;
                    }

                    if (count != 0)
                    {

                        Console.WriteLine("Which Permants do you wand to place\n");

                        Console.WriteLine(LandCards);

                        try
                        {
                            var userinput = Convert.ToInt32(Console.ReadLine());
                            if (userinput < count)
                            {
                                var postions = board.GetOpenLandCards(this.Name);


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
                        Console.WriteLine("You don't have any Permants");
                        Console.WriteLine("Press any key to go next");
                        Console.ReadLine();
                    }
                }

                else if (userInput == "3")
                {
                    Console.Clear();
                    var cards = board.getLandCards(this.Name);

                    if (cards.Count > 0)
                    {
                        Console.WriteLine("This landCards you can use\n");

                        for (int i = 0; i < cards.Count; i++)
                        {
                            Console.WriteLine($"[{i}] {cards[i].GetInfo()}");
                        }

                        Console.WriteLine("\nWhich Landcard do you wand to use");
                        try
                        {
                            var userinput = Convert.ToInt32(Console.ReadLine());
                            if (userinput < cards.Count)
                            {
                                board.ActivateLandCard(cards[userinput], this.Name);
                                if (cards[userinput].UseCard() == "🔴")
                                {
                                    this.LandEnergies[0].Total += 1;
                                }
                                if (cards[userinput].UseCard() == "🔵")
                                {
                                    this.LandEnergies[1].Total += 1;
                                }
                                if (cards[userinput].UseCard() == "⚪")
                                {
                                    this.LandEnergies[2].Total += 1;
                                }
                                if (cards[userinput].UseCard() == "🟢")
                                {
                                    this.LandEnergies[3].Total += 1;
                                }
                                if (cards[userinput].UseCard() == "🟤")
                                {
                                    this.LandEnergies[4].Total += 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong input");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Wrong input");
                        }

                    }
                    else
                    {
                        Console.WriteLine("You don't have LandCard to use");
                        Console.WriteLine("Press any key to go next");
                        Console.ReadLine();
                    }

                    Console.Clear();
                }

                else if (userInput == "4")
                {
                    Console.Clear();
                    Console.WriteLine("This cards can you place");
                }

                else if (userInput == "5")
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
