using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        //Problrm 5:
        //List<Society>societies=new List<Society>();
        //string input;
        //while ((input=Console.ReadLine())!="End")
        //{
        //    var args = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
        //    if (args.Count==3)
        //    {
        //        Society citizen=new Citizen(args[0],int.Parse(args[1]),args[2]);
        //        societies.Add(citizen);
        //    }
        //    else
        //    {
        //        Society robot = new Robot(args[0], args[1]);
        //        societies.Add(robot);


        //    }
        //}
        //string fakeId = Console.ReadLine();
        //foreach (var society in societies)
        //{
        //    if (society.Isdetained(fakeId))
        //    {
        //        Console.WriteLine(society.FakeId());
        //    }
        //}
        
        //Problem 6:

        //string input;
        //List<IBirthdate>birthDateOwners=new List<IBirthdate>();
        //while ((input=Console.ReadLine())!="End")
        //{
        //    var args = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
        //    if (args[0] == "Citizen")
        //    {
        //        string name = args[1];
        //        int age = int.Parse(args[2]);
        //        string id = args[3];
        //        string birthdate = args[4];
        //        IBirthdate citizen=new Citizen(name,age,id,birthdate);
        //        birthDateOwners.Add(citizen);
        //    }
        //    if (args[0]== "Pet")
        //    {
        //        string name = args[1];
        //        string birthdate = args[2];
        //        IBirthdate pet=new Pet(name, birthdate);
        //        birthDateOwners.Add(pet);
        //    }
        //}
        //string givenYear = Console.ReadLine();
        //foreach (var owner in birthDateOwners)
        //{
        //    if (owner.IsBirthYear(givenYear))
        //    {
        //        Console.WriteLine(owner.GetBirthdate());
        //    }
        //}
        
        
        //Problem 7:

        Dictionary<string,IBuyer>buyers=new Dictionary<string, IBuyer>();
        int numbersOfInputs = int.Parse(Console.ReadLine());
        string input;
        for (int i = 0; i < numbersOfInputs; i++)
        {
            input = Console.ReadLine();
            var inputArsg = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (inputArsg.Count==4)
            {
                IBuyer citizen=new Citizen(inputArsg[0],int.Parse(inputArsg[1]), inputArsg[2], inputArsg[2]);
                buyers.Add(inputArsg[0],citizen);
            }
            else
            {
                IBuyer rebel=new Rebel(inputArsg[0],int.Parse(inputArsg[1]), inputArsg[2]);
                buyers.Add(inputArsg[0],rebel);
            }
        }

        string inputBuyer;
        while ((inputBuyer=Console.ReadLine())!="End")
        {
            if (buyers.Any(k=>k.Key==inputBuyer))
            {
                buyers[inputBuyer].BuyFood();
            }
        }

        Console.WriteLine(buyers.Sum(k=>k.Value.Food));
    }
}

