using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    public interface IBankServices
    {
        public string? Deposit(string accNum, decimal amount);

        public string? Withdraw(string accNum, decimal amount);

        public string Transfer(string sourceAccNum, string destAccNum, decimal amount);
    }
}
