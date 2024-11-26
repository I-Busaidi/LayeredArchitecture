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
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
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
            _transactionRepository.DeleteTransaction(transaction.sourceAccNum, transaction.transactionId);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }

        public IEnumerable<Transaction> GetTransactionsBySourceAccountNum(int sourceAccNum)
        {
            return _transactionRepository.GetTransactionsBySourceAccountNum(sourceAccNum);
        }

        public IEnumerable<Transaction> GetTransactionsByDestinationAccountNum(int destAccNum)
        {
            return _transactionRepository.GetTransactionsByDestinationAccountNum(destAccNum);
        }

        public IEnumerable<Transaction> GetTransactionsByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _transactionRepository.GetTransactionsByDateRange(fromDate, toDate);
        }

        public IEnumerable<Transaction> GetAccountTransactionsByDateRange(int accNum, DateTime fromDate, DateTime toDate)
        {
            return _transactionRepository.GetAccountTransactionsByDateRange(accNum, fromDate, toDate);
        }
    }
}
