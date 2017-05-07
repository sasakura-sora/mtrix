using Matrix.DataStore.Interfaces;
using Matrix.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.DataStore
{
    public class RoomRepository : IRoomRepository
    {
        public async Task<List<PublicRoomsChunk>> PublicRooms()
        {
            var result = new List<PublicRoomsChunk>
            {
                Template.PublicRooms.RoomChunk
            };

            result.AddRange(Memory.RoomStore.Rooms);

            return result;
        }

        public async Task<string> CreateRoom(PublicRoomsChunk newRoom)
        {
            newRoom.room_id = Guid.NewGuid().ToString();
            Memory.RoomStore.Rooms.Add(newRoom);
            
            return newRoom.room_id;
        }
    }
}
