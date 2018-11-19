namespace EAD_Cwk2_EMoore_W1442006.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// An instance of <see cref="Expense"/> used to store information about expenses
    /// </summary>
    [XmlRoot("expense")]
    public class Expense : Payment
    {
        /// <summary>
        /// The <see cref="Models.Payee"/> related to a expense payment
        /// </summary>
        [XmlAttribute("Payee")]
        public Payee Payee { get; set; }
    }
}
