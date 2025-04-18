using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void AddAccount(Account account) => AccountDAO.Instance.AddAccount(account);

        public Account GetAccountById(Guid accountId) => AccountDAO.Instance.GetAccountById(accountId);

        public List<Account> GetAllAccounts() => AccountDAO.Instance.GetAllAccounts();

        public List<Account> GetAccountsByRole(string role) => AccountDAO.Instance.GetAccountsByRole(role);

        public List<Account> GetActiveAccounts() => AccountDAO.Instance.GetActiveAccounts();

        public void UpdateAccount(Guid accountId, Account account) => AccountDAO.Instance.UpdateAccount(accountId, account);

        public void DeleteAccount(Guid accountId) => AccountDAO.Instance.DeleteAccount(accountId);

        public Account GetAccountByUsername(string username) => AccountDAO.Instance.GetAccountByUsername(username);

        public Account Login(string email, string password)
        {
          Account  account=  AccountDAO.Instance.Login(email, password);
            if(account != null)
            {
                return account;
            }
            return null;
        }
        public void SignUp(Account account)
        {
            var existingAccountByEmail = AccountDAO.Instance.GetAccountByEmail(account.Email);
            if (existingAccountByEmail != null)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            var existingAccountByUsername = AccountDAO.Instance.GetAccountByUsername(account.UserName);
            if (existingAccountByUsername != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            AccountDAO.Instance.AddAccount(account);
        }

        public void UpdateAccountDetails(Guid accountId, string username, string email, string role, string status)
        {
            var existingAccountByEmail = AccountDAO.Instance.GetAccountByEmail(email);
            if (existingAccountByEmail != null && existingAccountByEmail.AccountId != accountId)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            var existingAccountByUsername = AccountDAO.Instance.GetAccountByUsername(username);
            if (existingAccountByUsername != null && existingAccountByUsername.AccountId != accountId)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            AccountDAO.Instance.UpdateAccountDetails(accountId, username, email, role, status);
        }
    }
}