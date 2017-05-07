using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Model.Events
{
    public class StateEvent : BaseEvent
    {
        public string prev_content { get; set; }
        public string state_key { get; set; }
    }
}
