using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._1.Data.Model
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public int CourseId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string ResourceType { get; set; }
        public string Url { get; set; }

        public virtual Course Course { get; set; }
    }
}
