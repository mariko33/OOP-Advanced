using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameController
{
    private MissionController missionControllerField;
    private IArmy army;
    private IWareHouse wareHouse;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IAmmunitionFactory ammunitionFactory;

    public GameController()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionControllerField = new MissionController(army, wareHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
        this.ammunitionFactory = new AmmunitionFactory();

    }


    public void AddSoldier(string[] argsList)
    {
        string type = argsList[0];
        string name = argsList[1];
        int age = int.Parse(argsList[2]);
        double experience = double.Parse(argsList[3]);
        double endurance = double.Parse(argsList[4]);
        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);
        
        if (this.wareHouse.TryEquipSoldier(soldier))
        {
            this.army.AddSoldier(soldier);
        }
        else
        {
            throw new ArgumentException(String.Format(OutputMessages.SoldierDecline, type,name));
        }

    }

    
    public void AddWareHouse(string[] argsList)
    {
        string ammunitionName = argsList[0];
        int count = int.Parse(argsList[1]);
        this.wareHouse.AddAmmunition(ammunitionName, count);
    }

    public string AddMission(string[] argsList)
    {
        IMission mission = this.missionFactory.CreateMission(argsList[0], double.Parse(argsList[1]));
        return this.missionControllerField.PerformMission(mission).Trim();
    }

    public void RegenerateSoldier(string soldierType)
    {
        var typeSoldiers = this.army.Soldiers.Where(s => s.GetType().Name == soldierType).ToList();
        foreach (var soldier in typeSoldiers)
        {
            soldier.Regenerate();
        }
    }

    public string ReturnOutput()
    {
        StringBuilder sb=new StringBuilder();
        this.missionControllerField.FailMissionsOnHold();
        sb.AppendLine("Results:");
        sb.AppendLine(string.Format(OutputMessages.ResultSuccessful,
            this.missionControllerField.SuccessMissionCounter));
        sb.AppendLine(string.Format(OutputMessages.ResultFailed,
            this.missionControllerField.FailedMissionCounter));
        sb.AppendLine("Soldiers:");
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s=>s.OverallSkill))
        {
            sb.AppendLine(soldier.ToString());
        }

        return sb.ToString().Trim();
    }
}        