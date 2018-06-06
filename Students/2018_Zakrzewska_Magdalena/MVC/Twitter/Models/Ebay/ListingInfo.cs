using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("listingInfo")]
    public class ListingInfo
    {
        public int Id { get; set; }

        [XmlElement("bestOfferEnabled")]
        public string bestOfferEnabled { get; set; }

        [XmlElement("buyItNowAvailable")]
        public string buyItNowAvailable { get; set; }

        [XmlElement("startTime")]
        public string startTime { get; set; }

        [XmlElement("endTime")]
        public string endTime { get; set; }

        [XmlElement("listingType")]
        public string listingType { get; set; }

        [XmlElement("gift")]
        public string gift { get; set; }
    }
}