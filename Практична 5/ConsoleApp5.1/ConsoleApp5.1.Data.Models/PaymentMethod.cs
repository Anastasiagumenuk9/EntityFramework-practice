using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5._1.Data.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public int BankAccountId { get; set; }
        public int CreditCardId { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }

        [Required]
        public  CreditCard CreditCard { get; set; }
        [Required]
        public virtual BankAccount BankAccount { get; set; }
        public User User { get; set; }
    }
}
