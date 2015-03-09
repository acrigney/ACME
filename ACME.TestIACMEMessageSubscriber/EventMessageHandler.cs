using System;
using NServiceBus;
using ACME.Shared;

public class EventMessageHandler : IHandleMessages<IACMEMessage>
{
    public void Handle(IACMEMessage message)
    {
      Console.WriteLine("IACMEMessage Subscriber received Message with Id {0}.", message.MessageId);
      message.ProcessMessage();
      Console.WriteLine("==========================================================================");
    }
}