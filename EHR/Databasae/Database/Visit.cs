using System;
using System.Collections.Generic;

namespace Databasae.Database
{
    public partial class Visit
    {
        public Visit()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int VisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
