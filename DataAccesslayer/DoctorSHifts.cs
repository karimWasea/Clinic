using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer
{
    public partial class DoctorSHifts : BaseEntity
    {
        public Guid DoctorId { get; set; }
        public Guid SHiftsId { get; set; }

         public virtual Doctor Doctor { get; set; }
        public virtual SHifts SHifts { get; set; }
    }

}
