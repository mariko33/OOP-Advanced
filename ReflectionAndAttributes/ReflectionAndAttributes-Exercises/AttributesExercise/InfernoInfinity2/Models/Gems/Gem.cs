
using System;
using InfernoInfinity2.Enums;

public abstract class Gem : IGem
{
    protected Gem(int strength, int agility, int vitality, LevelOfClarity clarity)
    {
        this.Clarity = clarity;
        this.Strength = strength+(int)this.Clarity;
        this.Agility = agility+(int)this.Clarity;
        this.Vitality = vitality+ (int)this.Clarity;

    }

    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Vitality { get; set; }

    public LevelOfClarity Clarity { get; set; }
}
