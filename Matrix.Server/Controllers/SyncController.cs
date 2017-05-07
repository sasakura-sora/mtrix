using Matrix.Model.Events;
using System.Web.Http;

namespace Matrix.Server.Controllers
{
    public class SyncController : ApiController
    {
        [HttpGet]
        public BaseEvent Sync(string filter, string since, bool full_state, string set_presence, int timeout)
        {
            return new BaseEvent();
        }
            
    }
}
