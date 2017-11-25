using System.Threading.Tasks;
using Matrix.Framework.Interfaces;
using Matrix.Model.Standards;
using Matrix.DataStore.Interfaces;
using Matrix.Model.Rooms;
using Matrix.Model.Rooms.Alias;
using CuttingEdge.Conditions;

namespace Matrix.Framework
{
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepo { get; set; }
        private IEventService events { get; set; }

        public RoomService(IRoomRepository roomRepo, IEventService eventsService)
        {
            Condition.Requires(roomRepo).IsNotNull();
            Condition.Requires(eventsService).IsNotNull();

            this.roomRepo = roomRepo;
            this.events = eventsService;
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

            //string.Compare("", "", System.Globalization.CompareOptions.OrdinalIgnoreCase);

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
            
            var newId = await roomRepo.RoomCreate(newRoomChunk);

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
            var room = await roomRepo.RoomGet(roomId);
            if (room.guest_can_join)
            {
                //public -> invite and join
                await roomRepo.InviteAdd(userId, roomId);
                await roomRepo.Join(userId, roomId);
                await roomRepo.InviteRemove(userId, roomId);
                return;
            }

            var invites = await roomRepo.InviteList(roomId);
            if (invites.Contains(userId))
            {
                //in invite list -> join
                await roomRepo.Join(userId, roomId);
                await roomRepo.InviteRemove(userId, roomId);
                //event it
            }

            return;//rejected
        }

        public async Task Forget(string userId, string roomId)
        {
            //leave room
            await this.Leave(userId, roomId);
            //probably nothing
            //drops history if everyone forgets it
        }

        public async Task Leave(string userId, string roomId)
        {
            var members = await roomRepo.Members(roomId);
            if (members.Contains(userId))
            {
                await roomRepo.Leave(userId, roomId);
            }
            
            var invites = await roomRepo.InviteList(roomId);
            if (invites.Contains(userId))
            {
                await roomRepo.InviteRemove(userId, roomId);
            }
        }

        public async Task Kick(string userId, string roomId)
        {
            //check admin level
            //clear pending invites
            //leave room
            await this.Leave(userId, roomId);
        }        

        public async Task Ban(string userId, string roomId)
        {
            //check admin level
            //clear invites
            await this.Leave(userId, roomId);
            //leave them
            await roomRepo.Ban(userId, roomId);
            //add to ban list
        }

        public async Task UnBan(string userId, string roomId)
        {
            //check admin level
            //remove from ban list            
            await roomRepo.UnBan(userId, roomId);
        }

        public async Task<PublicRoomsChunk> IdFind(string roomId)
        {
            return await roomRepo.IdFind(roomId);
        }

        public async Task<string> AliasFind(string alias)
        {
            return await roomRepo.AliasFind(alias);
        }       

        public async Task<string> AliasAdd(AliasCreate alias)
        {
            await roomRepo.AliasAdd("", "");

            return "";
        }

        public async Task<string> AliasRemove(string alias)
        {
            await roomRepo.AliasRemove("", alias);
            return "";
        }
    }
}
