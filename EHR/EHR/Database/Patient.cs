using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class Patient
    {
        public Patient()
        {
            AdmissionH = new HashSet<AdmissionH>();
        }

        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientDob { get; set; }
        public int GenderId { get; set; }
        public string PatientAddresss { get; set; }
        public string PatientCity { get; set; }
        public int? PatientZipCode { get; set; }
        public int? StateId { get; set; }
        public int? Ssn { get; set; }
        public string PatientMobile { get; set; }
        public string PatientEmail { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual States State { get; set; }
        public virtual ICollection<AdmissionH> AdmissionH { get; set; }
    }
}
