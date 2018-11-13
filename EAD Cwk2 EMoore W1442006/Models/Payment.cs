using System;
using System.Xml.Serialization;

namespace EAD_Cwk2_EMoore_W1442006.Models
{
    [Serializable()]
    public class Payment
    {
        /// <summary>
        /// The Id of the payment
        /// </summary>
        [XmlAttribute("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The payment reference
        /// </summary>
        [XmlAttribute("Reference")]
        public string Ref { get; set; }

        /// <summary>
        /// The amount of the payment
        /// </summary>
        [XmlAttribute("Amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Whether the payment is recurring or not
        /// </summary>
        [XmlAttribute("Recurring")]
        public bool IsRecurring { get; set; }

        /// <summary>
        /// The interval in days between recurring payments
        /// </summary>
        [XmlAttribute("Interval")]
        public int Interval { get; set; }

        /// <summary>
        /// The initial payment date if a recurring payment or the paid date if one-off
        /// </summary>
        [XmlAttribute("InitialDate")]
        public DateTime InitialPaidDate { get; set; }

        /// <summary>
        /// The last date the payment was paid on
        /// This will be set to the <see cref="InitialPaidDate"/> if a one-off payment
        /// </summary>
        [XmlAttribute("LastPaidDate")]
        public DateTime LastPaidDate { get; set; }
    }
}
