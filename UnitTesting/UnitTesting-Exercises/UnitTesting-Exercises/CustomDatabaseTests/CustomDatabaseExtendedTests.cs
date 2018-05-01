using System.Linq;
using System.Reflection;
using CustomDatabaseProject;
using NUnit.Framework;

namespace CustomDatabaseTests
{
    [TestFixture]
    public class CustomDatabaseExtendedTests
    {
        [Test]
        public void TestValidConstructor(Person[]elements)
        {
            CustomDatabaseExtended db=new CustomDatabaseExtended(elements);

            FieldInfo fieldPerson =
                typeof(CustomDatabaseExtended).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f=>f.FieldType==typeof(Person[]));

            Person[] personValues = (Person[])fieldPerson.GetValue(db);
            Person[] buffer=new Person[personValues.Length-elements.Length];
            
           // Assert.AreEqual(personValues,elements.Concat(buffer));
            Assert.That(personValues,Is.EqualTo(elements.Concat(buffer)));

        }
    }
}