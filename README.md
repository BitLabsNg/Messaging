# Messaging
BitLabs Messaging Sdk

Usage.


var response = 
  new Messaging()
      .GetServiceInstance(
          BitLabs.Messaging.Services.ServiceType.Sms, 
          new BitLabs.Messaging.Types.Credential(username, password))
       .Send(new BitLabs.Messaging.Types.SmsMessage(receipient, message));
  
  
