using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class States
    {
        public States()
        {
            Doctor = new HashSet<Doctor>();
            Patient = new HashSet<Patient>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
