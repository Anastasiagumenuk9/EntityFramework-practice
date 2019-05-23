using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3._2.Data.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        [MaxLength(50)]
        public string Name { get; set;}
        public int Price { get; set; }
        [Column(TypeName = "real")]
        public float Quantity { get; set; }

        [MaxLength(250)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Description { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
