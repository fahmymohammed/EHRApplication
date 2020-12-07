﻿using Databasae.Database;
namespace Databasae.EntityModels
{
    public partial class BillViewModel
    {
        public int BillId { get; set; }
        public int PatientId { get; set; }
        public double DoctorCharge { get; set; }
        public double MedicineCharge { get; set; }
        public double RoomCharge { get; set; }
        public double OperationCharge { get; set; }
        public double NursingCharge { get; set; }
        public double AdditionalCharge { get; set; }
        public int StayPeriod { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
