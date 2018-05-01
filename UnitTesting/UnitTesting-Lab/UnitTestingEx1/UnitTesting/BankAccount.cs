using System;

namespace UnitTesting
{
    public class BankAccount
    {
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if(this.Balance<amount)throw new Exception("Insufficient funds");
            if(amount<0)throw  new Exception("Invalid ammount");

            this.Balance -= amount;
        }
        
        
    }
}