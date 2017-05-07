using System.Collections.Generic;

namespace Matrix.Model.Filters
{
    public class RoomFilter
    {
        public bool include_leave { get; set; }
        public RoomEventFilter account_data { get; set; }
        public RoomEventFilter timeline { get; set; }
        public RoomEventFilter ephemeral { get; set; }
        public RoomEventFilter state { get; set; }

        public List<string> not_rooms { get; set; }
        public List<string> rooms { get; set; }
    }
}
