using System;
using NServiceBus;

namespace ACME.Shared
{
    public interface IACMEMessage: IEvent
    {
      Guid MessageId { get; set; }
      MessageType MessageType { get; set; }
      string Name { get; set; }
      string StandardMessageText { get; set; }
      bool ProcessMessage();
   }
}
