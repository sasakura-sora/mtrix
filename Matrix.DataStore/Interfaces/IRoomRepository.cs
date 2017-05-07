using Matrix.Model.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.DataStore.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<PublicRoomsChunk>> PublicRooms();
        Task<string> RoomCreate(PublicRoomsChunk newRoom);

        Task<PublicRoomsChunk> Room(string roomId);

        Task<List<string>> InviteList(string roomId);
        Task InviteAdd(string userId, string roomId);
        Task InviteRemove(string userId, string roomId);
    }
}
