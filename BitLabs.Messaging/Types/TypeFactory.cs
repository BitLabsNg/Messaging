using System;
using System.Collections.Generic;
using System.Text;

namespace BitLabs.Messaging.Types
{
    public class TypeFactory
    {
        public static IMessageType CreateSmsMessage(SmsMessage sms)
        {
            return sms;
        }
    }
}
