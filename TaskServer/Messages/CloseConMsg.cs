using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskServer.Messages
{
    class CloseConMsg:AbstractMessage
    {
        Messagetype _type;
        public CloseConMsg()
        {}
        public override AbstractMessage.Messagetype getMessageType()
        {
            return _type;
        }
    }
}
