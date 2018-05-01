
public class Hard : Mission
{
    private const double EnduranceConst = 80;
    private const double LevelDecrement = 70;
    private const string MissionName = "Disposal of terrorists";

    public Hard(double scoreToComplete)
        : base(scoreToComplete, EnduranceConst, LevelDecrement,MissionName)
    {
    }
}
