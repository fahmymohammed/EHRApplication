using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class Medicine
    {
        public Medicine()
        {
            AdmissionD = new HashSet<AdmissionD>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public double MedicinePrice { get; set; }
        public DateTime MedicineexpiredDate { get; set; }
        public string MedicineDoseNote { get; set; }

        public virtual ICollection<AdmissionD> AdmissionD { get; set; }
    }
}
