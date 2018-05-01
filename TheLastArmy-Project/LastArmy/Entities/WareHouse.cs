
using System.Collections.Generic;
using System.Linq;


public class WareHouse : IWareHouse
{
    private Dictionary<string, int> weaponsCount;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.weaponsCount = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public IReadOnlyDictionary<string, int> WeaponsCount => this.weaponsCount;

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            TryEquipSoldier(soldier);
        }
        
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var wornOutWeapons = soldier.Weapons
            .Where(w => w.Value == null).Select(w => w.Key).ToList();
        var isSoldierEquiped = true;
        foreach (var weapon in wornOutWeapons)
        {
            if (this.weaponsCount.ContainsKey(weapon)
                && this.weaponsCount[weapon] > 0)
            {
                soldier.Weapons[weapon] = ammunitionFactory.CreateAmmunition(weapon);
                this.weaponsCount[weapon]--;
            }
            else
            {
                isSoldierEquiped = false;
            }
        }
        return isSoldierEquiped;
    }

    public void AddAmmunition(string ammunitionName, int ammunitionCount)
    {
        if (!this.weaponsCount.ContainsKey(ammunitionName))
            this.weaponsCount.Add(ammunitionName, ammunitionCount);
        else this.weaponsCount[ammunitionName] += ammunitionCount;

    }
}
