using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private const double IncreaseSkill = 3.5;
    private const double IncreaseEndurance = 30;

    private double overallSkill; 

    public SpecialForce(string name, int age, double experience, double endurance)
            : base(name, age, experience, endurance, new List<string>{"Gun",
                "AutomaticMachine",
                "MachineGun",
                "RPG",
                "Helmet",
                "Knife",
                "NightVision"})
    {
    }

    public override double OverallSkill => base.OverallSkill * IncreaseSkill;


    public override void Regenerate()
    {
        this.Endurance += IncreaseEndurance + this.Age;
    }
}
