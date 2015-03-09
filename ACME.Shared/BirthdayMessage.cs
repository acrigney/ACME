using System;
using System.IO;
using Newtonsoft.Json;
using TracerX;

namespace ACME.Shared
{
   [Serializable]
   public class BirthdayMessage : BaseMessage
   {      
      public DateTime BirthDate { get; set; }
      public Gift Gift { get; set; }

      private static readonly Logger Log =
            Logger.GetLogger("BirthdayMessage");

      public BirthdayMessage()
      {
         StandardMessageText = string.Format("Happy Birthday {0}", Name);
      }
      
      public override bool ProcessMessage()
      {
         if (StandardMessageText != null)
         {
            StandardMessageText = StandardMessageText.ToUpper(); // Will be indempotent
         }

         base.ProcessMessage();

         Log.Info(this);

         return (true);
      }

      public override void Serialize()
      {
         string fileName = string.Format(@"c:\TestOutput\Birthdays\{0}.txt", this.ToFileName());
         string allFields = JsonConvert.SerializeObject(this,
            Formatting.Indented,
            new JsonSerializerSettings { });

         Directory.CreateDirectory(Path.GetDirectoryName(fileName));

         StreamWriter file = new StreamWriter(fileName);
         file.WriteLine(allFields);

         file.Close();
      }
   }
}