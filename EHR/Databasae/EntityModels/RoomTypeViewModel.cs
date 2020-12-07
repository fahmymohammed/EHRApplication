using Databasae.Database;
using System.Collections.Generic;

namespace Databasae.EntityModels
{
    public partial class RoomTypeViewModel
    {
        public RoomTypeViewModel()
        {
            Room = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
