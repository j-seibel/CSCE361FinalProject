using CardGame.Models;
using System;

namespace CardGameTests
{
    [TestClass]
    public class ELOTests
    {
        [TestMethod]
        public void TestELOValid()
        {
            Player p = new Player("TestName", "TestRoom", 1000);
            p.updateElo(1100, 1);
            Assert.IsTrue(p.ELO -  1003.6 < 0.1);

        }

        [TestMethod]
        public void TestELOInvalid()
        {
            Player p = new Player("TestName", "TestRoom", 1000);
            Assert.ThrowsException<ArgumentException>(() => p.updateElo(-1000, 0));


        }

        [TestMethod]

        public void TestRatingInvalid()
        {
            Player p = new Player("TestName", "TestRoom", 1000);
            Assert.ThrowsException<ArgumentException>(() => p.updateElo(1000, -2));

        }
    }
}