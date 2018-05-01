
using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const double HalfEnergyRequirement = 50;
    private const double EnergyEnergyRequirement = 20;
    private const double MinDurability = 0;

    private List<IHarvester> hervesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;
    private string mode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.hervesters=new List<IHarvester>();
        this.factory = new HarvesterFactory();
        this.OreProduced = 0;
        this.mode = "Full";
    }

    public IReadOnlyCollection<IEntity> Entities => this.hervesters.AsReadOnly();

    public double OreProduced { get; private set; }
    
    public string Register(IList<string> args)
    {
        IHarvester harverster = this.factory.GenerateHarvester(args);
        this.hervesters.Add(harverster);
        return String.Format(Constants.SuccessfullRegistration,
            harverster.GetType().Name);
    }

    public string Produce()
    {
        double oreByDay = 0;
        double energyNeeded = this.hervesters.Sum(h => h.EnergyRequirement);
        double oreCanBeProdused = this.hervesters.Sum(h => h.Produce());
        switch (this.mode)
        {
            case "Half":
                energyNeeded *= HalfEnergyRequirement/100;
                oreCanBeProdused *= HalfEnergyRequirement/100;
                break;
            case "Energy":
                energyNeeded *= EnergyEnergyRequirement/100;
                oreCanBeProdused *= EnergyEnergyRequirement/100;
                break;
                            
        }
        if (this.energyRepository.TakeEnergy(energyNeeded))
        {
            this.OreProduced += oreCanBeProdused;
            oreByDay = oreCanBeProdused;

        }

        return string.Format(Constants.OreOutputToday, oreByDay);
    }

    
    public string ChangeMode(string mode)
    {
        this.mode = mode;
        foreach (var harvester in this.hervesters)
        {
            harvester.Broke();
            //if (harvester.Durability <= 0)
            //    this.hervesters.Remove(harvester);
        }

        //remove broke harvesters
        this.hervesters = this.hervesters.Where(h => h.Durability >= MinDurability).ToList();

        return string.Format(Constants.ModeChanged, mode);
    }
}
