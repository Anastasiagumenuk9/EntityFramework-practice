using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Model
{
    public class Villains
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public int? EvilnessFactorsId { get; set; }

        public virtual ICollection<MinionsVillains> MinionsVillains { get; set; }
        public virtual EvilnessFactors EvilnessFactors { get; set; }
    }
}
