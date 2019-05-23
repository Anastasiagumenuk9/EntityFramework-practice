using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._1.Data.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public DateTime? Birthday { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        public bool RegisteredOn { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
        public virtual ICollection<HomeworkSubmission> HomeworkSubmission { get; set; }
    }
}
