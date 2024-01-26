using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer
{
    public partial class Patient : Person
    {   
       
        public virtual ICollection<Visits>  Visits { get; set; }

     }

}
