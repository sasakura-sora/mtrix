using Matrix.Model.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.DataStore.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<PublicRoomsChunk>> PublicRooms();
        Task<string> CreateRoom(PublicRoomsChunk newRoom);
    }
}
