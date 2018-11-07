using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
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
            LoadXml();
            Application.Run(new MainMenuForm());
        }

        private static void LoadXml()
        {
            XElement data = XElement.Load("C:\\Users\\Elliot\\Documents\\SaveFile.xml");
            XElement payer = data.Element("Payers");
            XmlSerializer serializer = new XmlSerializer(typeof(Payer));

            foreach (var xElement in payer.Elements())
            {
                Payer p = (Payer)serializer.Deserialize(new StringReader(payer.ToString()));
            }
            
            
        }
    }
}
