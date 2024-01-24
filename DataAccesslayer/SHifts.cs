using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer
{
    public class SHifts : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }

        // Navigation property for many-to-many relationship
        public virtual ICollection<DoctorSHifts> DoctorShifts { get; set; }
    }

}
