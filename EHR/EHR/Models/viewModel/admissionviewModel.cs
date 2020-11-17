using EHR.Database;
using System;
using System.Collections.Generic;

namespace EHR.Models.viewModel
{
    public class admissionviewModel
    {
        public int AdmissionHid { get; set; }
        public DateTime AdmissionDateTime { get; set; }
        public int PatientId { get; set; }
        public int RoomId { get; set; }
        public int DoctorId { get; set; }
        public bool Discharge { get; set; }
        public int InsuranceId { get; set; }


        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Insurance> insurances { get; set; }
    }
}
