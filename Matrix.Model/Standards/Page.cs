using System.Collections.Generic;

namespace Matrix.Model.Standards
{
    public class Page
    {
        public Page()
        {
            chunk = new List<Chunk>();
        }

        public List<Chunk> chunk { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}
