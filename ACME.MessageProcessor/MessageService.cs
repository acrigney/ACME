using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Features;
using ACME.Shared;

namespace ACMEMessageProcessor
{
   public partial class MessageService : ServiceBase
   {
      private BusConfiguration _busConfiguration;
      private IStartableBus _startableBus;
      public MessageService()
      {
         InitializeComponent();
      }

      protected override void OnStart(string[] args)
      {
         _busConfiguration = new BusConfiguration();
         _busConfiguration.EndpointName("ACME.MessageProcessor");
         _busConfiguration.UseSerialization<JsonSerializer>();
         _busConfiguration.DisableFeature<AutoSubscribe>();
         _busConfiguration.UsePersistence<InMemoryPersistence>();
         _busConfiguration.EnableInstallers();
         _startableBus = Bus.Create(_busConfiguration);
         using (IBus bus = _startableBus.Start())
         {
            bus.Subscribe<IACMEMessage>();            
         }
      }

      protected override void OnStop()
      {
         _startableBus.Unsubscribe<IACMEMessage>();
      }
   }
}
