using Clincic.DataAccesslayer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer;

public class Employee :Person
{
       public decimal Salary { get; set; }
      public string Imgpath { get; set; }
      public string Contractpath { get; set; }
      public string Title { get; set; }
      public DateTime HiringDate { get; set; }
    public virtual  Clinic  Clinic { get; set; }


  
}
