using Matrix.Model.Events;
using System.Threading.Tasks;

namespace Matrix.DataStore.Interfaces
{
    public interface IRoomEventRepository
    {
        Task EventAdd(string roomId, BaseEvent state_event);
    }
}
