using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string content { get; set; }
        public string room_id { get; set; }
        public List<string> invite_room_state { get; set; }
    }
}
