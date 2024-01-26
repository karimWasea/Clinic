 
using Clinicss.Models;

using PagedList;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Abstract
{
    public interface Idoctor   :IRepository<DoctorVm>
    {
 IPagedList<DoctorVm>Search(DoctorVm doctor); 

     }
}
