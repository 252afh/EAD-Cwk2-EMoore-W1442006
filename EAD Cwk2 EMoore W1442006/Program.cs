namespace EAD_Cwk2_EMoore_W1442006
{
    using DataAccess;
    using System;
    using System.Windows.Forms;
    using Views;

    /// <summary>
    /// The main execution class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new XmlDataAccess().LoadXml();
            Application.Run(new MainMenuForm());
        }
    }
}
