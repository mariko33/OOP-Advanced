namespace Skeleton
{
    public class Bank
    {
        private IAccountManager accountManager;
        
        public Bank(IAccountManager manager)
        {
            this.accountManager = manager;
        }

        public string GetAccountBalance()
        {
            return accountManager.GetBalanceInCents().ToString("f2");
        }
    }
    
}