﻿using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class AdmissionH
    {
        public AdmissionH()
        {
            AdmissionD = new HashSet<AdmissionD>();
        }

        public int AdmissionHid { get; set; }
        public DateTime AdmissionDateTime { get; set; }
        public int PatientId { get; set; }
        public int RoomId { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<AdmissionD> AdmissionD { get; set; }
    }
}
