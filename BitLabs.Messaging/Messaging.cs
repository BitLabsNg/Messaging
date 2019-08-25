using BitLabs.Messaging.Services;
using BitLabs.Messaging.Services.Factory;
using BitLabs.Messaging.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitLabs.Messaging
{
    public class Messaging
    {

        private readonly Dictionary<ServiceType, AbstractMessagingServiceFactory> _factories;

        /// <summary>
        /// Create an instance of BitLabs MessagingService.
        /// This is the entry point for all service types.
        /// </summary>
        public Messaging()
        {

            _factories = new Dictionary<ServiceType, AbstractMessagingServiceFactory>();
            foreach (ServiceType @type in Enum.GetValues(typeof(ServiceType)))
            {
                /// Wrap in try-catch for fault tolerance
                try
                {
                    _factories.Add(
                        @type,
                        (AbstractMessagingServiceFactory)Activator.CreateInstance(
                            Type.GetType("BitLabs.Messaging.Services.Factory." + Enum.GetName(typeof(ServiceType), @type) + "MessagingServiceFactory")
                            ));
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// MessagingService Factory .
        /// Use to create instance of available messaging types.
        /// </summary>
        /// <param name="serviceType">Messaging Type you need an instance of</param>
        /// <param name="credential">Your BitLabs Messaging credential. Required for connection to the remote service API</param>
        /// <returns>An instantiated Messaging Service that can then be used to carry out your messaging operations.</returns>
        public MessagingService GetServiceInstance(ServiceType serviceType, Credential credential)
        {
            if (_factories == null || _factories.Any() == false)
                throw new Exception("No factories is available");

            try
            {
                return _factories[serviceType].CreateServiceInstance(credential);
            }
            catch(KeyNotFoundException e)
            {
                throw new ServiceNotImplementedException("Implementation not available", e);
            }
        }
    }



 
}
