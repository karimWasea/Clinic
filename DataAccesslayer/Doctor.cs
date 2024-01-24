using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer
{
    public class Doctor :Person
    {
           public string Specialty { get; set; }
          public decimal Salary { get; set; }
          public string Imgpath { get; set; }
          public string Contractpath { get; set; }
        public virtual ICollection<Visits> Visits { get; set; }


        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<DoctorSHifts>  DoctorSHifts { get; set; }

    }

}
