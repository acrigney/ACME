using System;
using System.Text;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using TracerX;
using System.Threading;

namespace ACME.Shared
{
   [Serializable]
   public class NewBornMessage : BaseMessage
   {
      public DateTime BirthDate { get; set; }

      public string BirthDateString { get; set; }
      public Gender Gender { get; set; }

      [JsonIgnore]
      private bool IsNameBase64Encoded { get; set; } // To make ProcessMessage Indempotent

      private static readonly Logger Log =
            Logger.GetLogger("NewBornMessage");

      public NewBornMessage()
      {
         StandardMessageText = string.Format("Congratulations");
      }
      public override bool ProcessMessage()
      {
         if (!IsNameBase64Encoded)
         {
            if (Name != null)
            {
               byte[] bytesToEncode = Encoding.UTF8.GetBytes(Name);
               Name = Convert.ToBase64String(bytesToEncode);
               IsNameBase64Encoded = true;
            }
         }

         BirthDateString = DateTime.Now.ToShortDateString(); // The ShortDateFormat can be set globally by using a
                                                             // Format specified in the ACME.Conventions assembly.
                                                             // This assembly can contain classes that provide initializations
                                                             // For NServiceBus

         base.ProcessMessage();

         Log.Info(this);

         return (false);
      }

      public override void Serialize()
      {
         string fileName = string.Format(@"c:\TestOutput\BabyBirth\{0}.txt", this.ToFileName());

         Directory.CreateDirectory(Path.GetDirectoryName(fileName));

         using (StreamWriter sw = new StreamWriter(fileName, false))
         {
            XmlSerializer serializer = new XmlSerializer(this.GetType());

            serializer.Serialize(sw, this);
         }
      }
   }
}