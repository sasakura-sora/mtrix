using Matrix.Model.Events;
using System.Collections.Generic;

namespace Matrix.Model.Rooms
{
    public class RoomCreate
    {
        public RoomCreate()
        {
            invite = new List<string>();
            invite_3pid = new List<Invite3pid>();
            initial_state = new List<StateEvent>();
        }


        public List<string> invite { get; set; }
        public string name { get; set; }
        public Visibility visibility { get; set; }
        
        public List<Invite3pid> invite_3pid { get; set; }

        public string topic { get; set; }
        public Preset preset { get; set; }
        public string creation_content { get; set; }
        public List<StateEvent> initial_state { get; set; }
        public string room_alias_name { get; set; }
    }
}
