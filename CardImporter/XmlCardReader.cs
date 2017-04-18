using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Game;

namespace CardImporter
{
    public class XmlCardReader
    {
        public static Card[] GetCards()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Card[]), new XmlRootAttribute("Cards"));
            StringReader strReader = new StringReader(Resources.cards);
            XmlReader reader = XmlReader.Create(strReader);
            Card[] cards = (Card[])serializer.Deserialize(reader);
            return cards;
        }
    }
}
