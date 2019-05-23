using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._1.Data.Model
{
    public class HomeworkSubmission
    {
        public int HomeworkSubmissionId { get; set; }
        public string ContentType { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime? SubmissionTime { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
