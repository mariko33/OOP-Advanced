using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var telephoneNumbers = Console.ReadLine().Split(' ').ToList();
        var sites = Console.ReadLine().Split(' ').ToList();

        Smartphone phone=new Smartphone();

        foreach (var telephoneNumber in telephoneNumbers)
        {
            phone.AdddPhoneNumber(telephoneNumber);
        }

        foreach (var site in sites)
        {
            phone.AddSite(site);
        }

        Console.Write(phone.CallPhonenUmbers());
        Console.Write(phone.BrowsingSites());
    }
}

