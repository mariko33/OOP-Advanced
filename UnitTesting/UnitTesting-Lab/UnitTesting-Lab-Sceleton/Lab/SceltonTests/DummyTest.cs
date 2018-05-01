using NUnit.Framework;

namespace SceltonTests
{
    public class DummyTest
    {
        [Test]
        public void DummyLosesHealthAfterAttach()
        {
            var dummy=new Dummy(10,20);
            dummy.TakeAttack(5);
            Assert.That(dummy.Health,Is.EqualTo(5));
        }
    }
}