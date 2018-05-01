using Moq;
using NUnit.Framework;
using Skeleton;

namespace SceltonTests
{
    public class BankTests
    {
        //[Test]
        //public void GetAccountBalance_FormatToMoney()
        //{
        //    var bank=new Bank();
        //    var banckAccount=new BanckAccount();
            
        //    bank.AccountManager=new FakeAccountManager(10);
        //    string expected = "10.00";
        //    Assert.That(bank.GetAccountBalance(),Is.EqualTo(expected));
        //}

        class FakeAccountManager:IAccountManager
        {
            private int centsToReturn;

            public FakeAccountManager(int centsToReturn)
            {
                this.centsToReturn = centsToReturn;
            }


            public int GetBalanceInCents()
            {
                return this.centsToReturn;
            }
            
        }



        [Test]
        public void GetAccountBalance_FormatToMoney_WithMock()
        {
            var fackeAccountManager = new Mock<IAccountManager>();
            fackeAccountManager.Setup(m => m.GetBalanceInCents()).Returns(10);
           
            var bank=new Bank(fackeAccountManager.Object);
            
            string expected = "10.00";
            Assert.That(bank.GetAccountBalance(), Is.EqualTo(expected));
        }

    }
}