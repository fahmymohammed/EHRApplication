using Databasae.Database;
using System;
using System.Collections.Generic;

namespace Databasae.EntityModels
{
    public partial class MedicineViewModel
    {
        public MedicineViewModel()
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
