using Clincic.DataAccesslayer;

using Clinic.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Service;

public class BaseServess : IBaseServess
{
    public readonly ApplicationDBcontext _context;
  public BaseServess(ApplicationDBcontext context) {  _context = context; }
    public int ContexSaveChang()
        {
         return  _context.SaveChanges();
            
    
    }
    }

