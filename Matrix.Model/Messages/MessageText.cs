using Matrix.Model.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Model.Messages
{
    public class MessageText : MessageEvent
    {
        public MessageText()
        {
            this.msgtype = "m.text";
        }
    }
}
