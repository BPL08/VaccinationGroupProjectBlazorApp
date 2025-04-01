using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class AccountDAO
    {
        private ApplicationDbContext _dbContext;
        private static AccountDAO instance;

        public AccountDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public Account GetAccountById(Guid accountId)
        {
            return _dbContext.Accounts
                .Include(a => a.Center)
                .SingleOrDefault(a => a.AccountId == accountId);
        }

        public void AddAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

        public void UpdateAccount(Guid accountId, Account account)
        {
            var existingAccount = GetAccountById(accountId);
            if (existingAccount != null)
            {
                existingAccount.UserName = account.UserName;
                existingAccount.Password = account.Password;
                existingAccount.PhoneNumber = account.PhoneNumber;
                existingAccount.Email = account.Email;
                existingAccount.AccountRole = account.AccountRole;
                existingAccount.ProfileImage = account.ProfileImage;
                existingAccount.Salary = account.Salary;
                existingAccount.Status = account.Status;
                existingAccount.FKCenterId = account.FKCenterId;

                _dbContext.Accounts.Update(existingAccount);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteAccount(Guid accountId)
        {
            var account = GetAccountById(accountId);
            if (account != null)
            {
                _dbContext.Accounts.Remove(account);
                _dbContext.SaveChanges();
            }
        }

        public List<Account> GetAllAccounts()
        {
            return _dbContext.Accounts
                .Include(a => a.Center)
                .ToList();
        }

        public List<Account> GetActiveAccounts()
        {
            return _dbContext.Accounts
                .Where(a => a.Status == "Active")
                .Include(a => a.Center)
                .ToList();
        }

        public Account GetAccountByUsername(string username)
        {
            return _dbContext.Accounts
                .Include(a => a.Center)
                .SingleOrDefault(a => a.UserName == username);
        }

        public List<Account> GetAccountsByRole(string role)
        {
            return _dbContext.Accounts
                .Where(a => a.AccountRole == role)
                .Include(a => a.Center)
                .ToList();
        }

        public List<Account> GetAccountsByCenter(int centerId)
        {
            return _dbContext.Accounts
                .Where(a => a.FKCenterId == centerId)
                .Include(a => a.Center)
                .ToList();
        }
        public Account Login(string username, string password)
        {
            return _dbContext.Accounts
                .Include(a => a.Center)
                .SingleOrDefault(a => a.UserName == username && a.Password == password && a.Status == "Active");
        }
    }
}