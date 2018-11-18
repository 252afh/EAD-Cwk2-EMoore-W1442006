namespace EAD_Cwk2_EMoore_W1442006.Models
{
    using System.Xml.Serialization;

    [XmlRoot("expense")]
    public class Expense : Payment
    {
        /// <summary>
        /// The <see cref="Payee"/> related to a expense payment
        /// </summary>
        [XmlAttribute("Payee")]
        public Payee Payee { get; set; }
    }
}
