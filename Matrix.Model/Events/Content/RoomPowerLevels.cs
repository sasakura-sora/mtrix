using System.Collections.Generic;

namespace Matrix.Model.Events.Content
{
    public class RoomPowerLevels
    {
        public int events_default { get; set; }
        public int invite { get; set; }
        public int state_default { get; set; }
        public int redact { get; set; }
        public int users_default { get; set; }
        public KeyValuePair<string, int> events { get; set; }
        public int kick { get; set; }
        public KeyValuePair<string, int> users { get; set; }
    }
}
