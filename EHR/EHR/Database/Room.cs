using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class Room
    {
        public Room()
        {
            AdmissionH = new HashSet<AdmissionH>();
        }

        public int RoomId { get; set; }
        public int TotalBeds { get; set; }
        public int AvailBeds { get; set; }

        public virtual ICollection<AdmissionH> AdmissionH { get; set; }
    }
}
