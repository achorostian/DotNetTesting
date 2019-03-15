using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("discountPriceInfo")]
    public class DiscountPriceInfo
    {
        public int Id { get; set; }

        [XmlElement("originalRetailPrice")]
        public string originalRetailPrice { get; set; }

        [XmlElement("minimumAdvertisedPriceExposure")]
        public string minimumAdvertisedPriceExposure { get; set; }

        [XmlElement("pricingTreatment")]
        public string pricingTreatment { get; set; }
    }
}