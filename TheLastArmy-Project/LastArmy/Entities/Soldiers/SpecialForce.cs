using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private const double IncreaseSkill = 3.5;
    private const double IncreaseEndurance = 30;

    private double overallSkill;

    private List<string> weaponsAllowed = new List<string>()
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "RPG",
        "Helmet",
        "Knife",
        "NightVision"
    };

    public SpecialForce(string name, int age, double experience, double endurance)
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
