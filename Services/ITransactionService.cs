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

        public IEnumerable<Transaction> GetTransactionsBySourceAccountNum(string sourceAccNum);

        public IEnumerable<Transaction> GetTransactionsByDestinationAccountNum(string destAccNum);

        public IEnumerable<Transaction> GetTransactionsByDateRange(DateTime fromDate, DateTime toDate);

        public IEnumerable<Transaction> GetAccountTransactionsByDateRange(string accNum, DateTime fromDate, DateTime toDate);
    }
}
