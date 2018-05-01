using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


[TestFixture]
public class MissionControllerTest
{
    [Test]
    public void PerformMissionDecline()
    {
        IMission mission = new Easy(150);
        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();
        MissionController controller = new MissionController(army, wareHouse);
        string result = "";

        for (int i = 0; i < 4; i++)
        {
            result = controller.PerformMission(mission);
        }
        Assert.IsTrue(result.StartsWith("Mission declined"));
    }

    [Test]
    public void PerformMissionIsSucceess()
    {
        IMission mission = new Easy(0);
        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();
        MissionController controller = new MissionController(army, wareHouse);
        string result = controller.PerformMission(mission);

        Assert.IsTrue(result.StartsWith("Mission completed"));
    }
}

