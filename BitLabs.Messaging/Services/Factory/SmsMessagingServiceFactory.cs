using BitLabs.Messaging.Types;

namespace BitLabs.Messaging.Services.Factory
{
    public class SmsMessagingServiceFactory : AbstractMessagingServiceFactory
    {
        public override MessagingService CreateServiceInstance(Credential credential)
        {
            return
            new SmsService(credential);
        }
    }
}
