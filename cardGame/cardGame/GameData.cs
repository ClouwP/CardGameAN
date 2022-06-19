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
            new Card("DayChange",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),0,2)),
            new Card("FireBall",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),0,3)),
            new Card("DefensBitch",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),0,2)),
            new Card("HaloPortal",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),0,3)),
            new Card("HaloPortal",LandEnergieTypes.green,"🟢", new SpellCard(new Instantaneous(),0,3)),
            new Card("DragonGun",LandEnergieTypes.green,"🟢", new SpellCard(new Instantaneous(),0,4)),
            new Card("DemonPrison",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),0,5)),
            new Card("DarkSky",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),0,5)),
            new Card("DarkSky",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),0,5)),
            new Card("MouseTrap",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),0,2)),

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
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(),0,5)),
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(),0,5)),
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(),0,5)),
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
            new Card("DayChange",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),0,2)),
            new Card("FireBall",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),0,3)),
            new Card("DefensBitch",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),0,2)),
            new Card("HaloPortal",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),0,3)),
            new Card("FireBall",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),0,3)),
            new Card("DragonGun",LandEnergieTypes.green,"🟢", new SpellCard(new Instantaneous(),0,4)),
            new Card("DemonPrison",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),0,5)),
            new Card("DarkSky",LandEnergieTypes.brown,"🟤", new SpellCard(new Instantaneous(),0,5)),
            new Card("DefensBitch",LandEnergieTypes.blue,"🔵", new SpellCard(new Instantaneous(),0,2)),
            new Card("MouseTrap",LandEnergieTypes.red,"🔴", new SpellCard(new Instantaneous(),0,2)),

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
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(),0,5)),
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(),0,5)),
            new Card("DragonKnigt",LandEnergieTypes.red,"🔴", new SpellCard(new Artefact(),0,5)),
        };
    }


}