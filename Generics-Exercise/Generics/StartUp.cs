using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        //ex.1,2
        //int count = int.Parse(Console.ReadLine());

        //for (int i = 0; i < count; i++)
        //{
        //    string input = Console.ReadLine();

        //    if (int.TryParse(input, out int intValue))
        //    {
        //        Box<int> box = new Box<int>(intValue);
        //        Console.WriteLine(box);
        //    }
        //    else
        //    {
        //        Box<string> boxString = new Box<string>(input);
        //        Console.WriteLine(boxString);
        //    }
        //}

        //ex 3

        //   int count = int.Parse(Console.ReadLine());

        //   List<Box<string>> elements = new List<Box<string>>();

        //   for (int i = 0; i < count; i++)
        //   {
        //       string input = Console.ReadLine();
        //       Box<string> box = new Box<string>(input);
        //       elements.Add(box);
        //   }

        //   var indexes = Console.ReadLine()
        //                        .Split()
        //                        .Select(int.Parse)
        //                        .ToList();

        //Swap(elements,indexes[0],indexes[1])
        //    .ForEach(b=>Console.WriteLine(b));

        //ex 4
        //int count = int.Parse(Console.ReadLine());

        //List<Box<int>> elements = new List<Box<int>>();

        //for (int i = 0; i < count; i++)
        //{
        //    int input = int.Parse(Console.ReadLine());
        //    Box<int> box = new Box<int>(input);
        //    elements.Add(box);
        //}

        //var indexes = Console.ReadLine()
        //    .Split()
        //    .Select(int.Parse)
        //    .ToList();

        //Swap(elements, indexes[0], indexes[1])
        //    .ForEach(b => Console.WriteLine(b));


        //ex 5
        //int count = int.Parse(Console.ReadLine());

        //List<string> elements = new List<string>();

        //for (int i = 0; i < count; i++)
        //{
        //    string input = Console.ReadLine();
        //    elements.Add(input);
        //}

        //string element = Console.ReadLine();

        //Console.WriteLine(CountGreaterThenElement(elements,element));

        //ex 6
        //double count = double.Parse(Console.ReadLine());

        //List<double> elements = new List<double>();

        //for (int i = 0; i < count; i++)
        //{
        //    double input = double.Parse(Console.ReadLine());
        //    elements.Add(input);
        //}

        //double element = double.Parse(Console.ReadLine());

        //Console.WriteLine(CountGreaterThenElement(elements, element));

        // ex.7,8

        //CustomList<string>elements=new CustomList<string>();

        //string input;

        //while ((input=Console.ReadLine())!="END")
        //{
        //    var args = input.Split();
        //    string command = args[0];
        //    switch (command)
        //    {
        //        case "Add":elements.Add(args[1]);
        //            break;
        //        case "Remove": elements.Remove(int.Parse(args[1]));
        //            break;
        //        case "Contains": Console.WriteLine(elements.Contains(args[1])?"True":"False");
        //            break;
        //        case "Swap":
        //            int index1 = int.Parse(args[1]);
        //            int index2 = int.Parse(args[2]);
        //            elements.Swap(index1,index2);
        //            break;
        //        case "Greater": Console.WriteLine(elements.CountGreaterThan(args[1]));
        //            break;
        //        case "Max": Console.WriteLine(elements.Max());
        //            break;
        //        case "Min": Console.WriteLine(elements.Min());
        //            break;
        //        case "Print":
        //            elements.Print();
        //            break;
        //        case "Sort":
        //            elements.Sort();
        //            break;


        //    }
        //}

        //ex 10

        //var firstInput = Console.ReadLine().Split();

        //string fullName = firstInput[0] + " " + firstInput[1];
        //string adress = firstInput[2];

        //Tuple<string,string>tuple1=new Tuple<string, string>(fullName,adress);

        //var secondInput = Console.ReadLine().Split();
        //string name = secondInput[0];
        //int litersOfBeer = int.Parse(secondInput[1]);

        //Tuple<string,int>tuple2=new Tuple<string, int>(name,litersOfBeer);

        //var tirdInput = Console.ReadLine().Split();
        //int number = int.Parse(tirdInput[0]);
        //double numberDouble = double.Parse(tirdInput[1]);

        //Tuple<int,double>tuple3=new Tuple<int, double>(number,numberDouble);

        //Console.WriteLine(tuple1);
        //Console.WriteLine(tuple2);
        //Console.WriteLine(tuple3);


        // ex 11
        var firstInput = Console.ReadLine().Split();

        string fullName = firstInput[0] + " " + firstInput[1];
        string adress = firstInput[2];
        string town = firstInput[3];

        Threeuple<string, string,string> threeuple1 = new Threeuple<string, string, string>(fullName, adress,town);

        var secondInput = Console.ReadLine().Split();
        string name = secondInput[0];
        int litersOfBeer = int.Parse(secondInput[1]);
        bool isDrunk = false;
        if (secondInput[2] == "drunk") isDrunk = true;

        Threeuple<string, int,bool> threeuple2 = new Threeuple<string, int,bool>(name, litersOfBeer,isDrunk);

        var tirdInput = Console.ReadLine().Split();
        string namePerson = tirdInput[0];
        double bankAccount = double.Parse(tirdInput[1]);
        string bankName = tirdInput[2];

        Threeuple<string, double, string> threeuple3 = new Threeuple<string, double, string>(namePerson, bankAccount, bankName);

        Console.WriteLine(threeuple1);
        Console.WriteLine(threeuple2);
        Console.WriteLine(threeuple3);

    }

    public static int CountGreaterThenElement<T>(List<T>elements, T element)
    where T:IComparable<T>
    {
        var greaterElements = elements.Where(e => e.CompareTo(element)>0).ToList();
        return greaterElements.Count;
    }

    public static List<T> Swap<T>(List<T> elements, int indexFirst, int indexSecond)
    {
        var firstElement = elements[indexFirst];
        var secondElements = elements[indexSecond];
        elements[indexFirst] = secondElements;
        elements[indexSecond] = firstElement;

        return elements;
    }
}

