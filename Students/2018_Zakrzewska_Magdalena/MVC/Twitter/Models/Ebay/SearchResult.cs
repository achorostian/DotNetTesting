using System.Collections.Generic;
using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("searchResult")]
    public class SearchResult
    {
        public int Id { get; set; }
        
        [XmlElement("item")]
        public List<EbayItem> item { get; set; }
    }
}