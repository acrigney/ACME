using System;
using ACME.Shared;
using NServiceBus;

static class Program
{

   static void Main()
   {
      BusConfiguration busConfiguration = new BusConfiguration();
      busConfiguration.EndpointName("ACME.TestPublisher");
      busConfiguration.UseSerialization<JsonSerializer>();
      busConfiguration.UsePersistence<InMemoryPersistence>();
      busConfiguration.EnableInstallers();
      IStartableBus startableBus = Bus.Create(busConfiguration);
      using (IBus bus = startableBus.Start())
      {
         Start(bus);
      }
   }

   static void Start(IBus bus)
   {
      Console.WriteLine("This will publish a birthday wish message and a congratulations on the birth of your child message alternately.");
      Console.WriteLine("Press 'Enter' to publish the messages.To exit, Ctrl + C");
      #region PublishLoop
      int nextEventToPublish = 0;
      while (Console.ReadLine() != null)
      {
         Guid eventId = Guid.NewGuid();
         switch (nextEventToPublish)
         {
            case 0:
               bus.Publish<BirthdayMessage>(m =>
               {
                  m.MessageId = eventId;
                  m.MessageType = MessageType.HappyBirthday;
                  m.BirthDate = DateTime.Now.Date;
                  m.Name = "Fred";                  
                  m.Gift = new Gift { Name = "A gift Image Name" };
               });
               nextEventToPublish = 1;
               break;
            case 1:
               NewBornMessage boy = new NewBornMessage
               {
                  MessageId = eventId,
                  MessageType = MessageType.NewBaby,
                  Name = "John",
                  Gender = Gender.Male                  
               };
               bus.Publish(boy);
               nextEventToPublish = 2;
               break;
            default:
               NewBornMessage girl = new NewBornMessage
               {
                  MessageId = eventId,
                  MessageType = MessageType.NewBaby,
                  Gender = Gender.Female,
                  Name ="Sandy"
               };
               bus.Publish(girl);
               nextEventToPublish = 0;
               break;
         }

         Console.WriteLine("Published event with Id {0}.", eventId);

         Console.WriteLine("==========================================================================");
      }
      #endregion
   }

}