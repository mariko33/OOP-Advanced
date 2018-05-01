
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Core.IO.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        //private ISetFactory setFactory;
        //private IInstrumentFactory instrumentFactory;
        //private IStage stage;

        private ISetController setController;
        private IFestivalController festivalController;


        public Engine(IReader reader, IWriter writer, ISetController setController,
            IFestivalController festivalController)
        {
            this.reader = reader;
            this.writer = writer;
            this.setController = setController;
            this.festivalController = festivalController;

        }

        public void Run()
        {
            string input;
            while ((input=reader.ReadLine())!="END")
            {
                try
                {
                    this.writer.WriteLine(this.ProcessCommand(input));
                }
                catch (Exception e)
                {
                    this.writer.WriteLine($"ERROR: {e.Message}");
                }
            }

            writer.WriteLine(this.festivalController.ProduceReport());
        }

        public string ProcessCommand(string input)
        {
            var args = input.Split();
            string command = args[0];
            args = args.Skip(1).ToArray();
            string result=String.Empty;
            switch (command)
            {
                case "RegisterSet":
                     result=this.festivalController.RegisterSet(args);

                    break;
                case "SignUpPerformer":
                    result = this.festivalController.SignUpPerformer(args);
                 
                    break;
                case "RegisterSong":    //RegisterSong {name} {mm:ss}
                    result = this.festivalController.RegisterSong(args);
                    break;
                case "AddSongToSet":
                    result = this.festivalController.AddSongToSet(args);
                    break;
                case "AddPerformerToSet":
                    result = this.festivalController.AddPerformerToSet(args);
                    break;
                case "RepairInstruments":
                    result = this.festivalController.RepairInstruments(args);
                    break;
                case "LetsRock":
                    result = this.setController.PerformSets();
                    break;
            }

            return result;
        }

        //   public IReader chetаch;
        //   public IWriter pisаch;

        //public IFestivalController festivalCоntroller = new FestivalController();
        //public ISetController setCоntroller = new SetController();

        //// дайгаз
        //public void Запали()
        //{
        //	while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) // for job security
        //	{
        //		var input = chetach.ReadLine();

        //		if (input == "END")
        //			break;

        //		try
        //		{
        //			string.Intern(input);

        //			var result = this.DoCommand(input);
        //			this.pisach.WriteLine(result);
        //		}
        //		catch (Exception ex) // in case we run out of memory
        //		{
        //			this.pisach.WriteLine("ERROR: " + ex.Message);
        //		}
        //	}

        //	var end = this.festivalController.Report();

        //	this.pisach.WriteLine("Results:");
        //	this.pisach.WriteLine(end);
        //}

        //public string DoCommand(string input)
        //{
        //	var chasti = input.Split(" ".ToCharArray().First());

        //	var purvoto = chasti.First();
        //	var parametri = chasti.Skip(1).ToArray();

        //	if (purvoto == "LetsRock")
        //	{
        //		var setovete = this.setController.PerformSets();
        //		return setovete;
        //	}

        //	var festivalcontrolfunction = this.festivalController.GetType()
        //		.GetMethods()
        //		.FirstOrDefault(x => x.Name == purvoto);

        //	string a;

        //	try
        //	{
        //		a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parametri });
        //	}
        //	catch (TargetInvocationException up)
        //	{
        //		throw up; // ha ha
        //	}

        //	return a;
        //}

    }
}