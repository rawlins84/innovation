using System;
using CardImporter;
using System.Xml;
using System.Xml.Serialization;
using System.Resources;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace CardImporterTest
{
    [TestClass]
    public class CardImporterTests
    {
        private readonly string[] icon_types = {"Castle", "LightBulb", "Hexagon", "Factory", "Leaf", "Crown", "Clock"};
        
        [TestMethod]
        public void CanInitializeCard()
        {
            Card c = new Card();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void ValidateAllCards()
        {
            foreach( var card in XmlCardReader.GetCards())
            {
                IsValidCard(card);
            }
        }

        private void IsValidCard(Card c)
        {
            Assert.IsTrue(IsAColor(c.Color), MessageOnFail("Failed Color verification", c));
            Assert.IsTrue(ValueIsWithinRange(c.Value), MessageOnFail("Failed Value verification", c));
            Assert.IsTrue(IsAcceptableTitle(c.Title), MessageOnFail("Failed title verification", c));
            Assert.IsTrue(ContainsLegitimateIcons(c.Icons), MessageOnFail("Failed icon verification", c));
        }
        private string MessageOnFail(string failMessage, Card card)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(GetCardInfo(card));
            builder.AppendLine(failMessage);
            return builder.ToString();
        }

        private string GetCardInfo(Card c)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("####Card######");
            builder.AppendLine(c.Title);
            builder.AppendLine(c.Color);
            builder.AppendLine(c.Value.ToString());
            builder.AppendLine(string.Join(",", c.Icons));
            return builder.ToString();
        }

        private bool IsIconHexagon(string icon)
        {
            return icon == "Hexagon";
        }

        private bool ContainsLegitimateIcons(string [] icons)
        {
            if (icons.Length != 4) return false;

            int hexagonCount = 0;
            bool pass = true;
            foreach(string icon in icons)
            {
                if (IsIconHexagon(icon))
                {
                    hexagonCount++;
                }
                if (icon_types.Contains(icon))
                    continue;
                pass = false;
            }
            return pass && hexagonCount == 1;
        }

        

        private bool IsAcceptableTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title);
        }

        private bool ValueIsWithinRange(int value)
        {
            return 1 <= value && value <= 10;
        }

        private bool IsAColor(string color)
        {
            bool pass = false;
            switch(color) {
                case "purple":
                case "blue":
                case "green":
                case "yellow":
                case "pink":
                    pass = true;
                    break;
                default:
                    pass = false;
                    break;
            }
            return pass;
        }

        private Card GetSampleCard()
        {
           return XmlCardReader.GetCards().First();
        }
    }
}
