namespace cardGame
{
    public abstract class LandState : LandObserver
    {
        protected LandCard landcard;

        public LandState(LandCard landCard)
        {
            this.landcard = landCard;
        }

        public abstract void Activate();
        public abstract void Use();
        public abstract void Standby();
    }




    public class LandCard : ICardType
    {
        private LandState CardState;
        private Permants Permants;

        public void UseCard()
        {
            this.CardState.Use();
        }

        public void StandbyCard()
        {
            this.CardState.Standby();
        }

        public string GetState()
        {
            if (this.CardState is UseState)
            {
                return "Rotated";
            }
            else if (this.CardState is NewState) {
                return "Loading";
            }
            else
            {
                return "Straight";
            }
            
        }

        public Permants getPermants()
        {
            return this.Permants;
        }

        public void setPermants(Permants per)
        {
            this.Permants = per;
        }

        public LandState CurrentState
        {
            get { return CardState; }
            set { CardState = value; }
        }
    }





    public class UseState : LandState
    {

        public UseState(LandCard landCard) : base(landCard)
        {

        }

        public override void Activate()
        {
            System.Console.WriteLine("Card not go back to Activate state");
        }

        public override void Standby()
        {
            this.landcard.CurrentState = new StandbyState(this.landcard);
        }

        public override void Use()
        {
            System.Console.WriteLine("Card is al used");
        }
    }

    public class NewState : LandState
    {
        public NewState(LandCard landCard) : base(landCard)
        {

        }

        public override void Activate()
        {
            System.Console.WriteLine("Card not go back to Activate state");
        }

        public override void Standby()
        {
            this.landcard.CurrentState = new StandbyState(this.landcard);
        }

        public override void Use()
        {
            System.Console.WriteLine("Need to wait a round");
        }

    }

    public class StandbyState : LandState
    {
        public StandbyState(LandCard landCard) : base(landCard)
        {

        }

        public override void Activate()
        {
            System.Console.WriteLine("Card not go back to Activate state");
        }

        public override void Standby()
        {
            
        }

        public override void Use()
        {
            this.landcard.CurrentState = new UseState(this.landcard);
        }
    }
}