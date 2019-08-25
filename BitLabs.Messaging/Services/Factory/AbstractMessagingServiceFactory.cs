using BitLabs.Messaging.Types;

namespace BitLabs.Messaging.Services.Factory
{
    public abstract class AbstractMessagingServiceFactory
    {
        public abstract MessagingService CreateServiceInstance(Credential credential);
    }

}
