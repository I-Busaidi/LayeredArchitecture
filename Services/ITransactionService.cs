using LayeredArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    public interface ITransactionService
    {
        public void AddTransaction(Transaction transaction);

        public void UpdaterTransaction(Transaction transaction);

        public void DeleteTransaction(Transaction transaction);

        public IEnumerable<Transaction> GetAllTransactions();

        public IEnumerable<Transaction> GetTransactionsBySourceAccountNum(int sourceAccNum);

        public IEnumerable<Transaction> GetTransactionsByDestinationAccountNum(int destAccNum);

        public IEnumerable<Transaction> GetTransactionsByDateRange(DateTime fromDate, DateTime toDate);

        public IEnumerable<Transaction> GetAccountTransactionsByDateRange(int accNum, DateTime fromDate, DateTime toDate);
    }
}
