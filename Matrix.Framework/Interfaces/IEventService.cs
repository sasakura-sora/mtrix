using Matrix.Model.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.Framework.Interfaces
{
    public interface IEventService
    {
        Task<List<MemberEvent>> Members(string roomId);
        Task<List<StateEvent>> StatesGet(string roomId);

        Task<StateEvent> StateGet(string roomId, string eventId);
        Task<StateEvent> StateGet(string roomId, string eventId, string stateKey);

        Task<string> StateAdd(string roomId, string eventType, BaseEvent event_object);
        Task<string> StateAdd(string roomId, string eventType, BaseEvent event_object, string stateKey);       
    }
}
