using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using NServiceBus;

namespace ACME.Conventions
{
   // DateConfig class to specify how dates are to be formated by the ACME company. Assuming that it is required
   // that all dates be displayed consistently.
   public class DateConfig : INeedInitialization
   {
      public void Customize(BusConfiguration config)
      {
         CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
         newCulture.DateTimeFormat.ShortDatePattern = "dd MMM yyyy";
         newCulture.DateTimeFormat.DateSeparator = " ";
         Thread.CurrentThread.CurrentCulture = newCulture;
         CultureInfo.DefaultThreadCurrentCulture = newCulture;
      }
   }
}
