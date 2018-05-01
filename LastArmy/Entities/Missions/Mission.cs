
public abstract class Mission : IMission
{
    public Mission(double scoreToComplete, double enduranceRequired, double wearLevelDecrement,string name)
    {
        this.Name = name;
        this.ScoreToComplete = scoreToComplete;
        this.EnduranceRequired = enduranceRequired;
        this.WearLevelDecrement = wearLevelDecrement;
    }

    public string Name { get; }
    public double EnduranceRequired { get; } //constant
    public double ScoreToComplete { get; }
    public double WearLevelDecrement { get; } //const


}
