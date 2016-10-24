using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TaskServer
{
    abstract class AbstractMessage
    {
        [Serializable]
        public enum Messagetype
        {
            OPENCON,
            CLOSECON,
            POSTTASK,
            DELETETASK,
            GETTASKS,
            SUCCES,
            FAIL
        };
        
        public abstract Messagetype getMessageType();
    }
}
