using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class Insurance
    {
        public Insurance()
        {
            AdmissionH = new HashSet<AdmissionH>();
        }

        public int InsuranceId { get; set; }
        public string InsuranceName { get; set; }

        public virtual ICollection<AdmissionH> AdmissionH { get; set; }
    }
}
