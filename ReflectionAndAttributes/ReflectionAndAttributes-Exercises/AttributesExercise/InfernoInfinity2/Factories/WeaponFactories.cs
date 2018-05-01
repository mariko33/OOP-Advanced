using System;
using System.Linq;
using System.Reflection;

public static class WeaponFactories
{
    public static Weapon GetWeapon(string typeWeapon, string name, LevelOfRarity rarity)
    {
        Assembly currentAssembly=Assembly.GetExecutingAssembly();
        var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == typeWeapon);

        return (Weapon) Activator.CreateInstance(currentType, new object[]{name,rarity});
    }
}
