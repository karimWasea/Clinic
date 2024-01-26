 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Abstract
{
    public interface IRepository<T>  
    {
        void Save(T entity);
        T GetById(Guid Id);
    }
}
