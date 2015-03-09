using System;
using ACME.Shared;
using NServiceBus;
using NServiceBus.Features;

static class Program
{
    static void Main()
    {
        BusConfiguration busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("ACME.TestIACMEMessageSubscriber");
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.DisableFeature<AutoSubscribe>();
        busConfiguration.UsePersistence<InMemoryPersistence>();
        busConfiguration.EnableInstallers();
        IStartableBus startableBus = Bus.Create(busConfiguration);
        using (IBus bus = startableBus.Start())
        {
            bus.Subscribe<IACMEMessage>();
            Console.WriteLine("To exit, Ctrl + C");
            Console.ReadLine();
            bus.Unsubscribe<IACMEMessage>();
        }
    }
}