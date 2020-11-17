using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class PrescriptionH
    {
        public PrescriptionH()
        {
            PrescriptionD = new HashSet<PrescriptionD>();
        }

        public int PrescriptionHid { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime PrescriptionHdate { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<PrescriptionD> PrescriptionD { get; set; }
    }
}
