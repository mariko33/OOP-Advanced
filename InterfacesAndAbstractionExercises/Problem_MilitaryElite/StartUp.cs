using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string input;
        List<ISoldier> army = new List<ISoldier>();
        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = args[0];
            switch (command)
            {
                case "Private":
                    ISoldier privPrivate = new Private(int.Parse(args[1]), args[2], args[3], double.Parse(args[4]));
                    army.Add(privPrivate);
                    break;
                case "LeutenantGeneral":
                    List<string> inputPrivate = args.GetRange(5, args.Count - 5);
                    ISoldier general = new LeutenantGeneral(int.Parse(args[1]), args[2], args[3], double.Parse(args[4]), GetSoldiers(inputPrivate, army));
                    army.Add(general);
                    break;

                case "Engineer":
                    if (args[5] != "Airforces" && args[5] != "Marines")
                    {
                        break;
                    }
                    string corp = args[5];
                    List<string> pairsInput = args.GetRange(6, args.Count - 6);
                    ISoldier engineer = new Engineer(int.Parse(args[1]), args[2], args[3], double.Parse(args[4]), corp, ExtractRepairsList(pairsInput));
                    army.Add(engineer);
                    break;
                case "Commando":
                    if (args[5] != "Airforces" && args[5] != "Marines")
                    {
                        break;
                    }
                    corp = args[5];
                    List<string> inputMission = args.GetRange(6, args.Count - 6);
                    ISoldier comando = new Commando(int.Parse(args[1]), args[2], args[3], double.Parse(args[4]), corp, ExtractMission(inputMission));
                    army.Add(comando);
                    break;
                case "Spy":
                    ISoldier spy = new Spy(int.Parse(args[1]), args[2], args[3], int.Parse(args[4]));
                    army.Add(spy);
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;

            }


        }

        foreach (var soldier in army)
        {
            Console.WriteLine(soldier);
        }
    }

    public static List<IRepair> ExtractRepairsList(List<string> pairs)
    {
        List<IRepair> repairs = new List<IRepair>();
        for (int i = 0; i < pairs.Count; i += 2)
        {
            IRepair pair = new Repair(pairs[i], int.Parse(pairs[i + 1]));
            repairs.Add(pair);
        }
        return repairs;
    }

    public static List<IMission> ExtractMission(List<string> inputMission)
    {
        List<IMission> missions = new List<IMission>();
        for (int i = 0; i < inputMission.Count; i += 2)
        {
            if (inputMission[i + 1] != "inProgress" && inputMission[i + 1] != "Finished")
            {
                continue;
            }
            IMission mission = new Mission(inputMission[i], inputMission[i + 1]);
            missions.Add(mission);

        }
        return missions;
    }

    public static List<ISoldier> GetSoldiers(List<string> inputPrivate, List<ISoldier> army)
    {
        List<ISoldier> generalPrivates = new List<ISoldier>();
        foreach (var inPrivate in inputPrivate)
        {
            int idPriv = int.Parse(inPrivate);
            var generalPrivate = army.FirstOrDefault(p => p.Id == idPriv);
            generalPrivates.Add(generalPrivate);

        }
        return generalPrivates;
    }
}

