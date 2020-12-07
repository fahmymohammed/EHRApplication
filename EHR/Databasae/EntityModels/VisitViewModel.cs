using Databasae.Database;
using System;
using System.Collections.Generic;

namespace Databasae.EntityModels
{
    public partial class VisitViewModel
    {
        public VisitViewModel()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int VisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
