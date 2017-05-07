using Matrix.Model.Rooms.Alias;
using System.Web.Http;

namespace Matrix.Server.Controllers
{
    public class DirectoryController : ApiController
    {
        [HttpPut]
        [Route("directory/room/{roomAlias}")]
        public Model.Standards.Error AddAlias(AliasCreate alias)
        {
            return new Model.Standards.Error();
        }

        [HttpDelete]
        [Route("directory/room/{roomAlias}")]
        public Model.Standards.Error DeleteAlias(string roomAlias)
        {
            return new Model.Standards.Error();
        }

        [HttpGet]
        [Route("directory/room/{roomAlias}")]
        public Model.Standards.Error ResolveAlias(string roomAlias)
        {
            return new Model.Standards.Error();
        }
    }
}
