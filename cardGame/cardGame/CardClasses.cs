using System;
using System.Collections.Generic;

namespace cardGame
{
    public class Deck
    {
        private List<Card> Cards = new List<Card>();

        public Deck(Card[] cards)
        {
            for (int i = 0; i < 30; i++)
            {
                Cards.Add(cards[i]);
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
        private ISpellCardType TypeSpellCard;
        private int CardState;
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
    }

    public interface ISpellCardType
    {
        void ActavateSpell();
    }

    public class Artefact : ISpellCardType
    {
        public void ActavateSpell()
        {

        }
    }

    public class Instantaneous : ISpellCardType
    {
        private bool isUsed = false;
        private int effect = 1;

        public void ActavateSpell()
        {

        }
    }

    public class Permants : ISpellCardType
    {
        private int power;
        private int defense;

        public Permants(int p, int d)
        {
            this.power = p;
            this.defense = d;
        }

        public void ActavateSpell()
        {

        }
    }



}