using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("condition")]
    public class Condition
    {
        public int Id { get; set; }

        [XmlElement("conditionId")]
        public string conditionId { get; set; }

        [XmlElement("conditionDisplayName")]
        public string conditionDisplayName { get; set; }
    }
}