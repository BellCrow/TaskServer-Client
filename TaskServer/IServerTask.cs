using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;

namespace TaskServer
{
    interface IServerTask
    {
       void startTask(MessageCommunicator com);
       void requestStop();

    }
}
