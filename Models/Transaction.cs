using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Models
{
    [PrimaryKey(nameof(transactionId), nameof(sourceAccNum))]
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int transactionId { get; set; }

        [Required]
        [ForeignKey("SourceBA")]
        [InverseProperty("Transactions")]
        public int sourceAccNum { get; set; }
        public virtual BankAccount SourceBA { get; set; }

        [ForeignKey("DestinationBA")]
        [InverseProperty("RecievedTransactions")]
        public int? destinationAccNum { get; set; }
        public virtual BankAccount DestinationBA { get; set; }

        [Required]
        public string opertaion { get; set; }

        [Required]
        public double amount { get; set; }

        [Required]
        public DateTime date { get; set; }
    }
}
