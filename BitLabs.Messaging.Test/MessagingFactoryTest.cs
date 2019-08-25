using System;
using BitLabs.Messaging.Services;
using BitLabs.Messaging.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitLabs.Messaging.Test
{
    [TestClass]
    public class MessagingFactoryTest
    {
        [TestMethod]
        public void CreateServiceInstance_Returns_Instance_Of_Specified_Type()
        {
            var returnedService =
                new Messaging().GetServiceInstance(ServiceType.Sms, new Credential("studioruns", "3ratsass"));

            Assert.IsTrue(returnedService.ServiceType == ServiceType.Sms);
        }

        [TestMethod]
        public void CreateServiceInstance_Throws_An_Exception_When_Specifice_ServiceType_Is_Not_Implemented()
        {
            Assert.ThrowsException<ServiceNotImplementedException>(() => new Messaging().GetServiceInstance(ServiceType.WhatsApp, new Credential("studioruns", "3ratsass")));
        }
    }
}
