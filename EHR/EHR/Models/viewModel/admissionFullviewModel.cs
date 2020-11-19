using EHR.Database;
using System;
using System.Collections.Generic;

namespace EHR.Models.viewModel
{
    public class admissionFullviewModel
    {
        public int AdmissionHid { get; set; }
        public DateTime AdmissionDateTime { get; set; }
        public int PatientId { get; set; }
        public int RoomId { get; set; }
        public int DoctorId { get; set; }
        public bool Discharge { get; set; }
        public int InsuranceId { get; set; }
        public int MedicineId { get; set; }
        public int VisitId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public int RoomNum { get; set; }
        public string InsuranceName { get; set; }
        public int PrescriptionHid { get; set; }



        public ICollection<Doctor> doctors { get; set; }
        public ICollection<Patient> patients { get; set; }
        public ICollection<Room> rooms { get; set; }
        public ICollection<Insurance> insurances { get; set; }
        public ICollection<Medicine> medicines { get; set; }
        public ICollection<Visit> visits { get; set; }
        public ICollection<PrescriptionH> prescriptionHs { get; set; }

        public admissionFullviewModel()
        {
            visits = new HashSet<Visit>();
            prescriptionHs = new HashSet<PrescriptionH>();
        }

    }
}
