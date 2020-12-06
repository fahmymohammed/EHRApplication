using Databasae.Database;
using System.Threading.Tasks;

namespace Service
{
    public static class Factory
    {
        public static Department CreateDepartment()
        {
            return new Department();
        }

        public static Bill CreateBill()
        {
            return new Bill();
        }

        public static Visit CreateVisit()
        {
            return new Visit();
        }

        public static Gender CreateGender()
        {
            return new Gender();
        }

        public static AdmissionD CreateAdmissionD()
        {
            return new AdmissionD();
        }

        public static async Task<AdmissionH> CreateAdmissionH()
        {
            return await Task.Run(() => new AdmissionH());
        }

        public static RoomType CreateRoomType()
        {
            return new RoomType();
        }

        public static Room CreateRoom()
        {
            return new Room();
        }

        public static Patient CreatePatient()
        {
            return new Patient();
        }

        public static States CreateStates()
        {
            return new States();
        }

        public static Doctor CreateDoctor()
        {
            return new Doctor();
        }

        public static Medicine CreateMedicine()
        {
            return new Medicine();
        }

        public static Prescription CreatePrescription()
        {
            return new Prescription();
        }

        public static Insurance CreateInsurance()
        {
            return new Insurance();
        }

    }
}
