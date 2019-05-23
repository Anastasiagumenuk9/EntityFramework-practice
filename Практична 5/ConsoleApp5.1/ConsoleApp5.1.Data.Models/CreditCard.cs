using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5._1.Data.Models
{
   public  class CreditCard
    {
        public int CreditCardId { get; set; }
        public DateTime ExpirationDate { get; set; }
        [NotMapped]
        public float LimitLeft { get; set; }
        public float Limit { get; set; }
        public float MoneyOwned { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
