using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer
{
    public partial class Doctor : Employee
    {

         


        public string Specialty { get; set; }
         public virtual ICollection<Visits> Visits { get; set; }


        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<DoctorSHifts>  DoctorSHifts { get; set; }

    }

}
