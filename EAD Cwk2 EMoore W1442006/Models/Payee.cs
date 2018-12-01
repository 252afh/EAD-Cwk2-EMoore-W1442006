namespace EAD_Cwk2_EMoore_W1442006.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// An instance of <see cref="Payee"/> used to store inormation about payees
    /// </summary>
    [XmlRoot("payee")]
    public class Payee : Contact
    {
        /// <summary>
        /// The sort code
        /// </summary>
        [XmlAttribute("SortCode")]
        public string SortCode { get; set; }

        /// <summary>
        /// The account number
        /// </summary>
        [XmlAttribute("AccNumber")]
        public string AccNumber { get; set; }

        /// <summary>
        /// A simple address
        /// </summary>
        [XmlAttribute("Address")]
        public string Address { get; set; }
    }
}
