using Matrix.Model.Events.Content;
using System.Collections.Generic;

namespace Matrix.Model.Events
{
    public class MemberEvent : BaseEvent
    {
        public MemberEvent()
        {
            this.type = "m.room.member";
        }

        public string prev_content { get; set; }
        public string sender { get; set; }
        public string event_id { get; set; }
        public string state_key { get; set; }   //The user_id this membership event relates to
        public BaseContent content { get; set; }
        public string room_id { get; set; }
        public List<string> invite_room_state { get; set; }
    }
}
