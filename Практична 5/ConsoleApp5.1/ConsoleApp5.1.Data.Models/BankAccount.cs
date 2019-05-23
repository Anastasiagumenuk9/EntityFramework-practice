using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5._1.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public float Balance { get; set; }
        [MaxLength(50)]
        public string BankName { get; set; }
        [MaxLength(20)]
        public string SwiftCode { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
