using LayeredArchitecture.Models;
using LayeredArchitecture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        public TransactionService(ITransactionRepository transactionRepository, IBankAccountRepository bankAccountRepository)
        {
            _transactionRepository = transactionRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.AddTransaction(transaction);
        }

        public void UpdaterTransaction(Transaction transaction)
        {
            _transactionRepository.UpdateTransaction(transaction);
        }

        public void DeleteTransaction(Transaction transaction)
        {
            _transactionRepository.DeleteTransaction(transaction.SourceBA.Id, transaction.transactionId);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }

        public IEnumerable<Transaction> GetTransactionsBySourceAccountNum(string sourceAccNum)
        {
            var account = _bankAccountRepository.GetAccountByAccNum(sourceAccNum);
            return _transactionRepository.GetTransactionsBySourceAccountId(account.Id);
        }

        public IEnumerable<Transaction> GetTransactionsByDestinationAccountNum(string destAccNum)
        {
            var account = _bankAccountRepository.GetAccountByAccNum(destAccNum);
            return _transactionRepository.GetTransactionsByDestinationAccountId(account.Id);
        }

        public IEnumerable<Transaction> GetTransactionsByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _transactionRepository.GetTransactionsByDateRange(fromDate, toDate);
        }

        public IEnumerable<Transaction> GetAccountTransactionsByDateRange(string accNum, DateTime fromDate, DateTime toDate)
        {
            var account = _bankAccountRepository.GetAccountByAccNum(accNum);
            return _transactionRepository.GetAccountTransactionsByDateRange(account.Id, fromDate, toDate);
        }
    }
}
