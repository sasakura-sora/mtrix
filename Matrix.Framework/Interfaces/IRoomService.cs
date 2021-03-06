﻿using Matrix.Model.Rooms;
using Matrix.Model.Rooms.Alias;
using Matrix.Model.Standards;
using System.Threading.Tasks;

namespace Matrix.Framework.Interfaces
{
    public interface IRoomService
    {
        Task<Page> PublicRooms();
        Task<RoomCreateResponse> Create(RoomCreate createRoom);

        Task Invite(string userId, string roomId);
        Task Join(string userId, string roomId);
        Task Forget(string userId, string roomId);
        Task Leave(string userId, string roomId);
        Task Kick(string userId, string roomid);

        Task Ban(string userId, string roomId);
        Task UnBan(string userId, string roomId);

        Task<PublicRoomsChunk> IdFind(string roomId);

        Task<string> AliasFind(string alias);
        Task<string> AliasAdd(AliasCreate alias);
        Task<string> AliasRemove(string alias);        
    }
}
