using FestivalManager.Entities;
using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
        }


        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += "Results:" + Environment.NewLine;
            if (totalFestivalLength.Hours > 0)
            {
                int minutes = totalFestivalLength.Hours * 60 + totalFestivalLength.Minutes;
                int seconds = totalFestivalLength.Seconds;
                result += ($"Festival length: {minutes}:{seconds:D2}") + Environment.NewLine;
            }
            else result += ($"Festival length: {totalFestivalLength:mm\\:ss}") + Environment.NewLine;

            foreach (var set in this.stage.Sets)
            {
                if (set.ActualDuration.Hours > 0)
                {
                    int minutes = set.ActualDuration.Hours * 60 + totalFestivalLength.Minutes;
                    int seconds = set.ActualDuration.Seconds;
                    result += ($"--{set.Name} ({minutes}:{seconds:d2}):") + Environment.NewLine;
                }
                else result += ($"--{set.Name} ({set.ActualDuration:mm\\:ss}):") + Environment.NewLine;

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + Environment.NewLine;
                }


                if (!set.Songs.Any())
                    result += ("--No songs played") + Environment.NewLine;
                else
                {
                    result += ("--Songs played:") + Environment.NewLine;
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + Environment.NewLine;
                    }
                }
            }

            return result;
        }

        public string RegisterSet(string[] args)
        {
            ISet set = setFactory.CreateSet(args[0], args[1]);
            this.stage.AddSet(set);
            return $"Registered {args[1]} set";

        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumenti = args.Skip(2).ToArray();

            var instrumenti2 = instrumenti
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = new Performer(name, age);

            foreach (var instrument in instrumenti2)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            string res = "";
            var durationArgs = args[1].Split(":");
            if (durationArgs.Length < 3) res = "00:" + args[1];
            TimeSpan duration = TimeSpan.Parse(res);
            ISong song = new Song(name, duration);
            this.stage.AddSong(song);
            return $"Registered song {song}";

        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName)) throw new InvalidOperationException("Invalid set provided");
            if (!this.stage.HasSong(songName)) throw new InvalidOperationException("Invalid song provided");

            ISong targetSong = this.stage.GetSong(songName);
            ISet targetSet = this.stage.GetSet(setName);
            targetSet.AddSong(targetSong);

            return $"Added {targetSong} to {targetSet.Name}";
        }



        public string AddPerformerToSet(string[] args)
        {

            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
                throw new InvalidOperationException("Invalid performer provided");

            if (!this.stage.HasSet(setName))
                throw new InvalidOperationException("Invalid set provided");

            ISet set = this.stage.GetSet(setName);
            IPerformer performer = this.stage.GetPerformer(performerName);
            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
}