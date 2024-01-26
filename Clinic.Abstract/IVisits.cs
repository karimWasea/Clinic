 
using Clinicss.Models;

using PagedList;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Abstract
{
    public interface IVisits : IRepository<VisitsVm>
    {
 IPagedList<VisitsVm> Search(VisitsVm doctor); 

     }
}
