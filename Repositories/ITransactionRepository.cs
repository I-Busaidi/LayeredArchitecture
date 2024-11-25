using LayeredArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions();
        IEnumerable<Transaction> GetTransactionsBySourceAccountNum(int sourceAccNum);
        IEnumerable<Transaction> GetTransactionsByDestinationAccountNum(int destAccNum);
        IEnumerable<Transaction> GetTransactionsByDateRange(DateTime fromDate, DateTime toDate);
        IEnumerable<Transaction> GetAccountTransactionsByDateRange(int accNum, DateTime fromDate, DateTime toDate);
        void AddTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int accountId, int transactionId);
    }
}
