using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer
{
    public class DoctorSHifts : BaseEntity
    {
        public int DoctorId { get; set; }
        public int SHiftsId { get; set; }

         public virtual Doctor Doctor { get; set; }
        public virtual SHifts SHifts { get; set; }
    }

}
