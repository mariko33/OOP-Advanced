namespace Skeleton
{
    
    public class AccountManager : IAccountManager
    {
        public BanckAccount Account { get; private set; }


        public int GetBalanceInCents()
        {
            return Account.Balance;
        }
    }
    
  
}