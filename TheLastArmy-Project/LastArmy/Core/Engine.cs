

using System;
using System.Linq;
using System.Xml;

public class Engine
{
    private GameController controller;
    private const string EndOfInput = "Enough! Pull back!";


    public Engine()
    {
        this.controller = new GameController();
    }

    public void Run()
    {
        string input;
        while ((input = ConsoleReader.ReadLine()) != EndOfInput)
        {
            string[] args = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string command = args[0];

            string[] argsList = args.Skip(1).ToArray();

            try
            {
                switch (command)
                {
                    case "Soldier":
                        if (argsList[0] == "Regenerate") this.controller.RegenerateSoldier(argsList[1]);
                        else this.controller.AddSoldier(argsList);
                        break;
                    case "WareHouse":
                        this.controller.AddWareHouse(argsList);
                        break;
                    case "Mission":
                        ConsoleWriter.WriteLine(this.controller.AddMission(argsList));
                        break;
                }
            }
            catch (Exception e)
            {
               ConsoleWriter.WriteLine(e.Message);
               
            }
            
        }

        ConsoleWriter.WriteLine(this.controller.ReturnOutput());
    }
}
