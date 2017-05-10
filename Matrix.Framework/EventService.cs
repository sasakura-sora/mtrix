using Matrix.DataStore;
using Matrix.DataStore.Interfaces;
using Matrix.Framework.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Model.Events;
using System;

namespace Matrix.Framework
{
    public class EventService : IEventService
    {
        private IRoomRepository roomRepo { get; set; }

        public EventService()
        {
            roomRepo = new RoomMemoryRepository();
        }

        public async Task<List<string>> Members(string roomId)
        {
            //A list of members of the room. 
            var members = await roomRepo.Members(roomId);
            //If you are joined to the room then this will be the current members of the room. 
            //If you have left the room then this will be the members of the room when you left.

            return members;
        }

        public async Task<List<StateEvent>> StatesGet(string roomId)
        {
            return new List<StateEvent>();
        }

        public async Task<StateEvent> StateGet(string roomId, string eventType)
        {
            return new StateEvent();
        }

        public async Task<StateEvent> StateGet(string roomId, string eventType, string stateKey)
        {
            return new StateEvent();
        }

        public async Task<string> StateAdd(string roomId, string eventType, BaseEvent event_thing)
        {
            return "";
        }

        public async Task<string> StateAdd(string roomId, string eventType, BaseEvent event_thing, string stateKey)
        {
            return "";
        }
    }
}
