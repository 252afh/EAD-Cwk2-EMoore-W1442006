namespace EAD_Cwk2_EMoore_W1442006.Models
{
    using System.Xml.Serialization;

    [XmlRoot("income")]
    public class Income : Payment
    {
        /// <summary>
        /// The <see cref="Payer"/> related to the income payment
        /// </summary>
        [XmlAttribute("Payer")]
        public Payer Payer { get; set; }
    }
}
