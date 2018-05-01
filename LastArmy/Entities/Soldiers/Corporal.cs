using System.Collections.Generic;


public class Corporal : Soldier
{
    private const double IncreaseSkill = 2.5;
    private const double IncreaseEndurance = 10;

    public Corporal(string name, int age, double experience, double endurance)
            : base(name, age, experience, endurance, new List<string>
            {
                 "Gun",
                 "AutomaticMachine",
                 "MachineGun",
                 "Helmet",
                 "Knife",

            })
    {

    }

    public override double OverallSkill => base.OverallSkill * IncreaseSkill;

    public override void Regenerate()
    {
        this.Endurance += IncreaseEndurance + this.Age;
    }
}
