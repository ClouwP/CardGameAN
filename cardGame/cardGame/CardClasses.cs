using System;
using System.Collections.Generic;

namespace cardGame
{
    public class Deck
    {
        private List<Card> Cards = new List<Card>();

        public Deck()
        {
            var factory = new CardCreator();
            
                for (int b = 0; b < 5; b++)
                {
                    this.Cards.Add(factory.Factroy("Artefact"));
                }
                for (int b = 0; b < 9; b++)
                {
                    this.Cards.Add(factory.Factroy("LandCard"));
                }
                for (int b = 0; b < 7; b++)
                {
                    this.Cards.Add(factory.Factroy("Instantaneous"));
                }
                for (int b = 0; b < 9; b++)
                {
                    this.Cards.Add(factory.Factroy("Pre"));
                }
            
        }

        public Card GiveCard()
        {
            var ramdom = new Random();
            int randomNumber = ramdom.Next(0, Cards.Count);

            var value = Cards[randomNumber];

            Console.WriteLine("Player recive the card named: {0}",value.Name);
            Cards.RemoveAt(randomNumber);

            return value;

        }


    }

    public class Card
    {
        public string Name;
        private LandEnergie LandEnergieType;
        private ICardType CardType;

        public Card(string name, LandEnergieTypes energieType, string symbol , ICardType cardType)
        {
            this.Name = name;
            this.LandEnergieType = new LandEnergie(energieType, symbol);
            this.CardType = cardType;
        }

        public string UseCard()
        {
            if (this.CardType is LandCard)
            {
                return this.LandEnergieType.symbol;
            }
            return "";
        }

        public string GetInfo()
        {
            if (CardType is LandCard)
            {
                return $"{LandEnergieType.symbol} LandCard: {this.Name}";
            }

            else
            {
                return $"{LandEnergieType.symbol} SpellCard: {this.Name}";
            }
        }

        public string GetState()
        {
            var value = (this.CardType as LandCard).GetState();
            return value;

        }

        public ICardType GetCardType() => this.CardType;
        public LandEnergie GetLandEnergieType() => this.LandEnergieType;

    }

    public enum LandEnergieTypes
    {
        colorLess,
        neutral,
        red,
        blue,
        green,
        white,
        brown
    }

    public class LandEnergie
    {
        public LandEnergieTypes Type;
        public int Total = 0;
        public string symbol;

        public LandEnergie(LandEnergieTypes type, string s)
        {
            this.Type = type;
            this.symbol = s;
        }
    }

    public interface ICardType
    {
        void UseCard();
    }

    

    public class SpellCard : ICardType
    {
        public ISpellCardType TypeSpellCard;
        public int CardState;
        private int EnergiePrice;

        public SpellCard(ISpellCardType spellCardType, int cardState, int enrgiePrice)
        {
            this.TypeSpellCard = spellCardType;
            this.CardState = cardState;
            this.EnergiePrice = enrgiePrice;
        }

        public void UseCard()
        {
            
        }

        public int GetEnergiePrice()
        {
            return EnergiePrice;
        }
    }

    public interface ISpellCardType
    {
        void ActavateSpell();
    }

    public class Artefact : ISpellCardType
    {
        public int Type;
        public bool active = false;

        public Artefact(int type)
        {
            this.Type = type;
        }
        public void ActavateSpell()
        {
            this.active = true;
        }
    }

    public class Instantaneous : ISpellCardType
    {
        private bool isUsed = false;
        private int effect = 1;

        public void ActavateSpell()
        {
            this.isUsed = true;
        }

        public int getEffect() => this.effect;
    }

    public class Permants : ISpellCardType
    {
        private int power;
        private int defense;
        private bool AtackMode = false;

        public Permants(int p, int d)
        {
            this.power = p;
            this.defense = d;
        }

        public void ActavateSpell()
        {
            AtackMode = true;
        }

        public void reset()
        {
            AtackMode = false;
        }

        public void getDamage(int damage)
        {
            this.defense -= damage;
        }

        public int getHealth()
        {
            return defense;
        }

        public bool getState()
        {
            return !AtackMode;
        }

        public string getInfo()
        {
            return $"P:{this.power}, D:{this.defense}";
        }

        public int attack()
        {
            AtackMode = true;
            return this.power;
        }

        public void addHealt(int health)
        {
            this.defense += health;
        }

        public void addPower(int power)
        {
            this.power += power;
        }

        public void delPower(int power)
        {
            this.power -= power;
        }
    }



}