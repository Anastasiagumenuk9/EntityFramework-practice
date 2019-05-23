using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Data.Model
{
    public class PatientMedicament
    {
        public int PatientMedicamentId { get; set; }
        public int PatientsId { get; set; }
        public int MedicamentsId { get; set; }

        
        public virtual Medicaments Medicaments { get; set; }
        public virtual Patients Patients { get; set; }
    }
}
