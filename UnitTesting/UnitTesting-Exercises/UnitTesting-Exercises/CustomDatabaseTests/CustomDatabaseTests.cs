

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CustomDatabaseProject;
using Moq;
using NUnit.Framework;

namespace CustomDatabaseTests
{
    [TestFixture]
    public class CustomDatabaseTests
    {
        private readonly int[] Elements17 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        private readonly int[] Element16 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private readonly int[] Element5 = { 1, 2, 3, 4, 5 };


        public CustomDatabase GetCustomDatabase(int[] elements)
        {
            return new CustomDatabase(elements);
        }

        
        [TestCase(new int[]{1,2,3,45,4})]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { -10 })]
        public void TestValidConstructor(int[]values)
        {
            CustomDatabase db = GetCustomDatabase(values);

            FieldInfo fieldInfo = typeof(CustomDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int[]));

            int[] targetValues =((int[])fieldInfo.GetValue(db));
            int[]buffer=new int[targetValues.Length-values.Length];
            
            Assert.That(targetValues,Is.EqualTo(values.Concat(buffer)));
            

        }

        [Test]
        public void CustomDatabase_IsTrowValidException()
        {
            //Assert.Throws<InvalidOperationException>(() => new CustomDatabase(Elements17), "The database capacity should be 16");
            Assert.That(()=>new CustomDatabase(Elements17),Throws.InvalidOperationException);
        }

        [Test]
        public void Add_InFullArray()
        {
            //act
            var db = GetCustomDatabase(Element16);
            int addingElement = 17;
            //assert
            Assert.Throws<InvalidOperationException>(() => db.Add(addingElement));
        }


        
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(-20)]
        [TestCase(0)]
        public void Add_IsValid(int element)
        {
            CustomDatabase db=new CustomDatabase();
            
            db.Add(element);
            FieldInfo fieldInfo = typeof(CustomDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int[]));

            FieldInfo currentIndexInfo = typeof(CustomDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int));

            int firstValues = ((int[])fieldInfo.GetValue(db)).First();
            
            Assert.That(firstValues,Is.EqualTo(element));

            int valuesCount = (int)currentIndexInfo.GetValue(db);
            
            Assert.That(valuesCount,Is.EqualTo(1));
            
        }

        [Test]
        public void Add_IsInvalid()
        {
            CustomDatabase db=new CustomDatabase(Element16);
            Assert.That(()=>db.Add(2),Throws.InvalidOperationException, "Database is full!");
        }
        
        [Test]
        public void Remove_InEmptyDb()
        {
            //act
            var db=new CustomDatabase();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        
        [Test]
        [TestCase(new int[] { 1, 2, 3, 45, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { -10 })]
        public void Remove_IsValid(int[]values)
        {
            CustomDatabase db = new CustomDatabase(values);
            
            FieldInfo fieldInfo = typeof(CustomDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int[]));
            

            db.Remove();
            int[] targetValues = ((int[])fieldInfo.GetValue(db));
            int[] buffer = new int[targetValues.Length - (values.Length-1)];

            values = values
                .Take(values.Length-1)
                .Concat(buffer)
                .ToArray();

            Assert.That(targetValues, Is.EqualTo(values));

        }
        
      
    }
}
