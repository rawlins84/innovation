using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardImporter;
using Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardImporterTest
{
    [TestClass]
    public class DemandTests
    {
        [TestMethod]
        public void VerifyDrawDemand()
        {
            Card[] allCards = XmlCardReader.GetCards();
            int deckCount = allCards.Length;
            Card[] expectedHand = {allCards[0]};
            Card[] actualHand =  Demands.Draw(ref allCards, 1);
            CollectionAssert.AreEqual(expectedHand, actualHand);
            Assert.AreEqual(deckCount - 1, allCards.Length, "Verify card removed from drawn pile.");
        }

        [TestMethod]
        public void VerifyDrawAllDemand()
        {
            Card[] allCards = XmlCardReader.GetCards();
            Card[] expectedHand = XmlCardReader.GetCards();
            int countAllCards = allCards.Length;
            Card[] actualHand = Demands.Draw(ref allCards, countAllCards);
            Assert.AreEqual(0, allCards.Length, "Drawn pile should be empty.");
            CollectionAssert.AreEqual(expectedHand, actualHand);
        }
    }
}
