using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("shippingInfo")]
    public class ShippingInfo
    {
        public int Id { get; set; }

        [XmlElement("shippingServiceCost")]
        public string shippingServiceCost { get; set; }

        [XmlElement("shippingType")]
        public string shippingType { get; set; }

        [XmlElement("shipToLocations")]
        public string shipToLocations { get; set; }

        [XmlElement("expeditedShipping")]
        public string expeditedShipping { get; set; }

        [XmlElement("oneDayShippingAvailable")]
        public string oneDayShippingAvailable { get; set; }

        [XmlElement("handlingTime")]
        public string handlingTime { get; set; }
    }
}