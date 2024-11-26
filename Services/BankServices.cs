using LayeredArchitecture.Models;
using LayeredArchitecture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    public class BankServices : IBankServices
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly ITransactionService _transactionService;
        public BankServices(IBankAccountService bankAccountService, ITransactionService transactionService)
        {
            _bankAccountService = bankAccountService;
            _transactionService = transactionService;
        }

        public string? Deposit(string accNum, decimal amount)
        {
            var bankAccount = _bankAccountService.GetAccountByAccNumber(accNum);
            if (bankAccount != null)
            {
                bankAccount.Balance += amount;
                _bankAccountService.UpdateAccount(bankAccount);
                return null;
            }
            else
            {
                return "Bank account not found";
            }
        }

        public string? Withdraw(string accNum, decimal amount)
        {
            var bankAccount = _bankAccountService.GetAccountByAccNumber(accNum);
            if (bankAccount != null)
            {
                if (bankAccount.Balance < amount)
                {
                    return "Insufficient balance.";
                }
                else
                {
                    bankAccount.Balance -= amount;
                    _bankAccountService.UpdateAccount(bankAccount);
                    return null;
                }
            }
            else
            {
                return "Bank account not found";
            }
        }

        public string Transfer(string sourceAccNum, string destAccNum, decimal amount)
        {
            var sourceBankAcc = _bankAccountService.GetAccountByAccNumber(sourceAccNum);
            var destBankAcc = _bankAccountService.GetAccountByAccNumber(destAccNum);
            if (sourceBankAcc != null)
            {
                if (destBankAcc != null)
                {
                    if (sourceBankAcc.Balance < amount)
                    {
                        return "Insufficient balance.";
                    }
                    else
                    {
                        sourceBankAcc.Balance -= amount;
                        destBankAcc.Balance += amount;
                        _bankAccountService.UpdateAccount(sourceBankAcc);
                        _bankAccountService.UpdateAccount(destBankAcc);
                        return $"{amount} transferred successfully from account {sourceAccNum} to account {destAccNum}";
                    }
                }
                else
                {
                    return "Destination bank account not found";
                }
            }
            else
            {
                return "Source bank account not found";
            }
        }
    }
}
