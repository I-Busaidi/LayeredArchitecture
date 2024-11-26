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
    [PrimaryKey(nameof(transactionId), nameof(sourceAccId))]
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int transactionId { get; set; }

        [Required]
        [ForeignKey("SourceBA")]
        [InverseProperty("Transactions")]
        public int sourceAccId { get; set; }
        public virtual BankAccount SourceBA { get; set; }

        [ForeignKey("DestinationBA")]
        [InverseProperty("RecievedTransactions")]
        public int? destinationAccId { get; set; }
        public virtual BankAccount DestinationBA { get; set; }

        [Required]
        public string opertaion { get; set; }

        [Required]
        public decimal amount { get; set; }

        [Required]
        public DateTime date { get; set; }
    }
}
