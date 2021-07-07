using Blackjack.Data;
using Blackjack.Data.Enums;
using NUnit.Framework;

namespace CoreGameTesting
{
    public class CardTests
    {
        [Test]
        public void NormalCard_GetValue()
        {
            var fiveHearts = new Card(CardValue.Five, SuiteType.Hearts);

            var cardVal = fiveHearts.GetCardValue();

            Assert.AreEqual(5, cardVal);
        }

        [Test]
        public void Ace_GetValue()
        {
            var aceSpades = new Card(CardValue.Ace, SuiteType.Spades);

            var cardVal = aceSpades.GetCardValue();

            Assert.AreEqual(11, cardVal);
        }

        [Test]
        public void FaceCard_GetValue()
        {
            var kingClubs = new Card(CardValue.King, SuiteType.Clubs);
            var queenClubs = new Card(CardValue.Queen, SuiteType.Clubs);
            var jackClubs = new Card(CardValue.Jack, SuiteType.Clubs);


            var kingCardValue = kingClubs.GetCardValue();
            var queenCardValue = queenClubs.GetCardValue();
            var jackCardValue = jackClubs.GetCardValue();

            Assert.AreEqual(10, kingCardValue);
            Assert.AreEqual(10, queenCardValue);
            Assert.AreEqual(10, jackCardValue);
        }
    }
}