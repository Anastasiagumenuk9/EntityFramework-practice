using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ConsoleApp3.Data.Model;
using ConsoleApp3.Data;

namespace ConsoleApp3.Data.Model
{
    public class Patients
    {
        public int PatientsID { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(80)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        public bool HasInsurance { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
        public virtual ICollection<Visitations> Visitations { get; set; }
        public virtual ICollection<Diagnoses> Diagnoses { get; set; }
        public virtual ICollection<DoctorPatient> DoctorPatients { get; set; }
    }
}
