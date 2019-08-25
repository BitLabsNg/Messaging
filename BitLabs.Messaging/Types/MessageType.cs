using System;
using System.Collections.Generic;
using System.Text;

namespace BitLabs.Messaging.Types
{
    public abstract class MessageType: IMessageType
    {
        public abstract string Message { get;  set; }
        public abstract string Receipient { get; set; }
    }

    public interface IMessageType
    {
         string Message { get; }
         string Receipient { get;}

    }
}
