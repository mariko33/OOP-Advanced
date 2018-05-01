using System;
using System.Collections.Generic;
using System.Linq;
using BashSoftProject.Contracts;
using BashSoftProject.DataStructures;
using NUnit.Framework;

namespace BashSoftTesting
{
    [TestFixture]
    public class OrderedDataStructureTester
    {
        private const int DefaultCapacity = 16;
        private const int DefaultSize = 0; 
        private ISimpleOrderedBag<string> names;


        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names=new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity,DefaultCapacity);
            Assert.AreEqual(this.names.Size,DefaultSize);
        }

        [Test]
        public void TestCtorWithInitialCapasity()
        {
            int capacity = 20;
            this.names=new SimpleSortedList<string>(capacity);
            Assert.AreEqual(this.names.Capacity,capacity);
            Assert.AreEqual(this.names.Size,DefaultSize);

        }
        

        [Test]
        public void TestCtorWithAllParams()
        {
            int capacity = 30;
            IComparer<string>comparison=StringComparer.OrdinalIgnoreCase;
            this.names=new SimpleSortedList<string>(comparison,capacity);
            Assert.AreEqual(this.names.Capacity,capacity);
            Assert.AreEqual(this.names.Size,DefaultSize);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names.Add("first");
            Assert.AreEqual(this.names.Size,1);
            
        }

        [Test]
        public void TestAddNullThrowException()
        {
            
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            Assert.AreEqual("Balkan,Georgi,Rosen",this.names.JoinWhith(","));
            
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            string testName = "Pesho";
            for (int i = 0; i < 17; i++)
            {
                this.names.Add(testName);
            }

            Assert.AreEqual(this.names.Size,17);
            Assert.AreNotEqual(this.names.Capacity,DefaultCapacity);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string>testNames=new List<string>(){"Pesho","Gosho"};
            this.names.AddAll(testNames);
            Assert.AreEqual(this.names.Size,2);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            List<string>namesTest=new List<string>()
            {
                "Rosen",
                "Georgi",
                "Balkan"
            };
            this.names.AddAll(namesTest);
            Assert.AreEqual("Balkan,Georgi,Rosen", this.names.JoinWhith(","));
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Pesho");
            this.names.Add("Pesho");
            this.names.Add("Pesho");
            this.names.Remove("Pesho");
            Assert.AreEqual(this.names.Size,2);

        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Ivan");
            this.names.Add("Nasko");
            this.names.Remove("Ivan");
            Assert.AreEqual(null,this.names.FirstOrDefault(e=>e=="Ivan"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names.Add("Ivan");
            Assert.Throws<ArgumentNullException>(() => this.names.JoinWhith(null));
        }

        [Test]
        public void TestJoinWithNullCollection()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.JoinWhith(" "));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names.Add("Pesho");
            this.names.Add("Pesho");
            this.names.Add("Pesho");

            Assert.AreEqual("Pesho; Pesho; Pesho",this.names.JoinWhith("; "));
        }
    }
}
