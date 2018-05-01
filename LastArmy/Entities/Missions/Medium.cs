
public class Medium : Mission
{
    private const double EnduranceConst = 50;
    private const double LevelDecrement = 50;
    private const string MissionName = "Capturing dangerous criminals";

    public Medium(double scoreToComplete)
        : base(scoreToComplete, EnduranceConst, LevelDecrement,MissionName)
    {
    }
}

