using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EAD_Cwk2_EMoore_W1442006.Models
{
    public class Payer : Contact
    {
        /// <summary>
        /// The type of payment this is likely to be, e.g. bills
        /// </summary>
        [XmlAttribute("Type")]
        public string PaymentType { get; set; }
    }
}
