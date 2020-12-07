using Databasae.Database;
using System;
using System.Collections.Generic;

namespace Databasae.EntityModels
{
    public partial class AdmissionHViewModel
    {
        public AdmissionHViewModel()
        {
            AdmissionD = new HashSet<AdmissionD>();
        }

        public int AdmissionHid { get; set; }
        public DateTime AdmissionDateTime { get; set; }
        public int PatientId { get; set; }
        public int RoomId { get; set; }
        public int DoctorId { get; set; }
        public bool Discharge { get; set; }
        public int InsuranceId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Insurance Insurance { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<AdmissionD> AdmissionD { get; set; }
    }
}
