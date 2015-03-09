using System;
using ACME.Shared;
using NServiceBus;

public class NewBornMessageHandler : IHandleMessages<NewBornMessage>
{
   public void Handle(NewBornMessage message)
   {
      Console.WriteLine("Subscriber 1 received NewBornMessage with Id {0}.", message.MessageId);
      Console.WriteLine("NewBornMessage birth date: {0}.", message.BirthDate);
      Console.WriteLine("NewBornMessage gender: {0}.", Enum.GetName(typeof(Gender), message.Gender));
      message.ProcessMessage();
      Console.WriteLine("==========================================================================");
   }
}