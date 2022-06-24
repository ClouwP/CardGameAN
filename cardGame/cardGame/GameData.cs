using System;

namespace cardGame
{
    public class Globals
    {
        public Card[] Deck1 = new Card[30]
        {
            //Permanets
            new Card("DragonKnigt",LandEnergieTypes.red, "🔴", new SpellCard(new Permants(3,2),0,5)),
            new Card("WaterDragon",LandEnergieTypes.blue,"🔵", new SpellCard(new Permants(1,3),0,3)),
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Permants(3,2),0,5)),
            new Card("MasterDemon",LandEnergieTypes.brown,"🟤", new SpellCard(new Permants(5,1),0,4)),
            new Card("AngleLeon",LandEnergieTypes.white,"⚪", new SpellCard(new Permants(2,2),0,3)),
            new Card("AngleLeon",LandEnergieTypes.white,"⚪", new SpellCard(new Permants(2,2),0,3)),
            new Card("MouseKing",LandEnergieTypes.green,"🟢", new SpellCard(new Permants(3,2),0,5)),
            new Card("CatThief",LandEnergieTypes.brown,"🟤", new SpellCard(new Permants(1,5),0,2)),

            //Instantaneous 
            new Card("DayChange",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),1,2)),
            new Card("FireBall",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),2,3)),
            new Card("DefensBitch",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),3,2)),
            new Card("HaloPortal",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),1,3)),
            new Card("HaloPortal",LandEnergieTypes.green,"🟢", new SpellCard(new Instantaneous(),1,3)),
            new Card("DragonGun",LandEnergieTypes.green,"🟢", new SpellCard(new Instantaneous(),2,4)),
            new Card("DemonPrison",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),1,5)),
            new Card("DarkSky",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),1,5)),
            new Card("DarkSky",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),1,5)),
            new Card("MouseTrap",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),3,2)),

            //Land
            new Card("MountenPlace",LandEnergieTypes.red,"🔴", new LandCard()),
            new Card("OceanPlace",LandEnergieTypes.blue,"🔵", new LandCard()),
            new Card("HellPace",LandEnergieTypes.brown,"🟤", new LandCard()),
            new Card("LandPlace",LandEnergieTypes.green,"🟢", new LandCard()),
            new Card("GodPlace",LandEnergieTypes.white,"⚪", new LandCard()),
            new Card("MountenPlace",LandEnergieTypes.red,"🔴", new LandCard()),
            new Card("OceanPlace",LandEnergieTypes.blue,"🔵", new LandCard()),
            new Card("HellPace",LandEnergieTypes.brown,"🟤", new LandCard()),
            new Card("LandPlace",LandEnergieTypes.green,"🟢", new LandCard()),

            //Artefact
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(1),0,5)),
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(1),0,5)),
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(1),0,5)),
        };

        public Card[] Deck2 = new Card[30]
        {
            //Permanets
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Permants(3,2),0,5)),
            new Card("WaterDragon",LandEnergieTypes.blue,"🔵", new SpellCard(new Permants(1,3),0,3)),
            new Card("WaterDragon",LandEnergieTypes.blue,"🔵", new SpellCard(new Permants(1,3),0,3)),
            new Card("MasterDemon",LandEnergieTypes.brown,"🟤", new SpellCard(new Permants(5,1),0,4)),
            new Card("MasterDemon",LandEnergieTypes.brown,"🟤", new SpellCard(new Permants(5,1),0,4)),
            new Card("AngleLeon",LandEnergieTypes.white,"⚪", new SpellCard(new Permants(2,2),0,3)),
            new Card("MouseKing",LandEnergieTypes.green,"🟢", new SpellCard(new Permants(3,2),0,5)),
            new Card("CatThief",LandEnergieTypes.brown,"🟤", new SpellCard(new Permants(1,5),0,2)),

            //Instantaneous 
            new Card("DayChange",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),1,2)),
            new Card("FireBall",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),2,3)),
            new Card("DefensBitch",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),3,2)),
            new Card("HaloPortal",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),1,3)),
            new Card("FireBall",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),2,3)),
            new Card("DragonGun",LandEnergieTypes.green,"🟢", new SpellCard(new Instantaneous(),2,4)),
            new Card("DemonPrison",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),1,5)),
            new Card("DarkSky",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),1,5)),
            new Card("DefensBitch",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),3,2)),
            new Card("MouseTrap",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),3,2)),

            //Land
            new Card("MountenPlace",LandEnergieTypes.red,"🔴", new LandCard()),
            new Card("OceanPlace",LandEnergieTypes.blue,"🔵", new LandCard()),
            new Card("HellPace",LandEnergieTypes.brown,"🟤", new LandCard()),
            new Card("LandPlace",LandEnergieTypes.green,"🟢", new LandCard()),
            new Card("GodPlace",LandEnergieTypes.white,"⚪", new LandCard()),
            new Card("GodPlace",LandEnergieTypes.white,"⚪", new LandCard()),
            new Card("OceanPlace",LandEnergieTypes.blue,"🔵", new LandCard()),
            new Card("HellPace",LandEnergieTypes.brown,"🟤", new LandCard()),
            new Card("LandPlace",LandEnergieTypes.green,"🟢", new LandCard()),

            //Artefact
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(1),1,5)),
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(1),2,5)),
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(1),3,5)),
        };


        public void ActaveteCard()
        {
            (Deck1[18].GetCardType() as LandCard).CurrentState = new NewState((Deck1[18].GetCardType() as LandCard));
            (Deck1[19].GetCardType() as LandCard).CurrentState = new NewState((Deck1[19].GetCardType() as LandCard));
            (Deck1[20].GetCardType() as LandCard).CurrentState = new NewState((Deck1[20].GetCardType() as LandCard));
            (Deck1[21].GetCardType() as LandCard).CurrentState = new NewState((Deck1[21].GetCardType() as LandCard));
            (Deck1[22].GetCardType() as LandCard).CurrentState = new NewState((Deck1[22].GetCardType() as LandCard));
            (Deck1[23].GetCardType() as LandCard).CurrentState = new NewState((Deck1[23].GetCardType() as LandCard));
            (Deck1[24].GetCardType() as LandCard).CurrentState = new NewState((Deck1[24].GetCardType() as LandCard));
            (Deck1[25].GetCardType() as LandCard).CurrentState = new NewState((Deck1[25].GetCardType() as LandCard));
            (Deck1[26].GetCardType() as LandCard).CurrentState = new NewState((Deck1[26].GetCardType() as LandCard));

            (Deck2[18].GetCardType() as LandCard).CurrentState = new NewState((Deck2[18].GetCardType() as LandCard));
            (Deck2[19].GetCardType() as LandCard).CurrentState = new NewState((Deck2[19].GetCardType() as LandCard));
            (Deck2[20].GetCardType() as LandCard).CurrentState = new NewState((Deck2[20].GetCardType() as LandCard));
            (Deck2[21].GetCardType() as LandCard).CurrentState = new NewState((Deck2[21].GetCardType() as LandCard));
            (Deck2[22].GetCardType() as LandCard).CurrentState = new NewState((Deck2[22].GetCardType() as LandCard));
            (Deck2[23].GetCardType() as LandCard).CurrentState = new NewState((Deck2[23].GetCardType() as LandCard));
            (Deck2[24].GetCardType() as LandCard).CurrentState = new NewState((Deck2[24].GetCardType() as LandCard));
            (Deck2[25].GetCardType() as LandCard).CurrentState = new NewState((Deck2[25].GetCardType() as LandCard));
            (Deck2[26].GetCardType() as LandCard).CurrentState = new NewState((Deck2[26].GetCardType() as LandCard));
        }
    }

    public class CardCreator
    {
        public string[] firstName = new string[30]
        {
            "Dark",
            "Light",
            "Neon",
            "Hell",
            "God",
            "Angle",
            "Drake",
            "Mocro",
            "Thinh",
            "slim",
            "Rik",
            "tim",
            "Hij",
            "Angry",
            "King",
            "Quen",
            "Lord",
            "Ext",
            "Limit",
            "Rik",
            "bas",
            "Than",
            "Money",
            "Fire",
            "Water",
            "Ice",
            "Winter",
            "Mounten",
            "Sword",
            "Shilde",
        };

        public string[] lastName = new string[30]
        {
            "Ball",
            "Block",
            "Drim",
            "Echt",
            "Vall",
            "Rise",
            "Age",
            "Month",
            "Day",
            "Ello",
            "This",
            "Etto",
            "Ditto",
            "Pokie",
            "Smile",
            "Change",
            "Defense",
            "Demon",
            "Angle",
            "Test",
            "bas",
            "Than",
            "Money",
            "Fire",
            "Water",
            "Ice",
            "Winter",
            "Mounten",
            "Sword",
            "Shilde",
        };

        public Tuple<LandEnergieTypes, string>[] types = new Tuple<LandEnergieTypes, string>[5]
        {
            Tuple.Create(LandEnergieTypes.red,"🔴"),
            Tuple.Create(LandEnergieTypes.blue,"🔵"),
            Tuple.Create(LandEnergieTypes.brown,"🟤"),
            Tuple.Create(LandEnergieTypes.white,"⚪"),
            Tuple.Create(LandEnergieTypes.green,"🟢")
        };


        public Card Factroy(string type)
        {
            var ramdom = new Random();
            var name = firstName[ramdom.Next(0, 29)] + lastName[ramdom.Next(0, 29)];
            var typei = types[ramdom.Next(0, 4)];

            if (type == "Artefact")
            {
                return new Card(name, typei.Item1, typei.Item2, new SpellCard(new Artefact(1), ramdom.Next(0, 3), ramdom.Next(0, 4)));
            }
            if (type == "Instantaneous")
            {
                return new Card(name, typei.Item1, typei.Item2, new SpellCard(new Instantaneous(), ramdom.Next(0, 3), ramdom.Next(0, 4)));
            }
            if (type == "LandCard")
            {
                var tijd =  new Card(name, typei.Item1, typei.Item2, new LandCard());
                (tijd.GetCardType() as LandCard).CurrentState = new NewState((tijd.GetCardType() as LandCard));
                return tijd;
            }
            else
            {
                return new Card(name, typei.Item1, typei.Item2, new SpellCard(new Permants(ramdom.Next(0, 4), ramdom.Next(0, 4)),ramdom.Next(0, 3), ramdom.Next(0, 4)));
            }
        }

    }
}