using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }
    public IProviderController ProviderController { get; private set; }


    public override string Execute()
    {
        int id = int.Parse(this.Arguments[0]);
        IEntity entity = this.HarvesterController.Entities.FirstOrDefault(e => e.ID == id);
        if (entity==null)
        {
            entity= this.ProviderController.Entities.FirstOrDefault(e => e.ID == id);
        }

        if (entity==null)
        {
            return string.Format(Constants.EntityMissing, id);
        }

        return entity.ToString();

        //List<IEntity>entities=new List<IEntity>();
        //GetHarvesters(entities);
        //GetProviders(entities);

        //int id = int.Parse(this.Arguments[0]);

        //IEntity entity = entities.FirstOrDefault(e => e.ID == id);

        //if (entity == null)
        //{
        //    return string.Format(Constants.EntityMissing, id);
        //}

        //return entity.ToString();
    }

    private void GetHarvesters(List<IEntity> entities)
    {
        var propertyInfo = this.HarvesterController.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(p => p.Name.Contains("Entities"));

        IReadOnlyCollection<IEntity> harvesterEntities = (IReadOnlyCollection<IEntity>)propertyInfo
            .GetValue(this.HarvesterController);

        entities.AddRange(harvesterEntities);
    }

    private void GetProviders(List<IEntity> entities)
    {
        var propertyInfo = this.ProviderController.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(t => t.Name.Contains("Entities"));

        IReadOnlyCollection<IEntity> providerEntities = (IReadOnlyCollection<IEntity>) propertyInfo
            .GetValue(this.ProviderController);

        entities.AddRange(providerEntities);

    }
}
