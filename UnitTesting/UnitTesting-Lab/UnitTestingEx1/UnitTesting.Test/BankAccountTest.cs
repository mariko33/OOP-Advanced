using System;
using NUnit.Framework;

namespace UnitTesting.Test
{
    public class BankAccountTest
    {
        [Test]
        public void DepositShouldIncreaseBalance()
        {
            var bankAccount=new BankAccount();
            bankAccount.Deposit(10);
            Assert.That(bankAccount.Balance,Is.EqualTo(10));
        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(-10)]
        public void WhithdrawThrowsExceptionIfInsuffitionFunds(int ammount)
        {
            var bankAccount=new BankAccount();
            Assert.Throws<Exception>(() => bankAccount.Withdraw(ammount));

        }
    }
    
    
}
