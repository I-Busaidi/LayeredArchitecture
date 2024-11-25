using LayeredArchitecture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredArchitecture.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transactions.Include(t => t.SourceBA)
                                        .Include(t => t.DestinationBA)
                                        .ToList();
        }

        public IEnumerable<Transaction> GetTransactionsBySourceAccountNum(int sourceAccNum)
        {
            return _context.Transactions.Include(t => t.SourceBA)
                                        .Include(t => t.DestinationBA)
                                        .Where(t => t.sourceAccNum == sourceAccNum)
                                        .ToList();
        }

        public IEnumerable<Transaction> GetTransactionsByDestinationAccountNum(int destAccNum)
        {
            return _context.Transactions.Include(t => t.SourceBA)
                                        .Include(t => t.DestinationBA)
                                        .Where(t => t.destinationAccNum == destAccNum)
                                        .ToList();
        }

        public IEnumerable<Transaction> GetTransactionsByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _context.Transactions.Where(t => t.date >= fromDate && t.date <= toDate)
                                        .ToList();
        }

        public IEnumerable<Transaction> GetAccountTransactionsByDateRange(int accNum, DateTime fromDate, DateTime toDate)
        {
            return _context.Transactions.Where(t => t.date >= fromDate 
                                                    && t.date <= toDate 
                                                    && (t.sourceAccNum == accNum || t.destinationAccNum == accNum))
                                        .ToList();
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }

        public void DeleteTransaction(int accId, int tId)
        {
            var transaction = _context.Transactions.Find(tId, accId);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
            }
        }
    }
}
