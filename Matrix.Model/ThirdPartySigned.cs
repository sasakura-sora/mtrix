using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Model
{
    public class ThirdPartySigned
    {
        public Signed signed { get; set; }
    }

    public class Signed
    {
        public string token { get; set; }
        public string mxid { get; set; }
        public string sender { get; set; }
        public string signatures { get; set; }
    }
}
