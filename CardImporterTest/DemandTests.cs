using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardImporter;
using Actions; 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;

namespace CardImporterTest
{
    [TestClass]
    public class DemandTests
    {
        private Card[] _allCards;
 
        [TestInitialize]
        public void TestSetup()
        {
            _allCards = XmlCardReader.GetCards();
        }

        [TestMethod]
        public void VerifyDrawDemand()
        { 
            int deckCount = _allCards.Length;
            Card[] expectedHand = {_allCards[0]};
            Card[] actualHand =  Demands.Draw(ref _allCards, 1);
            CollectionAssert.AreEqual(expectedHand, actualHand);
            Assert.AreEqual(deckCount - 1, _allCards.Length, "Verify card removed from drawn pile.");
        }

        [TestMethod]
        public void VerifyDrawAllDemand()
        {
            Card[] expectedHand = XmlCardReader.GetCards();
            int countAllCards = _allCards.Length;
            Card[] actualHand = Demands.Draw(ref _allCards, countAllCards);
            Assert.AreEqual(0, _allCards.Length, "Drawn pile should be empty.");
            CollectionAssert.AreEqual(expectedHand, actualHand);
        }

        [TestMethod]
        public void VerifyDrawHigestValueCard()
        {
            Card[] anyHand = new Card[] {
                _allCards[_allCards.Length - 1], //highest card
                _allCards[1],
                _allCards[2],
                _allCards[3],
                _allCards[4]
            };

            int expectedValue = 10;
            Card drawnCard = Demands.DrawHighestValue(ref anyHand);
            Assert.AreEqual(expectedValue, drawnCard.Value, Common.MessageOnFail("Drawn card should be highest card.", drawnCard));
        }

        [TestMethod]
        public void TransferCard()
        {
            Card cardToTransfer = _allCards[0];
            Hand playerHand = new Hand(new Card[] { cardToTransfer });
            Hand otherPlayerHand = new Hand(new Card[0]);

            int indexOfCardToTransfer = 0;

            playerHand.TransferAt(indexOfCardToTransfer, otherPlayerHand);
            Assert.IsTrue(playerHand.IsEmpty(), "Player hand should be empty.");
            Assert.IsTrue(otherPlayerHand.Contains(cardToTransfer), "Hand should contain transfered card.");
        }
    }
}
