using Matrix.Model.Rooms;
using System.Collections.Generic;

namespace Matrix.DataStore.Memory
{
    public static class RoomStore
    {
        static RoomStore()
        {
            Members = new Dictionary<string, List<string>>();
            Bans = new Dictionary<string, List<string>>();
            Alias = new Dictionary<string, string>();
        }

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

        public static Dictionary<string, List<string>> Members;

        public static Dictionary<string, List<string>> Bans;

        public static Dictionary<string, string> Alias;
    }
}
