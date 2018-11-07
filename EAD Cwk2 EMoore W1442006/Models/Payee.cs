using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EAD_Cwk2_EMoore_W1442006.Models
{
    public class Payee : Contact
    {
        /// <summary>
        /// The sort code related to a <see cref="Payee"/>
        /// </summary>
        [XmlAttribute]
        public int SortCode { get; set; }

        /// <summary>
        /// The account number related to a <see cref="Payee"/>
        /// </summary>
        [XmlAttribute]
        public int AccNumber { get; set; }
    }
}
