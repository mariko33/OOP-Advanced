using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
   
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Assembly assembly=Assembly.GetExecutingAssembly();
        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == soldierTypeName);
        Object[] ctorParams =
        {
            name,
            age,
            experience,
            endurance
        };

        ISoldier soldier = (ISoldier)Activator.CreateInstance(type, ctorParams);

        return soldier;
    }
}
