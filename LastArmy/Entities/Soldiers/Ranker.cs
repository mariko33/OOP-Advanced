using System.Collections.Generic;
using System.Reflection.Emit;

public class Ranker : Soldier
{
    private const double IncreaseSkill = 1.5;
    private const double IncreaseEndurance = 10;

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, new List<string>{
                "Gun",
                "AutomaticMachine",
                "Helmet"})
    {

    }


    public override double OverallSkill => base.OverallSkill * IncreaseSkill;

    public override void Regenerate()
    {
        this.Endurance += IncreaseEndurance + this.Age;
    }
}
