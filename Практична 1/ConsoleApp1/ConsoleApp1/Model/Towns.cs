using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Model
{
    public class Towns
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public int? CountriesId { get; set; }

        public virtual ICollection<Minions> Minions { get; set; }
        public virtual Countries Countries { get; set; }
    }
}
