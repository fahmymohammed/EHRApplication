using System;
using System.Collections.Generic;

namespace Databasae.Database
{
    public partial class Gender
    {
        public Gender()
        {
            Patient = new HashSet<Patient>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
