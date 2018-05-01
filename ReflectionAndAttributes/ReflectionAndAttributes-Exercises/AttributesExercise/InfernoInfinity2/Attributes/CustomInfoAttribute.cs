﻿
using System;

[AttributeUsage(AttributeTargets.All)]
public class CustomInfoAttribute : Attribute
{
    public CustomInfoAttribute(string author, int revision, string description,params string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = reviewers;
    }
    
    public string Author { get; set; }
    public int Revision { get; set; }
    public string Description { get; set; }
    public string[] Reviewers { get; set; }
}
