using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;

public class Smartphone : ICalling, IBrowsing
{
    private List<string> phoneNumbers;
    private List<string> sites;
    
    public Smartphone()
    {
        this.phoneNumbers=new List<string>();
        this.sites=new List<string>();
    }

    public void AdddPhoneNumber(string phoneNumber)
    {
        this.phoneNumbers.Add(phoneNumber.Any(char.IsDigit)?$"Calling... {phoneNumber}" : "Invalid number!");
    }

    public void AddSite(string site)
    {
        this.sites.Add(site.Any(char.IsDigit)? "Invalid URL!":$"Browsing: {site}!");
    }
    
    public string CallPhonenUmbers()
    {
        StringBuilder sb=new StringBuilder();
        foreach (var phoneNumber in this.phoneNumbers)
        {
            sb.AppendLine(phoneNumber);
        }

        return sb.ToString();
    }

    public string BrowsingSites()
    {
        StringBuilder sb=new StringBuilder();
        foreach (var site in this.sites)
        {
            sb.AppendLine(site);
        }
        return sb.ToString();
    }
}
