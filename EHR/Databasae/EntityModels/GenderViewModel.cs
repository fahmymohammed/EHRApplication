
using Databasae.Database;
using System.Collections.Generic;

namespace Databasae.EntityModels
{
    public partial class GenderViewModel
    {
        public GenderViewModel()
        {
            Patient = new HashSet<Patient>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
