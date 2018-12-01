namespace EAD_Cwk2_EMoore_W1442006.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// An instance of <see cref="Income"/> used to store information about incomes
    /// </summary>
    [XmlRoot("income")]
    public class Income : Payment
    {
        /// <summary>
        /// The <see cref="Models.Payer"/> related to the income payment
        /// </summary>
        [XmlAttribute("Payer")]
        public Payer Payer { get; set; }
    }
}
