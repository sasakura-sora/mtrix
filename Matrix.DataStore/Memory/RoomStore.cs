using Matrix.Model.Rooms;
using System.Collections.Generic;

namespace Matrix.DataStore.Memory
{
    public static class RoomStore
    {
        private static List<PublicRoomsChunk> rooms { get; set; }

        public static List<PublicRoomsChunk> Rooms
        {
            get
            {
                if (rooms == null)
                {
                    rooms = new List<PublicRoomsChunk>();
                }
                return rooms;
            }
        }
    }
}
