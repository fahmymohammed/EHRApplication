using System;
using System.Collections.Generic;

namespace Databasae.Database
{
    public partial class Department
    {
        public Department()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
