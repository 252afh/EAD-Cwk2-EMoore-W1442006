namespace EAD_Cwk2_EMoore_W1442006.Models
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// An instance of a <see cref="Contact"/> object used to store common information between <see cref="Payer"/> and <see cref="Payee"/>
    /// </summary>
    [Serializable()]
    public class Contact
    {
        /// <summary>
        /// The id of the <see cref="Contact"/>
        /// </summary>
        [XmlAttribute("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the <see cref="Contact"/>
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
