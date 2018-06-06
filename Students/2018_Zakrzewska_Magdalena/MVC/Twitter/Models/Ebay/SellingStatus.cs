using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("shippingStatus")]
    public class SellingStatus
    {
        public int Id { get; set; }

        [XmlElement("currentPrice")]
        public string currentPrice { get; set; }

        [XmlElement("convertedCurrentPrice")]
        public string convertedCurrentPrice { get; set; }

        [XmlElement("sellingState")]
        public string sellingState { get; set; }

        [XmlElement("timeLeft")]
        public string timeLeft { get; set; }
    }
}