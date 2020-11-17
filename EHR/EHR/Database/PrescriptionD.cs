using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class PrescriptionD
    {
        public int PrescriptionDid { get; set; }
        public int PrescriptionHid { get; set; }
        public int MedicineId { get; set; }
        public string Note { get; set; }
        public double Cost { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual PrescriptionH PrescriptionH { get; set; }
    }
}
