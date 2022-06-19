namespace cardGame
{
    public interface ILandState : LandObserver
    {
        void changeState();
    }


    public class LandCard : ICardType
    {
        private ILandState CardState = new StandbyState();
        private Permants Permants;

        public void UseCard()
        {

        }

        public string GetState()
        {
            if (this.CardState is UseState)
            {
                return "Rotated";
            }
            return "Straight";
        }
    }

    public class UseState : ILandState
    {
        public void changeState()
        {

        }
    }

    public class StandbyState : ILandState
    {
        public void changeState()
        {

        }
    }
}