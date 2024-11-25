using LayeredArchitecture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public BankAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return _context.BankAccounts.Include(b => b.Owner).ToList();
        }

        public BankAccount GetAccountById(int accountId)
        {
            return _context.BankAccounts.Include(b => b.Owner).FirstOrDefault(b => b.Id == accountId);
        }

        public void AddAccount(BankAccount account)
        {
            _context.BankAccounts.Add(account);
            _context.SaveChanges();
        }

        public void UpdateAccount(BankAccount account)
        {
            _context.BankAccounts.Update(account);
            _context.SaveChanges();
        }

        public void DeleteAccount(int accountId)
        {
            var account = _context.BankAccounts.Find(accountId);
            if (account != null)
            {
                _context.BankAccounts.Remove(account);
                _context.SaveChanges();
            }
        }
    }
}
