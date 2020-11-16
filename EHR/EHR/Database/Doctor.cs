using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class Doctor
    {
        public Doctor()
        {
            AdmissionH = new HashSet<AdmissionH>();
        }

        public int DoctorId { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<AdmissionH> AdmissionH { get; set; }
    }
}
