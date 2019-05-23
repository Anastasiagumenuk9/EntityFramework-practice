using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp3.Data.Model
{
    public class Visitations
    {
        public int VisitationsID { get; set; }
        [MaxLength(250)]
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public int PatientsId { get; set; }

        public virtual Patients Patients { get; set; }
    }
}
