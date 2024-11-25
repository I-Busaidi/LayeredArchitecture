using LayeredArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Repositories
{
    public interface IBankAccountRepository
    {
        IEnumerable<BankAccount> GetAllAccounts();
        BankAccount GetAccountById(int accountId);

        BankAccount GetAccountByAccNum(string accNum);
        void AddAccount(BankAccount account);
        void UpdateAccount(BankAccount account);
        void DeleteAccount(int accountId);
    }
}
