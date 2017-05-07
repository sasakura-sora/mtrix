using System.Threading.Tasks;
using Matrix.Framework.Interfaces;
using Matrix.Model.Standards;
using Matrix.DataStore.Interfaces;
using Matrix.DataStore;
using Matrix.Model.Rooms;
using System;

namespace Matrix.Framework
{
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepo { get; set; }

        public RoomService()
        {
            roomRepo = new RoomMemoryRepository();
        }

        public async Task<Page> PublicRooms()
        {
            var rooms = await roomRepo.PublicRooms();

            var page = new Page
            {
                start = "",
                end = ""
            };

            page.chunk.AddRange(rooms);

            return page;
        }

        public async Task<RoomCreateResponse> Create(RoomCreate createRoom)
        {
            //Create room
            var newRoomChunk = new PublicRoomsChunk();

            //TODO: Mappers?
            newRoomChunk.name = createRoom.name;

            //if visiblilty is null set to private

            //Set states
            foreach (var state in createRoom.initial_state)
            {   
                //set state
            }

            //Not name or topic states
            newRoomChunk.topic = createRoom.topic;
            newRoomChunk.name = createRoom.name;
            
            var newId = await roomRepo.CreateRoom(newRoomChunk);

            foreach (var user in createRoom.invite)
            {
                await Invite(user, newId);
            }

            return new RoomCreateResponse()
            {
                room_id = newId
            };
        }

        public async Task Invite(string userId, string roomId)
        {
            //add userId to the list of invitiees for roomId
            var inviteList = await roomRepo.InviteList(roomId);

            //check ban list
            if (!inviteList.Contains(userId))
            {
                await roomRepo.InviteAdd(userId, roomId);
            }
        }

        public async Task Join(string userId, string roomId)
        {
            //check if public
            var room = await roomRepo.Room(roomId);
            if (room.guest_can_join)
            {
                //public -> invite and join
                return;
            }

            var invites = await roomRepo.InviteList(roomId);
            if (invites.Contains(userId))
            {
                //in invite list -> join
            }

            return;//rejected
        }

        public async Task Forget(string userId, string roomId)
        {
            //leave room
            //probably nothing
            //drops history if everyone forgets it
        }

        public async Task Leave(string userId, string roomId)
        {
            //check if in room
            //not -> reject pending invite
            //yes -> leave
        }

        public async Task Kick(string userId, string roomid)
        {
            //check admin level
            //clear pending invites?
            //leave room
        }

        public async Task Members(string roomId)
        {
            //A list of members of the room. 
            //If you are joined to the room then this will be the current members of the room. 
            //If you have left te room then this will be the members of the room when you left.
        }

        public async Task Ban(string userId, string roomId)
        {
            //check admin level
            //clear invites
            //leave them
            //add to ban list
        }

        public async Task UnBan(string userId, string roomId)
        {
            //check admin level
            //remove from ban list            
        }
    }
}
