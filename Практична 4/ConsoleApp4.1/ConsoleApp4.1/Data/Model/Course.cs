using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._1.Data.Model
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
        public virtual ICollection<HomeworkSubmission> HomeworkSubmission { get; set; }
        public virtual ICollection<Resource> Resource { get; set; }

    }
}
