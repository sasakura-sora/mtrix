namespace Matrix.Model.Events
{
    public class RoomEvent : BaseEvent
    {
        public string event_id { get; set; }
        public string room_id { get; set; }
        public string sender { get; set; }
    }
}
