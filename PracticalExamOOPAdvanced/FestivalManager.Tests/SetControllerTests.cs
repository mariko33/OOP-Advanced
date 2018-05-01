// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

using System;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.Core.Controllers;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        private SetController setController;
        private IStage stage;

        [SetUp]
        public void SetUpSetController()
        {
            stage = new Stage();
            setController = new SetController(stage);
        }

        [Test]
        public void Test()
        {
            ISet set = new Short("TestSet");
            this.stage.AddSet(set);
            string result = this.setController.PerformSets();

            Assert.IsTrue(result.Contains("-- Did not perform"));

        }

        [Test]
        public void TestShoulPerform()
        {
            var set1 = new Short("Set1");
            var set2 = new Medium("Set2");

            var misho = new Performer("Misho", 20);
            misho.AddInstrument(new Guitar());
            var ivo = new Performer("Ivo", 24);
            ivo.AddInstrument(new Drums());
            var minka = new Performer("Minka", 19);
            minka.AddInstrument(new Guitar());
            minka.AddInstrument(new Microphone());

            Song song1 = new Song("Song1", new TimeSpan(0, 1, 2));

            set1.AddSong(song1);
            set1.AddPerformer(ivo);
            set1.AddPerformer(minka);

            stage.AddSet(set1);
            stage.AddSet(set2);

            var expected = @"1. Set1:
                            -- 1. Song1 (01:02)
                            -- Set Successful
                            2. Set2:
                            -- Did not perform";

            var actual = setController.PerformSets();

            Assert.That(expected, Is.EqualTo(actual));
            Assert.That(minka.Instruments.First().Wear, Is.EqualTo(40));
        }
    }
}
