using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Models
{
    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public decimal Balance { get; set; }

        //navigation property
        [ForeignKey(nameof(Owner))]
        public int UserId { get; set; }
        public virtual User Owner { get; set; }

        [InverseProperty("SourceBA")]
        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
