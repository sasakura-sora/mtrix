using Matrix.Model.Filters;
using Matrix.Model.Profiles;
using System.Web.Http;

namespace Matrix.Server.Controllers
{
    public class ProfilesController : ApiController
    {
        [HttpPut]
        [Route("profile/{userId}/displayname")]
        public void DisplayName(string userId, DisplayName displayname )
        {
            return;
        }

        [HttpGet]
        [Route("profile/{userId}/displayname")]
        public DisplayName DisplayName(string userId)
        {
            return new DisplayName();
        }

        [HttpPut]
        [Route("profile/{userId}/avatar_url")]
        public void AvatarUrl(string userId, AvatarUrl avatarurl)
        {
            return;
        }

        [HttpGet]
        [Route("profile/{userId}/avatar_url")]
        public AvatarUrl AvatarUrl(string userId)
        {
            return new AvatarUrl();
        }

        [HttpGet]
        [Route("profile/{userId}")]
        public Profile Profile(string userId)
        {
            return new Profile();
        }

        [HttpGet]
        [Route("user/{userid}/filter/{filterId}")]
        public Filter Filter(string userId, string filterId)
        {
            return new Filter();
        }

        [HttpPost]
        [Route("user/{userId}/filter")]
        public void Filter(string userId, FilterRequest filterrequest)
        {

        }
    }
}
