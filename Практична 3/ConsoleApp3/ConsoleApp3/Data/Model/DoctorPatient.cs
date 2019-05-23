using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Data.Model
{
    public class DoctorPatient
    {
        public int DoctorPatientId { get; set; }
        public int DoctorsId { get; set; }
        public int PatientsId { get; set; }
        

        public virtual Doctors Doctors { get; set; }
        public virtual Patients Patients { get; set; }
    }
}
