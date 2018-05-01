
    public class Easy:Mission
    {
        private const double EnduranceConst = 20;
        private const double LevelDecrement = 30;
        private const string MissionName = "Suppression of civil rebellion";

        public Easy( double scoreToComplete) 
            : base(scoreToComplete, EnduranceConst,LevelDecrement,MissionName)
        {
        }
    }
