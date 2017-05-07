using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Model.Events
{
    public class RoomEvent : BaseEvent
    {
        public string event_id { get; set; }
        public string room_id { get; set; }
        public string sender { get; set; }
    }
}
