using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Model.Filters
{
    public class RoomEventFilter
    {
        public List<string> not_types { get; set; }
        public List<string> not_rooms { get; set; }
        public int limit { get; set; }
        public List<string> rooms { get; set; }
        public List<string> not_senders { get; set; }
        public List<string> senders { get; set; }
        public List<string> types { get; set; }
    }
}
