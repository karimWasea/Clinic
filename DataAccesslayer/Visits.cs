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
        public Visisttype Visisttype { get; set; } 
        public VisitStatus   VisitStutus { get; set; } 
         public  Guid patientid     { get; set; } 
         public  Guid DoctorId     { get; set; } 
        public Patient    Patient { get; set; } 
        public Doctor    Doctor { get; set; } 
     }

}

 