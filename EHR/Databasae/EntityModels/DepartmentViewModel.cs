using Databasae.Database;
using System.Collections.Generic;

namespace Databasae.EntityModels
{
    public partial class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
