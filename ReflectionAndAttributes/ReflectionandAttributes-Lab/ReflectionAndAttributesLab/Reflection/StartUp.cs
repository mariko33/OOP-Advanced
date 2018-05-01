using System;

[SoftUni("Ventsi")]
class StartUp
{
    [SoftUni("Gosho")]
    static void Main()
    {
        // ex. 1
        //Spy spy=new Spy();
        //string result = spy.StealFieldInfo("Hacker", "username", "password");
        //Console.WriteLine(result);

        //ex.2

        //Spy spy=new Spy();
        //string result = spy.AnalyzeAcessModifiers("Hacker");
        //Console.WriteLine(result);

        //ex. 3

        //Spy spy=new Spy();
        //string result = spy.RevealPrivateMethods("Hacker");
        //Console.WriteLine(result);

        // ex. 4

        //Spy spy = new Spy();
        //string result = spy.CollectGettersAndSetters("Hacker");
        //Console.WriteLine(result);
        
        // ex. 5
        
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
        
    }
}

