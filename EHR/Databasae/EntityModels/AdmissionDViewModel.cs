using Databasae.Database;
namespace Databasae.EntityModels
{
    public partial class AdmissionDViewModel
    {
        public int AdmissionDid { get; set; }
        public int AdmissionHid { get; set; }

        public virtual AdmissionH AdmissionH { get; set; }
    }
}
