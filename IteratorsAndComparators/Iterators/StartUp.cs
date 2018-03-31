using System;
using System.Globalization;
using System.Linq;


class StartUp
{
    static void Main()
    {
        //ex 1-2
        //ListyIterator<string> listyIterator=new ListyIterator<string>(Console.ReadLine().Split().Skip(1));

        //string input;
        //while ((input=Console.ReadLine())!="END")
        //{
        //    if(input=="Move") Console.WriteLine(listyIterator.Move());
        //    else if(input=="HasNext") Console.WriteLine(listyIterator.HasNext());
        //    else if (input == "Print")
        //    {
        //        try
        //        {
        //            listyIterator.Print();
        //        }
        //        catch (InvalidOperationException ie)
        //        {
        //            Console.WriteLine(ie.Message);

        //        }
        //    }
        //    else if (input == "PrintAll") Console.WriteLine(string.Join(" ",listyIterator));



        //}

        //ex 3

        //CustomStack<int> stack = new CustomStack<int>();

        //string input;
        //while ((input = Console.ReadLine()) != "END")
        //{
        //    var args = input.Split(new []{" ",","},StringSplitOptions.RemoveEmptyEntries);
        //    string command = args[0];
        //    try
        //    {
        //        switch (command)
        //        {
        //            case "Push":
        //                var paramsCollection = args.Skip(1).Select(int.Parse).ToArray();
        //                stack.Push(paramsCollection);
        //                break;
        //            case "Pop":
        //                stack.Pop();
        //                break;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
                
        //    }
        //}
        
        //foreach (var s in stack)
        //{
        //    Console.WriteLine(s);
        //}
        //foreach (var s in stack)
        //{
        //    Console.WriteLine(s);
        //}
        
        //ex 4

        var input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        
        Lake<int>lake=new Lake<int>(input);

        Console.WriteLine(string.Join(", ",lake));
    }
}
