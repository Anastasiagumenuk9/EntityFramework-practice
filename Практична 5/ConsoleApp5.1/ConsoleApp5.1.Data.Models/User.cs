using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5._1.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        [MaxLength(80)]
        public string Email{ get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(25)]
        public string Password{ get; set; }

        public virtual ICollection<PaymentMethod> PaymentMethod { get; set; }
    }
}
