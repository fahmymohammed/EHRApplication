using Databasae.Database;
using System.Collections.Generic;

namespace Databasae.EntityModels
{
    public partial class InsuranceViewModel
    {
        public InsuranceViewModel()
        {
            AdmissionH = new HashSet<AdmissionH>();
        }

        public int InsuranceId { get; set; }
        public string InsuranceName { get; set; }

        public virtual ICollection<AdmissionH> AdmissionH { get; set; }
    }
}
