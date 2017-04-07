using System;
using CardImporter;
using System.Xml;
using System.Xml.Serialization;
using System.Resources;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardImporterTest
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CanInitializeCard()
        {
            Card c = new Card();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void CanReadCardFromXml()
        {
            Card c = GetSampleCard();

            string expectedColor = "purple";
            Assert.AreEqual(expectedColor, c.Color);
            
            int expectedValue = 6;
            Assert.AreEqual(expectedValue, c.Value);

            string expectedTitle = "Emancipation";
            Assert.AreEqual(expectedTitle, c.Title);

            string[] expectedIcons = { "factory", "light-bulb", "factory", "hexagon" };
            CollectionAssert.AreEqual(expectedIcons, c.Icons);
        }

        private Card GetSampleCard()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Card));
            StringReader strReader = new StringReader(CardSamples.basic_card);
            XmlReader reader = XmlReader.Create(strReader);
            Card c = (Card)serializer.Deserialize(reader);
            return c;
        }
    }
}
