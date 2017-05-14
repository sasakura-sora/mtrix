namespace Matrix.Model.Events
{
    public class MessageEvent : BaseEvent
    {
        public MessageEvent()
        {
            this.type = "m.room.message";
        }

        public string body { get; set; }
        public string msgtype { get; set; }

        public string sender { get; set; }
        public string room_id { get; set; }
    }
}
