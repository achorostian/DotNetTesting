using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("findItemsAdvancedResponse")]
    public class Items
    {
        public int Id { get; set; }

        [XmlElement("ack")]
        public string ack { get; set; }

        [XmlElement("version")]
        public string version { get; set; }

        [XmlElement("timestamp")]
        public string timestamp { get; set; }

        [XmlElement("searchResult")]
        public SearchResult searchResult { get; set; }

        [XmlElement("paginationOutput")]
        public PaginationOutput paginationOutput { get; set; }

        [XmlElement("itemSearchUrl")]
        public string itemSearchUrl { get; set; }
    }
}