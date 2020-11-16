using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class Category
    {
        public Category()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
