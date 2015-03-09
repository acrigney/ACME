namespace ACME.MessageProcessor
{
   partial class ProjectInstaller
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.MessageProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
         this.MessageprocessServiceInstaller = new System.ServiceProcess.ServiceInstaller();
         // 
         // MessageProcessInstaller
         // 
         this.MessageProcessInstaller.Password = null;
         this.MessageProcessInstaller.Username = null;
         // 
         // MessageprocessServiceInstaller
         // 
         this.MessageprocessServiceInstaller.ServiceName = "MessageProcessor";
         // 
         // ProjectInstaller
         // 
         this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MessageProcessInstaller,
            this.MessageprocessServiceInstaller});

      }

      #endregion

      private System.ServiceProcess.ServiceProcessInstaller MessageProcessInstaller;
      private System.ServiceProcess.ServiceInstaller MessageprocessServiceInstaller;
   }
}