﻿using Matrix.Framework;
using Matrix.Framework.Interfaces;
using Matrix.Model;
using Matrix.Model.Events;
using Matrix.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Matrix.Server.Controllers
{
    public class RoomsController : ApiController
    {
        private readonly IRoomService roomService;
        private readonly IEventService eventService;

        public RoomsController()
        {
            var memoryStore = new DataStore.RoomMemoryRepository();
            eventService = new EventService();

            roomService = new RoomService(memoryStore, eventService);

            
        }

        [HttpPost]
        [Route("createRoom")]
        public async Task<RoomCreateResponse> CreateRoom(RoomCreate createRoom)
        {
            return await roomService.Create(createRoom);
        }

        //TODO: Rate limiting
        [HttpPost]
        [Route("rooms/{roomId}/invite")]
        public Model.Standards.Error Invite(string roomId, Invite roomInvite)
        {
            //TODO: Get the user from auth
            //Check user can invite into that room
            roomService.Invite(roomInvite.user_id, roomId);
            //send invite event to that user
            return new Model.Standards.Error();
        }

        [HttpPost]
        [Route("join/{roomIdOrAlias}")]
        public async Task<Model.Standards.Error> AliasInvite(string roomIdOrAlias, ThirdPartySigned signature)
        {
            //work out if roomId or Alias
            var aliasId = await roomService.AliasFind(roomIdOrAlias);
            PublicRoomsChunk room;
            if (aliasId != "")
            {
                room = await roomService.IdFind(aliasId);
            }
            else
            {
                room = await roomService.IdFind(roomIdOrAlias);
            }
                        
            if(room.room_id != "")
            {
                await roomService.Join("", room.room_id);
                return new Model.Standards.Error();
            }

            //return roomid
            return new Model.Standards.Error();
        }

        [HttpPost]
        [Route("rooms/{roomId}/join")]
        public Model.Standards.Error Join(string roomId, ThirdPartySigned signature)
        {
            roomService.Join("", roomId);
            return new Model.Standards.Error();
        }

        [HttpPost]
        [Route("rooms/{roomId}/forget")]
        public Model.Standards.Error Forget(string roomId)
        {
            roomService.Forget("", roomId);
            return new Model.Standards.Error();
        }

        [HttpPost]
        [Route("rooms/{roomId}/leave")]
        public Model.Standards.Error Leave(string roomId)
        {
            roomService.Leave("", roomId);
            return new Model.Standards.Error();
        }

        [HttpPost]
        [Route("rooms/{roomId}/kick")]
        public Model.Standards.Error Kick(string roomId, Kick kick)
        {
            roomService.Kick("", roomId);
            return new Model.Standards.Error();
        }

        [HttpPost]
        [Route("rooms/{roomId}/ban")]
        public Model.Standards.Error Ban(string roomId, Kick ban)
        {
            roomService.Ban("", roomId);
            return new Model.Standards.Error();
        }

        [HttpPost]
        [Route("rooms/{roomId}/unban")]
        public Model.Standards.Error UnBan(string roomId, Kick unban)
        {
            roomService.UnBan("", roomId);
            return new Model.Standards.Error();
        }

        [HttpGet]
        [Route("publicRooms")]
        public async Task<Model.Standards.Page> PublicRooms()
        {
            return await roomService.PublicRooms();
        }

        /* - Events stuff below here */

        [HttpGet]
        [Route("rooms/{roomId}/state")]
        public async Task<List<StateEvent>> State(string roomId)
        {
            return await eventService.StatesGet(roomId);
        }

        [HttpGet]
        [Route("rooms/{roomId}/state/{eventType}")]
        public async Task<StateEvent> StateGet(string roomId, string eventType)
        {
            return await eventService.StateGet(roomId, eventType);
        }

        [HttpPut]
        [Route("rooms/{roomId}/state/{eventType}")]
        public async Task<string> StatePut(string roomId, string eventType, [FromBody]BaseEvent event_object)
        {
            return await eventService.StateAdd(roomId, eventType, event_object);
        }

        [HttpGet]
        [Route("rooms/{roomId}/state/{eventType}/{stateKey}")]
        public async Task<StateEvent> StateKeyGet(string roomId, string eventType, string stateKey)
        {
            return await eventService.StateGet(roomId, eventType, stateKey);
        }

        [HttpPut]
        [Route("rooms/{roomId}/state/{eventType}/{stateKey}")]
        public async Task<string> StateKeyPut(string roomId, string eventType, string stateKey, [FromBody]BaseEvent event_object)
        {
            return await eventService.StateAdd(roomId, eventType, event_object, stateKey);
        }

        [HttpPut]
        [Route("rooms/{roomId}/send/{eventType}/{txnId}")]
        public string Send(string roomId, string eventType, string txnId)
        {
            return "";
        }
        
        [HttpGet]
        [Route("rooms/{roomId}/members")]
        public async Task<List<MemberEvent>> Members(string roomId)
        {
            return await eventService.Members(roomId);
        }

        [HttpGet]
        [Route("rooms/{roomId}/messages")]
        public List<MemberEvent> Messages(string roomId, string from, string to, char dir, int limit = 10)
        {
            return new List<MemberEvent>();
        }
    }
}
