
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
[CustomInfo("Pesho",3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public abstract class Weapon
{
    protected Weapon(string name, int minDamage, int maxDamage, int numberOfSocets, LevelOfRarity rarity)
    {
        this.Rarity = rarity;
        this.Name = name;
        this.MinDamage = minDamage * (int)this.Rarity;
        this.MaxDamage = maxDamage * (int)this.Rarity;
        this.NumberOfSocets = numberOfSocets;
        this.Gems = new Dictionary<int, Gem>();
    }

    public string Name { get; set; }

    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int NumberOfSocets { get; set; }

    public LevelOfRarity Rarity { get; set; }

    public Dictionary<int,Gem> Gems { get; set; }

    public void AddGem(Gem gem, int index)
    {
        if (this.Gems.ContainsKey(index)) this.Gems[index] = gem;
        else if (this.Gems.Count < this.NumberOfSocets) this.Gems.Add(index, gem);


    }

    public void RemoveGem(int index)
    {
        if (this.Gems.ContainsKey(index)) this.Gems.Remove(index);
       
    }

    public void CalculateBaseStatus()
    {
        this.MinDamage += 2 * this.Gems.Sum(g => g.Value.Strength) + this.Gems.Sum(g => g.Value.Agility);
        this.MaxDamage += 3 * this.Gems.Sum(g => g.Value.Strength) + 4 * this.Gems.Sum(g => g.Value.Agility);

    }
    

    public override string ToString()
    {
        this.CalculateBaseStatus();
        int strenght = this.Gems.Sum(g => g.Value.Strength);
        int agility = this.Gems.Sum(g => g.Value.Agility);
        int vitality = this.Gems.Sum(g => g.Value.Vitality);

        return
            $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strenght} Strength, +{agility} Agility, +{vitality} Vitality";
    }
}
