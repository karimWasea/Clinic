using Clinicss.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer
{
    public  partial class Visits : BaseEntity
    {
         public DateTime VisitsApientment { get; set; }

        // Navigation property for many-to-many relationship
        public VisitStutus  Visisttype { get; set; } 
        public VisitStutus   VisitStutus { get; set; } 
        public Patient    Patient { get; set; } 
       public virtual ICollection<DoctorSHifts> DoctorShifts { get; set; }
    }

}

 