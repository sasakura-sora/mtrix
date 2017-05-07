using Matrix.Model.Rooms;

namespace Matrix.DataStore.Template
{
    public static class PublicRooms
    {
        public static PublicRoomsChunk RoomChunk
        {
            get
            {
                return new PublicRoomsChunk()
                {
                    world_readable = true,
                    topic = "test topic",
                    num_joined_members = 0,
                    room_id = "1A",
                    guest_can_join = false,
                    name = "test room"
                };
            }
        }
    }
}
