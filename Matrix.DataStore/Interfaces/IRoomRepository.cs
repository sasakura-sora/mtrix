using Matrix.Model.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.DataStore.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<PublicRoomsChunk>> PublicRooms();
        Task<string> RoomCreate(PublicRoomsChunk newRoom);

        Task<PublicRoomsChunk> RoomGet(string roomId);

        Task<List<string>> InviteList(string roomId);
        Task InviteAdd(string userId, string roomId);
        Task InviteRemove(string userId, string roomId);

        Task Join(string userId, string roomId);
        Task Leave(string userId, string roomId);

        Task<List<string>> Members(string roomId);

        Task Ban(string userId, string roomId);
        Task UnBan(string userId, string roomId);

        Task AliasAdd(string roomId, string alias);
        Task<string> AliasFind(string alias);
        Task AliasRemove(string roomId, string alias);

        Task<string> Find(string roomId);
    }
}
