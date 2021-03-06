﻿using Databasae.Database;
using System;

namespace Databasae.EntityModels
{
    public partial class PrescriptionViewModel
    {
        public int PrescriptionHid { get; set; }
        public DateTime PrescriptionHdate { get; set; }
        public int VisitId { get; set; }
        public int MedicineId { get; set; }
        public string Note { get; set; }
        public double? Cost { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
