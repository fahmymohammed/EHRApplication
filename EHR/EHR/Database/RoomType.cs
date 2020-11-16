using System;
using System.Collections.Generic;

namespace EHR.Database
{
    public partial class RoomType
    {
        public RoomType()
        {
            Room = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
