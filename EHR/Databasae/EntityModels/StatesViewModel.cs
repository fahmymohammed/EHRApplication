using Databasae.Database;
using System.Collections.Generic;

namespace Databasae.EntityModels
{
    public partial class StatesViewModel
    {
        public StatesViewModel()
        {
            Doctor = new HashSet<Doctor>();
            Patient = new HashSet<Patient>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
