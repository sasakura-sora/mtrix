using Matrix.Model.Events;

namespace Matrix.Model.Messages
{
    public class MessageLocation : MessageEvent
    {
        public MessageLocation()
        {
            this.type = "m.location";
        }

        public string geo_uri { get; set; }
    }
}
