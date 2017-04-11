using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CardImporter
{
    [XmlType("Card")]
    public class Card
    {
        [XmlAttribute("color")]
        public string Color { get; set; }
        
        [XmlAttribute("value")]
        public int Value { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlArray("Icons")]
        [XmlArrayItem("Icon")]
        public string[] Icons { get; set; }
    }
}
