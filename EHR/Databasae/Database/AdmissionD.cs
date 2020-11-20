using System;
using System.Collections.Generic;

namespace Databasae.Database
{
    public partial class AdmissionD
    {
        public int AdmissionDid { get; set; }
        public int AdmissionHid { get; set; }

        public virtual AdmissionH AdmissionH { get; set; }
    }
}
