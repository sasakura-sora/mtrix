using Matrix.Framework;
using Matrix.Framework.Interfaces;
using Matrix.Model.Rooms.Alias;
using System.Web.Http;

namespace Matrix.Server.Controllers
{
    public class DirectoryController : ApiController
    {
        private readonly IRoomService roomService;

        public DirectoryController()
        {
            roomService = new RoomService();
        }

        [HttpPut]
        [Route("directory/room/{roomAlias}")]
        public Model.Standards.Error AddAlias(AliasCreate alias)
        {
            roomService.AliasAdd(alias);
            return new Model.Standards.Error();
        }

        [HttpDelete]
        [Route("directory/room/{roomAlias}")]
        public Model.Standards.Error DeleteAlias(string roomAlias)
        {
            roomService.AliasRemove(roomAlias);
            return new Model.Standards.Error();
        }

        [HttpGet]
        [Route("directory/room/{roomAlias}")]
        public Model.Standards.Error ResolveAlias(string roomAlias)
        {
            roomService.AliasFind(roomAlias);
            return new Model.Standards.Error();
        }
    }
}
