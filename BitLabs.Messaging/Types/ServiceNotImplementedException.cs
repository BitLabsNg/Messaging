using System;
using System.Collections.Generic;
using System.Text;

namespace BitLabs.Messaging.Types
{
    /// <summary>
    /// ServiceNotImplementedException indicates that the ServiceType you attempted to instantiate does not have an implementation.
    /// Using a more recent API version may give you access to the required service.
    /// </summary>
    public class ServiceNotImplementedException : Exception
    {
        public ServiceNotImplementedException(string message,Exception innerException):base(message, innerException)
        {
        }
    }
}
