using BO.Entity;

namespace Repository.Interface
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        Account GetAccountById(Guid accountId);
        List<Account> GetAllAccounts();
        List<Account> GetAccountsByRole(string role);
        List<Account> GetActiveAccounts();
        void UpdateAccount(Guid accountId, Account account);
        void DeleteAccount(Guid accountId);
        public Account GetAccountByUsername(string username);
    }
}