using System.Collections.Generic;
using System.Reflection.Emit;

public class Ranker : Soldier
{
    private const double IncreaseSkill = 1.5;
    private const double IncreaseEndurance = 10;

    private List<string> weaponsAllowed = new List<string>()
    {
        "Gun",
        "AutomaticMachine",
        "Helmet"
    };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {

    }


    public override double OverallSkill => base.OverallSkill * IncreaseSkill;

    protected override List<string> WeaponsAllowed => this.weaponsAllowed;

    public override void Regenerate()
    {
        this.Endurance += IncreaseEndurance + this.Age;
    }
}
