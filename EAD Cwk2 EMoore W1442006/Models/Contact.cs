namespace EAD_Cwk2_EMoore_W1442006.Models
{
    using System;
    using System.Xml.Serialization;

    [Serializable()]
    public class Contact
    {
        [XmlAttribute("Id")]
        public Guid Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
