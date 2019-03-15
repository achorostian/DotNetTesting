using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("item")]
    public class EbayItem
    {
        public int Id { get; set; }

        [XmlElement("itemId")]
        public string itemId { get; set; }

        [XmlElement("title")]
        public string title { get; set; }

        [XmlElement("globalId")]
        public string globalId { get; set; }

        [XmlElement("primaryCategory")]
        public Category primaryCategory { get; set; }

        [XmlElement("galleryUrl")]
        public string galleryUrl { get; set; }

        [XmlElement("viewItemUrl")]
        public string viewItemUrl { get; set; }

        [XmlElement("paymentMethod")]
        public string paymentMethod { get; set; }

        [XmlElement("autoPay")]
        public string autoPay { get; set; }

        [XmlElement("location")]
        public string location { get; set; }

        [XmlElement("country")]
        public string country { get; set; }

        [XmlElement("shippingInfo")]
        public ShippingInfo shippingInfo { get; set; }

        [XmlElement("sellingStatus")]
        public SellingStatus sellingStatus { get; set; }

        [XmlElement("listingInfo")]
        public ListingInfo listingInfo { get; set; }

        [XmlElement("returnsAccepted")]
        public string returnsAccepted { get; set; }

        [XmlElement("condition")]
        public Condition condition { get; set; }

        [XmlElement("isMultiVariationListing")]
        public string isMultiVariationListing { get; set; }

        [XmlElement("discountPriceInfo")]
        public DiscountPriceInfo discountPriceInfo { get; set; }

        [XmlElement("topRatedListing")]
        public string topRatedListing { get; set; }
    }
}