using Databasae.Database;
using System.Collections.Generic;

namespace Databasae.EntityModels
{
    public partial class RoomViewModel
    {
        public RoomViewModel()
        {
            AdmissionH = new HashSet<AdmissionH>();
        }

        public int RoomId { get; set; }
        public int RoomNum { get; set; }
        public int TotalBeds { get; set; }
        public int AvailableBeds { get; set; }
        public int RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<AdmissionH> AdmissionH { get; set; }
    }
}
