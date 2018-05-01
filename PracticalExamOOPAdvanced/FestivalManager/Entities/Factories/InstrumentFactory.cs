namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
	    public IInstrument CreateInstrument(string type)
	    {
	        Type instrumentType = Assembly.GetCallingAssembly()
	            .GetTypes()
	            .FirstOrDefault(t => t.Name == type);

	        var ctor = instrumentType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).First();
	        IInstrument instrument = (IInstrument)ctor.Invoke(null);
	        return instrument;
        }
	}
}