using System;

namespace ACME.Shared
{
    [Serializable]
    public abstract class BaseMessage : IACMEMessage
    {
      public Guid MessageId { get; set; }
      public MessageType MessageType { get; set; }
      public string Name { get; set; }
      public string StandardMessageText { get; set; }
      public string FilePath { get; set; }

      // We could put the logging in the base ProcessMessage here
      // but then we would limit the control of how the logging is done.
      // e.g in this case TraceX logger needs the name of the log, 
      // we could still put the trace log here but only for 1 log.
      // Its much nicer to have separate logs for every message processing etc.

      public virtual bool ProcessMessage()
      {
         Serialize();
         return (true);
      }
         
      public abstract void Serialize();

      public string ToFileName()
      {
         return (MessageId.ToString("D"));
      }
   }
}