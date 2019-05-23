using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3._2.Data.Model
{
   public  class Store
    {
        public int StoreId { get; set; }
        [MaxLength(80)]
        public string Name { get; set; }


        public ICollection<Sale> Sales { get; set; }
    }
}
