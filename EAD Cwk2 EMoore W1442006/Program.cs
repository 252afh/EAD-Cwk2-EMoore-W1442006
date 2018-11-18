using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;
using EAD_Cwk2_EMoore_W1442006.Views;
using Payer = EAD_Cwk2_EMoore_W1442006.Models.Payer;

namespace EAD_Cwk2_EMoore_W1442006
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new XmlDataAccess().LoadXml();
            Application.Run(new MainMenuForm());
        }
    }
}
