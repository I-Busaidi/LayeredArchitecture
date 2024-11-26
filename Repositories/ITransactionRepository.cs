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
        IEnumerable<Transaction> GetTransactionsBySourceAccountId(int sourceAccId);
        IEnumerable<Transaction> GetTransactionsByDestinationAccountId(int destAccId);
        IEnumerable<Transaction> GetTransactionsByDateRange(DateTime fromDate, DateTime toDate);
        IEnumerable<Transaction> GetAccountTransactionsByDateRange(int accId, DateTime fromDate, DateTime toDate);
        void AddTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int accountId, int transactionId);
    }
}
