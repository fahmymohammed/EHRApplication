using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class AdmissionD
    {
        public int AdmissionDid { get; set; }
        public int AdmissionHid { get; set; }
        public int MedicineId { get; set; }

        public virtual AdmissionH AdmissionH { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
