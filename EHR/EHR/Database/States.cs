using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class States
    {
        public States()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
