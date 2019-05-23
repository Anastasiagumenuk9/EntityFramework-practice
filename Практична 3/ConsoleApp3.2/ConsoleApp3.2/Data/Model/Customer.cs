using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3._2.Data.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int CreditCardNumber { get; set; }
        [MaxLength(80)]
        public string Email { get; set;}
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
