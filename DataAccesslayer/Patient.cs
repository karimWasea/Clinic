﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clincic.DataAccesslayer
{
    public class Patient : Person
    {
        public virtual ICollection<Visits>  Visits { get; set; }

        public Doctor Doctor { get; set; }
    }

}