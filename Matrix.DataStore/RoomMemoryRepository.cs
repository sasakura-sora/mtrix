using Matrix.DataStore.Interfaces;
using Matrix.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.DataStore
{
    public class RoomMemoryRepository : IRoomRepository
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

        public async Task<string> RoomCreate(PublicRoomsChunk newRoom)
        {
            newRoom.room_id = Guid.NewGuid().ToString();
            Memory.RoomStore.Rooms.Add(newRoom);
            
            return newRoom.room_id;
        }
        
        public async Task<PublicRoomsChunk> RoomGet(string roomId)
        {
            return Memory.RoomStore.Rooms.Find(x => x.room_id == roomId);
        }

        public async Task<List<string>> InviteList(string roomId)
        {
            return Memory.InviteStore.Invites[roomId];
        }

        public async Task InviteAdd(string userId, string roomId)
        {
            Memory.InviteStore.Invites[roomId].Add(userId);
        }

        public async Task InviteRemove(string userId, string roomId)
        {
            Memory.InviteStore.Invites[roomId].Remove(userId);
        }

        public async Task Join(string userId, string roomid)
        {
            Memory.RoomStore.Members[roomid].Add(userId);
        }

        public async Task Leave(string userId, string roomid)
        {
            Memory.RoomStore.Members[roomid].Remove(userId);
        }

        public async Task<List<string>> Members(string roomid)
        {
            return Memory.RoomStore.Members[roomid];
        }

        public async Task Ban(string userId, string roomId)
        {
            Memory.RoomStore.Bans[roomId].Add(userId);
        }

        public async Task UnBan(string userId, string roomId)
        {
            Memory.RoomStore.Bans[roomId].Remove(userId);
        }

        public async Task AliasAdd(string roomId, string alias)
        {
            Memory.RoomStore.Alias.Add(alias, roomId);
        }

        public async Task<string> AliasFind(string alias)
        {
            return Memory.RoomStore.Alias[alias];
        }

        public async Task AliasRemove(string roomId, string alias)
        {
            Memory.RoomStore.Alias.Remove(alias);
        }

        public async Task<string> Find(string roomId)
        {
            return Memory.RoomStore.Rooms.Find(x => x.room_id == roomId).room_id;
        }
    }
}
