using System.Collections.Generic;

public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmunition(string ammunitionName, int ammunitionCount);

    bool TryEquipSoldier(ISoldier soldier);

    IReadOnlyDictionary<string, int> WeaponsCount { get; }


}
