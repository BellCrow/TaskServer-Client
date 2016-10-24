using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskServer.Messages
{
    class OpenConMsg:AbstractMessage
    {
        Messagetype _type;
        public OpenConMsg()
        {}
        public override AbstractMessage.Messagetype getMessageType()
        {
            return _type;
        }
    }
}
