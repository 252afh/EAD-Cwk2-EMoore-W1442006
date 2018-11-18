namespace EAD_Cwk2_EMoore_W1442006.Models
{
    using System.Xml.Serialization;

    [XmlRoot("payee")]
    public class Payee : Contact
    {
        /// <summary>
        /// The sort code related to a <see cref="Payee"/>
        /// </summary>
        [XmlAttribute("SortCode")]
        public string SortCode { get; set; }

        /// <summary>
        /// The account number related to a <see cref="Payee"/>
        /// </summary>
        [XmlAttribute("AccNumber")]
        public string AccNumber { get; set; }

        /// <summary>
        /// A simple address for a <see cref="Payee"/>
        /// </summary>
        [XmlAttribute("Address")]
        public string Address { get; set; }
    }
}
