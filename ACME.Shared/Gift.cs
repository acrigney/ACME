using System;
using System.Drawing;

namespace ACME.Shared
{
    [Serializable]
    public class Gift 
    {
      public string Name { get; set; }
      public Image Image { get; set; }
   }
}