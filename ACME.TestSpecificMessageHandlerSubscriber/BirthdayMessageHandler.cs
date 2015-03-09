using System;
using ACME.Shared;
using NServiceBus;

public class BirthdayMessageHandler : IHandleMessages<BirthdayMessage>
{
    public void Handle(BirthdayMessage message)
    {
        Console.WriteLine("Subscriber 1 received EventMessage with Id {0}.", message.MessageId);
        Console.WriteLine("Birth day Message date: {0}.", message.BirthDate);
        Console.WriteLine("Birth day Message gift name: {0}.", message.Gift != null ? message.Gift.Name : "Unspecified");
      message.ProcessMessage();
      Console.WriteLine("==========================================================================");
    }
}