using BitLabs.Messaging.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitLabs.Messaging.Types
{
    public class SmsMessage:IMessageType
    {

        public string Receipient { get; protected set; }
        public string Message { get; protected set; }
        public string Sender { get; private set; }


        private readonly int SENDER_LENGTH = 11;

        public static string DefaultSender { get; set; } = "TeamNigeria";

        public SmsMessage()
        {
        }
        /// <summary>
        /// Creates an SmsMessage object that can be used for sending an sms message. 
        /// The resulting object is immutable.
        /// </summary>
        /// <param name="receipient">Telephone number of intended receipient (e.g. 23480283948373).
        /// Separate multiple receipients with comma(,).
        /// </param>
        /// <param name="message">The message to be sent as sms.
        /// Sms messages generally have a 140 character page.
        /// </param>
        public SmsMessage(string receipient, string message) :this(receipient, message, DefaultSender)
        {
        }

        /// <summary>
        /// Creates an SmsMessage object that can be used for sending an sms message. 
        /// The resulting object is immutable.
        /// </summary>
        /// <param name="receipient">
        /// Telephone number of intended receipient (e.g. 23480283948373).
        /// Separate multiple receipients with comma(,).
        /// </param>
        /// <param name="message">The message to be sent as sms.
        /// Sms messages generally have a 140 character page.
        /// </param>
        /// <param name="sender">The sender the receipient will see on their device</param>
        public SmsMessage(string receipient,string message, string sender):this()
        {
            SetReceipient(receipient);

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message), $"{nameof(message)} must be provided");

            Message = message;

            SetSender(sender);
        }

        private void SetReceipient(string receipient)
        {
            if (string.IsNullOrEmpty(receipient))
                throw new ArgumentNullException(nameof(receipient), $"{nameof(receipient)} must be provided");

            Receipient = receipient;
        }
        private void SetSender(string sender)
        {
            if (string.IsNullOrEmpty(sender))
                throw new ArgumentNullException(nameof(sender), $"{nameof(sender)} is required");

            if (sender.Length > 11)
                throw new ArgumentOutOfRangeException(nameof(sender), $"{nameof(sender)} cannot be more than {11}");

            Sender = sender;
        }
    }
}
