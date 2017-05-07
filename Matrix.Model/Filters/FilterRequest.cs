using System.Collections.Generic;

namespace Matrix.Model.Filters
{
    public class FilterRequest
    {
        public List<string> event_fields { get; set; }
        public string event_format { get; set; }
        public Filter account_data { get; set; }
        public RoomFilter room { get; set; }
        public Filter presence { get; set; }
    }
}
