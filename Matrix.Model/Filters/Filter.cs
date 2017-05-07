using System.Collections.Generic;

namespace Matrix.Model.Filters
{
    public class Filter
    {
        public List<string> not_types { get; set; }
        public int limit { get; set; }
        public List<string> senders { get; set; }
        public List<string> types { get; set; }
        public List<string> not_senders { get; set; }
    }
}
