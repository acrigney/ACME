using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;

namespace ACME.MessageProcessor
{

   [RunInstaller(true)]
   public class MessageProcessorServiceInstaller : Installer
   {
      private ServiceInstaller serviceInstaller1;      
      private ServiceProcessInstaller processInstaller;

      public MessageProcessorServiceInstaller()
      {
         // Instantiate installers for process and services.
         processInstaller = new ServiceProcessInstaller();
         serviceInstaller1 = new ServiceInstaller();


         // The services run under the system account.
         processInstaller.Account = ServiceAccount.LocalSystem;

         // The services are started manually.
         serviceInstaller1.StartType = ServiceStartMode.Manual;


         // ServiceName must equal those on ServiceBase derived classes.
         serviceInstaller1.ServiceName = "MessageService";

         // Add installers to collection. Order is not important.
         Installers.Add(serviceInstaller1);

         Installers.Add(processInstaller);
      }   
   }
}
