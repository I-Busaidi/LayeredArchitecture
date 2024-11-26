using LayeredArchitecture.Models;
using LayeredArchitecture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    public class BankAccountService : IBankAccountService
    {

        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return _bankAccountRepository.GetAllAccounts();
        }

        public BankAccount GetAccountByAccNumber(string accNumber)
        {
            var account = _bankAccountRepository.GetAccountByAccNum(accNumber);
            if (account == null)
            {
                return null;
            }
            return _bankAccountRepository.GetAccountById(account.Id);
        }

        public string AddAccount(BankAccount account)
        {
            var bankAccount = GetAccountByAccNumber(account.AccountNumber);
            if (bankAccount == null)
            {
                _bankAccountRepository.AddAccount(account);
                return "Account added successfully.";
            }
            else
            {
                return "An account with this number already exists.";
            }
        }

        public string UpdateAccount(BankAccount account)
        {
            var existingAccount = _bankAccountRepository.GetAccountById(account.Id);
            if (existingAccount != null)
            {
                // Update properties
                existingAccount.AccountNumber = account.AccountNumber;
                existingAccount.Balance = account.Balance;
                existingAccount.UserId = account.UserId;

                // Save changes to the database
                _bankAccountRepository.UpdateAccount(existingAccount);
                return "Account updated successfully";
            }
            else
            {
                return "Account not found";
            }
        }

        public string DeleteAccount(int accountId)
        {
            var bankAccount = _bankAccountRepository.GetAccountById(accountId);
            if (bankAccount != null)
            {
                _bankAccountRepository.DeleteAccount(accountId);
                return "Account deleted successfully";
            }
            else
            {
                return "Account not found";
            }
        }

        public decimal BalanceInquiry(int accountId)
        {
            var account = _bankAccountRepository.GetAccountById(accountId);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }
            return account.Balance;
        }
    }
}
