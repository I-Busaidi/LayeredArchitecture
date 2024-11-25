using LayeredArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    public interface IBankAccountService
    {
        IEnumerable<BankAccount> GetAllAccounts();
        BankAccount GetAccountById(int accountId);

        BankAccount GetAccountByAccNumber(string accNumber);
        string AddAccount(BankAccount account);
        string UpdateAccount(BankAccount account);
        string DeleteAccount(int accountId);
        decimal BalanceInquiry(int accountId);
    }
}
