using System.Xml.Serialization;

namespace Twitter.Models.Ebay
{
    [XmlRoot("primaryCategory")]
    public class Category
    {
        public int Id { get; set; }

        [XmlElement("categoryId")]
        public string categoryId { get; set; }


        [XmlElement("categoryName")]
        public string categoryName { get; set; }
    }
}