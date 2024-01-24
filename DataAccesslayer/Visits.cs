using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer
{
    public class Visits : BaseEntity
    {
         public DateTime VisitsApientment { get; set; }

        // Navigation property for many-to-many relationship
        public Visisttype  Visisttype { get; set; } 
       public virtual ICollection<DoctorSHifts> DoctorShifts { get; set; }
    }

}

namespace Clincic.DataAccesslayer
{
    public enum Visisttype
    {
    }
}