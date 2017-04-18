using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Game
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

        public override bool Equals(object obj)
        {
            Card card = obj as Card;
            if (card == null) return false;

            return this.Color == card.Color &&
                   this.Value == card.Value &&
                   this.Title == card.Title;
           
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}
