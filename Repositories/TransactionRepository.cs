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

        public IEnumerable<Transaction> GetTransactionsBySourceAccountId(int sourceAccId)
        {
            return _context.Transactions.Include(t => t.SourceBA)
                                        .Include(t => t.DestinationBA)
                                        .Where(t => t.sourceAccId == sourceAccId)
                                        .ToList();
        }

        public IEnumerable<Transaction> GetTransactionsByDestinationAccountId(int destAccId)
        {
            return _context.Transactions.Include(t => t.SourceBA)
                                        .Include(t => t.DestinationBA)
                                        .Where(t => t.destinationAccId == destAccId)
                                        .ToList();
        }

        public IEnumerable<Transaction> GetTransactionsByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _context.Transactions.Where(t => t.date >= fromDate && t.date <= toDate)
                                        .ToList();
        }

        public IEnumerable<Transaction> GetAccountTransactionsByDateRange(int accId, DateTime fromDate, DateTime toDate)
        {
            return _context.Transactions.Where(t => t.date >= fromDate 
                                                    && t.date <= toDate 
                                                    && (t.sourceAccId == accId || t.destinationAccId == accId))
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
