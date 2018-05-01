using FestivalManager.Core;
using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Core.IO;
using FestivalManager.Core.IO.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;

namespace FestivalManager
{
	using System.IO;
	using System.Linq;
	

	public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader=new Reader();
            IWriter writer=new Writer();
            IStage stage=new Stage();
            ISetController setController=new SetController(stage);
            IFestivalController festivalController=new FestivalController(stage);
            IEngine engine=new Engine(reader,writer,setController,festivalController);

            engine.Run();

        }
	}
}