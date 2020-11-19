using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class Medicine
    {
        public Medicine()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public double MedicinePrice { get; set; }
        public DateTime MedicineexpiredDate { get; set; }
        public string MedicineDoseNote { get; set; }

        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
