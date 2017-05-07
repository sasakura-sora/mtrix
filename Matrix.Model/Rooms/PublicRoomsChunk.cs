using Matrix.Model.Standards;
using System.Collections.Generic;

namespace Matrix.Model.Rooms
{
    public class PublicRoomsChunk : Chunk
    {
        public bool world_readable { get; set; }
        public string topic { get; set; }
        public int num_joined_members { get; set; }
        public string avatar_url { get; set; }
        public string room_id { get; set; }
        public bool guest_can_join { get; set; }
        public List<string> aliases { get; set; }
        public string name { get; set; }
    }
}
