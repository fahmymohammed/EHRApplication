using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class Visit
    {
        public Visit()
        {
            PrescriptionH = new HashSet<PrescriptionH>();
        }

        public int VisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<PrescriptionH> PrescriptionH { get; set; }
    }
}
