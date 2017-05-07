using Matrix.Framework;
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

        public RoomsController()
        {
            roomService = new RoomService();
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
            roomService.Invite("", roomId);
            return new Model.Standards.Error();
        }

        [HttpPost]
        [Route("join/{roomIdOrAlias}")]
        public Model.Standards.Error AliasInvite(string roomIdOrAlias, ThirdPartySigned signature)
        {
            //work out if roomId or Alias
            //neither -> error
            //Alias -> look up roomId
            roomService.Join("", "");

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
        public List<StateEvent> State(string roomId)
        {
            return new List<StateEvent>();
        }

        [HttpGet]
        [Route("rooms/{roomId}/state/{eventType}")]
        public StateEvent StateGet(string roomId, string eventType)
        {
            return new StateEvent();
        }

        [HttpPut]
        [Route("rooms/{roomId}/state/{eventType}")]
        public string StatePut(string roomId, string eventType)
        {
            return "";
        }

        [HttpGet]
        [Route("rooms/{roomId}/state/{eventType}/{stateKey}")]
        public StateEvent StateKeyGet(string roomId, string eventType, string stateKey)
        {
            return new StateEvent();
        }

        [HttpPut]
        [Route("rooms/{roomId}/state/{eventType}/{stateKey}")]
        public string StateKeyPut(string roomId, string eventType, string stateKey)
        {
            return "";
        }

        [HttpPut]
        [Route("rooms/{roomId}/send/{eventType}/{txnId}")]
        public string Send(string roomId, string eventType, string txnId)
        {
            return "";
        }
        
        [HttpGet]
        [Route("rooms/{roomId}/members")]
        public List<MemberEvent> Members(string roomId)
        {
            roomService.Members(roomId);
            return new List<MemberEvent>();
        }

        [HttpGet]
        [Route("rooms/{roomId}/messages")]
        public List<MemberEvent> Messages(string roomId, string from, string to, char dir, int limit = 10)
        {
            return new List<MemberEvent>();
        }
    }
}
