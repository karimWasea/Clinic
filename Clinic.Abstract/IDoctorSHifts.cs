
using Clincic.DataAccesslayer;

using Clinicss.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Abstract
{
    public interface IDoctorSHifts: IRepository<DoctorSHiftsVm>
    {
        public string GetdoctorName(Guid Doctorid);

     }
}
