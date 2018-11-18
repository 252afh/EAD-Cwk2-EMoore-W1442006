﻿namespace EAD_Cwk2_EMoore_W1442006.Models
{
    using System.Xml.Serialization;

    [XmlRoot("payer")]
    public class Payer : Contact
    {
        /// <summary>
        /// The type of payment this is likely to be, e.g. bills
        /// </summary>
        [XmlAttribute("Type")]
        public string PaymentType { get; set; }
    }
}
