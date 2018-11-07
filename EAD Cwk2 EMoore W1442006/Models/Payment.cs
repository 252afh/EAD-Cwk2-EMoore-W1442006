using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EAD_Cwk2_EMoore_W1442006.Models
{
    [Serializable()]
    public class Payment
    {
        /// <summary>
        /// The Id of the payment
        /// </summary>
        [XmlAttribute]
        public Guid Id { get; set; }

        /// <summary>
        /// The payment reference
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// The amount of the payment
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Whether the payment is recurring or not
        /// </summary>
        public bool IsRecurring { get; set; }

        /// <summary>
        /// The interval in days between recurring payments
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// The initial payment date if a recurring payment or the paid date if one-off
        /// </summary>
        public DateTime InitialPaidDate { get; set; }

        /// <summary>
        /// The last date the payment was payed on
        /// This will be set to the <see cref="InitialPaidDate"/> if a one-off payment
        /// </summary>
        public DateTime LastPayedDate { get; set; }
    }
}
