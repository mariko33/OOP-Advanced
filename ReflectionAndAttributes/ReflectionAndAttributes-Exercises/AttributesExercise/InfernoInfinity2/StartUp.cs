using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfernoInfinity2.Enums;

class StartUp
    {
        static void Main()
        {
            List<Weapon>weapons=new List<Weapon>();
            var customInfoAttribute = typeof(Weapon).GetCustomAttribute<CustomInfoAttribute>();
            string input;
            while ((input=Console.ReadLine())!="END")
            {
                var args = input.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];

                switch (command)
                {
                    case "Create":
                    {
                        var type = args[1].Split(" ");
                        string rarity = type[0];
                        string typeWeapon = type[1];
                        string name = args[2];
                        LevelOfRarity rarityEnum = (LevelOfRarity) Enum.Parse(typeof(LevelOfRarity), rarity);
                        weapons.Add(WeaponFactories.GetWeapon(typeWeapon, name, rarityEnum));
                        break;
                    }
                    case "Add":
                    {
                        string weaponName = args[1];
                        int soketIndex = int.Parse(args[2]);
                        var gemTypeArgs = args[3].Split(" ");
                        string clarityString = gemTypeArgs[0];
                        string type = gemTypeArgs[1];

                        LevelOfClarity clarity = (LevelOfClarity)Enum.Parse(typeof(LevelOfClarity), clarityString);

                        Weapon currWeapon = weapons.FirstOrDefault(w => w.Name == weaponName);
                        //check

                        Gem gem = GemFactory.GetGem(type, clarity);
                        
                        currWeapon.AddGem(gem,soketIndex);
                        break;

                    }
                    case "Print":
                    {
                        string name = args[1];
                        Weapon weapon = weapons.FirstOrDefault(w => w.Name == name);
                        Console.WriteLine(weapon);
                        break;
                    }
                    case "Remove":
                    {
                        string name = args[1];
                        int index = int.Parse(args[2]);
                        Weapon weapon = weapons.FirstOrDefault(w => w.Name == name);
                        if(weapon!=null)weapon.RemoveGem(index);
                        break;
                    }
                case "Author": Console.WriteLine($"Author: {customInfoAttribute.Author}");
                    break;
                case "Revision": Console.WriteLine($"Revision: {customInfoAttribute.Revision}");
                    break;
                case "Description": Console.WriteLine($"Class description: {customInfoAttribute.Description}");
                    break;
                case "Reviewers": Console.WriteLine($"Reviewers: {string.Join(", ",customInfoAttribute.Reviewers)}");
                    break;
                }
            }
        }
    }

