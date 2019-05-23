using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp3.Data.Model
{
    public class Medicaments
    {
        public int MedicamentsID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
