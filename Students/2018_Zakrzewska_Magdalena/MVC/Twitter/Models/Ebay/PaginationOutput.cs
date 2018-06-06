using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("paginationOutput")]
    public class PaginationOutput
    {
        public int Id { get; set; }

        [XmlElement("pageNumber")]
        public string pageNumber { get; set; }

        [XmlElement("entriesPerPage")]
        public string entriesPerPage { get; set; }

        [XmlElement("totalPages")]
        public string totalPages { get; set; }

        [XmlElement("totalEntries")]
        public string totalEntries { get; set; }
    }
}