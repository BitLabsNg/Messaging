using BitLabs.Messaging.Types;
using System;
using System.Threading.Tasks;

namespace BitLabs.Messaging.Services
{
    public abstract class MessagingService
    {
        public MessagingService(Credential credential)
        {
            if (credential == null)
                throw new ArgumentNullException(nameof(credential), $"{nameof(credential)} is required");

            if (string.IsNullOrEmpty(credential.CredentialHash))
                throw new ArgumentException(nameof(credential), "Invalid credencial provided");

            Credential = credential;
        }
        public abstract Task<string> SendAsync(IMessageType message);
        public abstract string Send(IMessageType message);
        public ServiceType ServiceType { get; protected set; }
        
        protected Credential Credential { get; private set; }
    }
}
