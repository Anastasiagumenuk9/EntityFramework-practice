using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Data.Model
{
    public class Doctors
    {
        public int DoctorsID { get; set; }
        [MaxLength(50)]
        public string Name{ get; set; }
        [MaxLength(150)]
        public string Speciality { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<DoctorPatient> DoctorPatients { get; set; }
    }
}
