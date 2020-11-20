using System;
using System.Collections.Generic;

namespace Databasae.Database
{
    public partial class Doctor
    {
        public Doctor()
        {
            AdmissionH = new HashSet<AdmissionH>();
            Visit = new HashSet<Visit>();
        }

        public int DoctorId { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public int DepartmentId { get; set; }
        public string DoctorAddresss { get; set; }
        public string DoctorCity { get; set; }
        public int? DoctorZipCode { get; set; }
        public int? StateId { get; set; }
        public int? Ssn { get; set; }
        public string DoctorMobile { get; set; }
        public string DoctorEmail { get; set; }

        public virtual Department Department { get; set; }
        public virtual States State { get; set; }
        public virtual ICollection<AdmissionH> AdmissionH { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
