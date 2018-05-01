using System;
using System.Collections.Generic;
using System.Linq;


public abstract class Soldier : ISoldier
{
    private double endurance;
   // private List<string> weaponsAllowed;


    public Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons=new Dictionary<string, IAmmunition>();
        //this.weaponsAllowed = weaponsAllowed;

        foreach (var weapon in WeaponsAllowed)
        {
            this.Weapons.Add(weapon,null);
        }
    }

    public string Name { get; }
    public int Age { get; }
    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        set { this.endurance = Math.Min(value, 100); }
    }

    public virtual double OverallSkill =>this.Age + this.Experience;

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected abstract List<string> WeaponsAllowed { get; }

    public abstract void Regenerate();
   

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        var hasAllEquipment = this.Weapons.Values.All(weapon => weapon != null);

        if (!hasAllEquipment) return false;

        return this.Weapons.Values.All(weapon => weapon.WearLevel > 0);

        //bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        //if (!hasAllEquipment)
        //{
        //    return false;
        //}

        //return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

   

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
       
        this.Endurance -= mission.EnduranceRequired;

        foreach (var weapon in this.Weapons.Values.Where(w => w != null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);
            if (weapon.WearLevel <= 0) this.Weapons[weapon.Name] = null;
        }
    }

   

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}