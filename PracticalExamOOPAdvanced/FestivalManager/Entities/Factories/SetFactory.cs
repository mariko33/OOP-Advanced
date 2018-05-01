
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
	    public ISet CreateSet(string name, string type)
	    {
	        Type setType = Assembly.GetCallingAssembly()
	            .GetTypes()
	            .FirstOrDefault(t => t.Name == type);

	        var ctor = setType.GetConstructors(BindingFlags.Instance|BindingFlags.Public).First();
	        ISet set = (ISet) ctor.Invoke(new object[] {name});
	        return set;
            
	    }
	}




}
